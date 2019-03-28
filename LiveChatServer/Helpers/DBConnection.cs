using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveChatServer.Helpers
{
    public class DBConnection
    {

        public static async Task EstablishConnection()
        {
            string connectionString = "mongodb://172.16.0.13:27017"; 
            string DBName = "CSharpExamChatServer";

            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase(DBName);

            IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("Users");

            using (IAsyncCursor<BsonDocument> cursor = await collection.FindAsync(new BsonDocument()))
            {
                while (await cursor.MoveNextAsync())
                {
                    IEnumerable<BsonDocument> batch = cursor.Current;
                    foreach (BsonDocument document in batch)
                    {
                        Console.WriteLine(document);
                        Console.WriteLine();
                    }
                }
            }

        }
    }
}
