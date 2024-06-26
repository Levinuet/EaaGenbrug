﻿using System;
using Core.Model;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace ServerAPI.Repositories
{
    public class AdRepositoryMongoDB : IAdRepository
    {
        private IMongoClient client;
        private IMongoCollection<Ad> collection;

        public AdRepositoryMongoDB()
        {
            // Initializes the MongoDB client connection with authentication and targets our database and collection.
            var password = "XdWOg0DZEhGTpzuX";
            var mongoUri = $"mongodb+srv://eaa23rao:{password}@shopping.dujfobz.mongodb.net/?retryWrites=true&w=majority";
            try
            {
                client = new MongoClient(mongoUri);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem connecting to your " +
                    "Atlas cluster. Check that the URI includes a valid " +
                    "username and password, and that your IP address is " +
                    $"in the Access List. Message: {e.Message}");
                Console.WriteLine(e);
                Console.WriteLine();
                return;
            }

            var dbName = "Eaagenbrug";
            var collectionName = "Ads";
            collection = client.GetDatabase(dbName)
               .GetCollection<Ad>(collectionName);
        }

        public void AddAd(Ad ad)
        {
            // Adds a new ad to the collection with an auto-incremented ID.
            var max = 0;
            if (collection.Count(Builders<Ad>.Filter.Empty) > 0)
            {
                max = collection.Find(Builders<Ad>.Filter.Empty).SortByDescending(r => r.Id).Limit(1).ToList()[0].Id;
            }
            ad.Id = max + 1;
            collection.InsertOne(ad);
        }

        public void DeleteById(int id)
        {
            // Deletes an ad by its ID.
            var deleteResult = collection
                .DeleteOne(Builders<Ad>.Filter.Where(r => r.Id == id));
        }

        public Ad[] GetAll()
        {
            // Retrieves all ads from the collection.
            return collection.Find(Builders<Ad>.Filter.Empty).ToList().ToArray();
        }

        public void PurchaseAd(Ad ad)
        {
            // Marks an ad as reserved if it isn't already.
            if (ad.Status != "Reserved")
            {
                var updateDef = Builders<Ad>.Update
            .Set(x => x.Status, "Reserved")
            .Set(x => x.BuyerUserName, ad.BuyerUserName);

                collection.UpdateOne(x => x.Id == ad.Id, updateDef);
            }
        }

        public void ApproveAd(Ad ad)
        {
            // Changes the status of an ad to 'Sold'.
            var updateDef = Builders<Ad>.Update
                .Set(x => x.Status, "Sold");

            collection.UpdateOne(x => x.Id == ad.Id, updateDef);
        }

        public void UpdateAd(Ad ad)
        {
            // Updates the specified fields of an existing ad.
            var updateDef = Builders<Ad>.Update
        .Set(x => x.Title, ad.Title)
        .Set(x => x.Price, ad.Price)
        .Set(x => x.Location, ad.Location)
        .Set(x => x.Category, ad.Category)
        .Set(x => x.ImageUrl, ad.ImageUrl)
        .Set(x => x.Status, ad.Status);
            collection.UpdateOne(x => x.Id == ad.Id, updateDef);
        }
    }

}