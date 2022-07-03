using MongoDB.Driver;

namespace Ropuszka.Migration.Core.DataAccess;

public static class MongoDb
{
    private const string ConnectionString = "mongodb://root:root@localhost:27017/?authSource=admin&readPreference=primary&ssl=false";

    public static void Put(string collectionName, dynamic document)
    {
        var client = new MongoClient(ConnectionString);
        var db = client.GetDatabase("ropuszka");
        var collection = db.GetCollection<dynamic>(collectionName);
        collection.InsertOne(document);
    }
}
