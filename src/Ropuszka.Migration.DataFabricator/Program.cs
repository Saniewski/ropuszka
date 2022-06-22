using Ropuszka.Migration.DataFabricator.Helpers;
using Ropuszka.Migration.DataFabricator.Models;
using Ropuszka.Migration.DataFabricator.Services;

const int numberOfShops = 1000;
const int numberOfProducts = 100000;
const int numberOfClients = 10000000;
const int numberOfDiscounts = 10000;
const int numberOfProductDiscounts = 400000;
const int numberOfPurchases = 100000000;
const int numberOfProductPurchases = 500000000;

GenerateMockedData(numberOfShops, numberOfProducts, numberOfClients, numberOfDiscounts, numberOfProductDiscounts, numberOfPurchases, numberOfProductPurchases);

static void GenerateMockedData(
    int numberOfShops,
    int numberOfProducts,
    int numberOfClients,
    int numberOfDiscounts,
    int numberOfProductDiscounts,
    int numberOfPurchases,
    int numberOfProductPurchases)
{
    // Setup
    var ropuszkaService = new RopuszkaService();
    var dataGenerator = new DataGenerator();
    
    // Generate shops
    Console.WriteLine("Generating shops...");
    for (var i = 0; i < numberOfShops; i++)
    {
        ShopDto? shop = null;
        try
        {
            shop = dataGenerator.GenerateFakeShop();
            ropuszkaService.AddShop(shop);
            Console.Write($"\rProgress: {i + 1} / {numberOfShops} shops generated.");
        } catch (Exception ex)
        {
            Console.Write("\r\n");
            Console.WriteLine($"Error while adding shop no {i}:\n{shop}\nError message: {ex.Message}");
        }
    }
    Console.WriteLine($"\nShops generated.");

    // Generate products
    Console.WriteLine("Generating products...");
    for (var i = 0; i < numberOfProducts; i++)
    {
        ProductDto? product = null;
        try
        {
            product = dataGenerator.GenerateFakeProduct();
            ropuszkaService.AddProduct(product);
            Console.Write($"\rProgress: {i + 1} / {numberOfProducts} products generated.");
        } catch (Exception ex)
        {
            Console.Write("\r\n");
            Console.WriteLine($"Error while adding product no {i}:\n{product}\nError message: {ex.Message}");
        }
    }
    Console.WriteLine($"\nProducts generated.");

    // Generate clients
    Console.WriteLine("Generating clients...");
    for (var i = 0; i < numberOfClients; i++)
    {
        ClientDto? client = null;
        try
        {
            client = dataGenerator.GenerateFakeClient();
            ropuszkaService.AddClient(client);
            Console.Write($"\rProgress: {i+1} / {numberOfClients} clients generated.");
        } catch (Exception ex)
        {
            Console.Write("\r\n");
            Console.WriteLine($"Error while adding client no {i}:\n{client}\nError message: {ex.Message}");
        }
    }
    Console.WriteLine($"\nClients generated.");
    
    // Generate discounts
    Console.WriteLine("Generating discounts...");
    for (var i = 0; i < numberOfDiscounts; i++)
    {
        DiscountDto? discount = null;
        try
        {
            discount = dataGenerator.GenerateFakeDiscount();
            ropuszkaService.AddDiscount(discount);
            Console.Write($"\rProgress: {i + 1} / {numberOfDiscounts} discounts generated.");
        } catch (Exception ex)
        {
            Console.Write("\r\n");
            Console.WriteLine($"Error while adding discount no {i}:\n{discount}\nError message: {ex.Message}");
        }
    }
    Console.WriteLine($"\nDiscounts generated.");
    
    // Generate product discounts
    Console.WriteLine("Generating product discounts...");
    for (var i = 0; i < numberOfProductDiscounts; i++)
    {
        ProductDiscountDto? productDiscount = null;
        try
        {
            productDiscount = dataGenerator.GenerateFakeProductDiscount();
            ropuszkaService.AddProductDiscount(productDiscount);
            Console.Write($"\rProgress: {i + 1} / {numberOfProductDiscounts} product discounts generated.");
        } catch (Exception ex)
        {
            Console.Write("\r\n");
            Console.WriteLine($"Error while adding product discount no {i}:\n{productDiscount}\nError message: {ex.Message}");
        }
    }
    Console.WriteLine($"\nProduct discounts generated.");
    
    // Generate purchases
    Console.WriteLine("Generating purchases...");
    for (var i = 0; i < numberOfPurchases; i++)
    {
        PurchaseDto? purchase = null;
        try
        {
            purchase = dataGenerator.GenerateFakePurchase();
            ropuszkaService.AddPurchase(purchase);
            Console.Write($"\rProgress: {i + 1} / {numberOfPurchases} purchases generated.");
        } catch (Exception ex)
        {
            Console.Write("\r\n");
            Console.WriteLine($"Error while adding purchase no {i}:\n{purchase}\nError message: {ex.Message}");
        }
    }
    Console.WriteLine($"\nPurchases generated.");
    
    // Generate product purchases
    Console.WriteLine("Generating product purchases...");
    for (var i = 0; i < numberOfProductPurchases; i++)
    {
        ProductPurchaseDto? productPurchase = null;
        try
        {
            productPurchase = dataGenerator.GenerateFakeProductPurchase();
            ropuszkaService.AddProductPurchase(productPurchase);
            Console.Write($"\rProgress: {i + 1} / {numberOfProductPurchases} product purchases generated.");
        } catch (Exception ex)
        {
            Console.Write("\r\n");
            Console.WriteLine($"Error while adding product purchase no {i}:\n{productPurchase}\nError message: {ex.Message}");
        }
    }
    Console.WriteLine($"\nProduct purchases generated.");
}
