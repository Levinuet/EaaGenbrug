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
            var dbName = "Shopping";
            var collectionName = "items";

            collection = client.GetDatabase(dbName)
               .GetCollection<Ad>(collectionName);

        }

        public void AddItem(Ad item)
        {
            var max = 0;
            if (collection.Count(Builders<Ad>.Filter.Empty) > 0)
            {
                max = collection.Find(Builders<Ad>.Filter.Empty).SortByDescending(r => r.Id).Limit(1).ToList()[0].Id;
            }
            item.Id = max + 1;
            collection.InsertOne(item);

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

        /*public ShoppingItem[] GetAllByShop(string shop)
        {
            var filter = Builders<ShoppingItem>.Filter.Where(r => r.Shop.Equals(shop));
            return collection.Find(filter).ToList().ToArray();

        }*/

        public void UpdateItem(Ad item)
        {
            var updateDef = Builders<Ad>.Update
                .Set(x => x.Description, item.Description)
                .Set(x => x.ImageUrl, item.ImageUrl)
                .Set(x => x.Category, item.Category)
                .Set(x => x.Status, item.Status)
                .Set(x => x.Location, item.Location);
            collection.UpdateOne(x => x.Id == item.Id, updateDef);
        }
    }
}

