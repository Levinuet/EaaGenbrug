using System;
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

            // Provide the name of the database and collection you want to use.
            // If they don't already exist, the driver and Atlas will create them
            // automatically when you first write data.
            var dbName = "Eaagenbrug";
            var collectionName = "Ads";

            collection = client.GetDatabase(dbName)
               .GetCollection<Ad>(collectionName);

        }


        public void AddItem(Ad ad)
        {
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
            var deleteResult = collection
                .DeleteOne(Builders<Ad>.Filter.Where(r => r.Id == id));
        }

        public Ad[] GetAll()
        {
            return collection.Find(Builders<Ad>.Filter.Empty).ToList().ToArray();
        }

        public void PurchaseAd(Ad ad)
        {

            var updateDef = Builders<Ad>.Update
                .Set(x => x.Status, "Reserved")
                  .Set(x => x.BuyerUserName, ad.BuyerUserName);


            collection.UpdateOne(x => x.Id == ad.Id, updateDef);
        }

        public void UpdateItem(Ad ad)

        {
            var updateDef = Builders<Ad>.Update
                .Set(x => x.Description, ad.Description)
                .Set(x => x.ImageUrl, ad.ImageUrl)
                .Set(x => x.Category, ad.Category)
                .Set(x => x.Status, ad.Status)
                .Set(x => x.Location, ad.Location);
            collection.UpdateOne(x => x.Id == ad.Id, updateDef);
        }
    }
}

