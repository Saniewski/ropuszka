using Ropuszka.Migration.Core.Models.Postgres;
using Ropuszka.Migration.Core.Services.Mongo;
using Ropuszka.Migration.Core.Services.Postgres;
using Ropuszka.Migration.DataMigrator.Helpers;

MigrateData();

static void MigrateData()
{
    // Setup
    var clientService = new ClientService();
    var discountService = new DiscountService();
    var productDiscountService = new ProductDiscountService();
    var productPurchaseService = new ProductPurchaseService();
    var productService = new ProductService();
    var purchaseService = new PurchaseService();
    var shopService = new ShopService();
    var mongoService = new MongoService();
    var dtoConverter = new PostgresToMongoDtoConverter(
        clientService,
        discountService,
        productDiscountService,
        productPurchaseService,
        productService,
        purchaseService,
        shopService
        );
    
    // Migrate clients
    Console.WriteLine("Migrating clients...");
    var allClientIds = clientService.GetAllIds().ToList();
    var numberOfClients = allClientIds.Count;
    var i = 1;
    foreach (var clientId in allClientIds)
    {
        ClientDto? pgClient = null;
        try
        {
            pgClient = clientService.GetById(clientId);
            if (pgClient == null)
            {
                Console.Error.WriteLine($"Client {clientId} not found in Postgres database");
                i++;
                continue;
            }
            var mongoClient = dtoConverter.ConvertPgClientToMongoClient(pgClient);
            mongoService.AddClient(mongoClient);
            Console.Write($"\rProgress: {i++} / {numberOfClients} clients migrated.");
        }
        catch (Exception ex)
        {
            Console.Write("\r\n");
            Console.Error.WriteLine($"Error while migrating client {clientId}:\n{pgClient}\nError message: {ex.Message}");
        }
    }
    Console.WriteLine($"\nClients migrated.");

    // Migrate discounts
    Console.WriteLine("Migrating discounts...");
    var allDiscountIds = discountService.GetAllIds().ToList();
    var numberOfDiscounts = allDiscountIds.Count;
    i = 1;
    foreach (var discountId in allDiscountIds)
    {
        DiscountDto? pgDiscount = null;
        try
        {
            pgDiscount = discountService.GetById(discountId);
            if (pgDiscount == null)
            {
                Console.Error.WriteLine($"Discount {discountId} not found in Postgres database");
                i++;
                continue;
            }
            var mongoDiscount = dtoConverter.ConvertPgDiscountToMongoDiscount(pgDiscount);
            mongoService.AddDiscount(mongoDiscount);
            Console.Write($"\rProgress: {i++} / {numberOfDiscounts} discounts migrated.");
        }
        catch (Exception ex)
        {
            Console.Write("\r\n");
            Console.Error.WriteLine($"Error while migrating discount {discountId}:\n{pgDiscount}\nError message: {ex.Message}");
        }
    }
    Console.WriteLine($"\nDiscounts migrated.");

    // Migrate products
    Console.WriteLine("Migrating products...");
    var allProductIds = productService.GetAllIds().ToList();
    var numberOfProducts = allProductIds.Count;
    i = 1;
    foreach (var productId in allProductIds)
    {
        ProductDto? pgProduct = null;
        try
        {
            pgProduct = productService.GetById(productId);
            if (pgProduct == null)
            {
                Console.Error.WriteLine($"Product {productId} not found in Postgres database");
                i++;
                continue;
            }
            var mongoProduct = dtoConverter.ConvertPgProductToMongoProduct(pgProduct);
            mongoService.AddProduct(mongoProduct);
            Console.Write($"\rProgress: {i++} / {numberOfProducts} products migrated.");
        }
        catch (Exception ex)
        {
            Console.Write("\r\n");
            Console.Error.WriteLine($"Error while migrating product {productId}:\n{pgProduct}\nError message: {ex.Message}");
        }
    }
    Console.WriteLine($"\nProducts migrated.");

    // Migrate shops
    Console.WriteLine("Migrating shops...");
    var allShopIds = shopService.GetAllIds().ToList();
    var numberOfShops = allShopIds.Count;
    i = 1;
    foreach (var shopId in allShopIds)
    {
        ShopDto? pgShop = null;
        try
        {
            pgShop = shopService.GetById(shopId);
            if (pgShop == null)
            {
                Console.Error.WriteLine($"Shop {shopId} not found in Postgres database");
                i++;
                continue;
            }
            var mongoShop = dtoConverter.ConvertPgShopToMongoShop(pgShop);
            mongoService.AddShop(mongoShop);
            Console.Write($"\rProgress: {i++} / {numberOfShops} shops migrated.");
        }
        catch (Exception ex)
        {
            Console.Write("\r\n");
            Console.Error.WriteLine($"Error while migrating shop {shopId}:\n{pgShop}\nError message: {ex.Message}");
        }
    }
    Console.WriteLine($"\nShops migrated.");
}
