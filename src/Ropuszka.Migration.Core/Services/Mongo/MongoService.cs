using Ropuszka.Migration.Core.DataAccess;
using Ropuszka.Migration.Core.Models.Mongo.Client;
using Ropuszka.Migration.Core.Models.Mongo.Discount;
using Ropuszka.Migration.Core.Models.Mongo.Product;
using Ropuszka.Migration.Core.Models.Mongo.Shop;

namespace Ropuszka.Migration.Core.Services.Mongo;

public class MongoService
{
    public void AddClient(ClientDto client)
    {
        MongoDb.Put("clients", client);
    }
    
    public void AddDiscount(DiscountDto discount)
    {
        MongoDb.Put("discounts", discount);
    }
    
    public void AddProduct(ProductDto product)
    {
        MongoDb.Put("products", product);
    }
    
    public void AddShop(ShopDto shop)
    {
        MongoDb.Put("shops", shop);
    }
}
