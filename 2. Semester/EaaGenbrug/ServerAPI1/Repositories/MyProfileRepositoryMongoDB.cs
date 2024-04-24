/*using System;
using Core.Model;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace ServerAPI.Repositories
{
    public class MyProfileRepositoryMongoDB : IMyProfileRepository
    {
        private IMongoClient client;
        private IMongoCollection<Ad> collection;

        public MyProfileRepositoryMongoDB()
        {
            var password = "genbrug123"; 
            var mongoUri = $"mongodb+srv://Miniprojekt:{password}@miniprojekt.nb8ncxm.mongodb.net/?retryWrites=true&w=majority";
           
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

            // Provide the name of the database and collection you want to use.
            var dbName = "myDatabase";
            var collectionName = "ads";

            collection = client.GetDatabase(dbName)
                .GetCollection<Ad>(collectionName);
        }

        public void AddAd(Ad ad)
        {
            var max = 0;
            if (collection.CountDocuments(Builders<Ad>.Filter.Empty) > 0)
            {
                max = collection.Find(Builders<Ad>.Filter.Empty).SortByDescending(r => r.Id).Limit(1).ToList()[0].Id;
            }
            ad.Id = max + 1;
            collection.InsertOne(ad);
        }

        public void DeleteAd(int id)
        {
            var deleteResult = collection.DeleteOne(Builders<Ad>.Filter.Eq(r => r.Id, id));
        }

        public Ad[] GetAllAds()
        {
            return collection.Find(Builders<Ad>.Filter.Empty).ToList().ToArray();
        }

        public void UpdateAd(Ad ad)
        {
            var updateDef = Builders<Ad>.Update
                .Set(x => x.Title, ad.Title)
                .Set(x => x.Description, ad.Description)
                .Set(x => x.Price, ad.Price)
                .Set(x => x.ImageUrl, ad.ImageUrl)
                .Set(x => x.Category, ad.Category)
                .Set(x => x.Location, ad.Location)
                .Set(x => x.Status, ad.Status);
            collection.UpdateOne(Builders<Ad>.Filter.Eq(r => r.Id, ad.Id), updateDef);
        }

    }
}
*/