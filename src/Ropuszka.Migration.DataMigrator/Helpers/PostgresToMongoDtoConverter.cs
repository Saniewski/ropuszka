using Ropuszka.Migration.Core.Models.Mongo.Client;
using Ropuszka.Migration.Core.Models.Mongo.Discount;
using Ropuszka.Migration.Core.Services;
using mongo = Ropuszka.Migration.Core.Models.Mongo;
using pg = Ropuszka.Migration.Core.Models.Postgres;

namespace Ropuszka.Migration.DataMigrator.Helpers;

public class PostgresToMongoDtoConverter
{
    private readonly PostgresService _postgresService;
    
    public PostgresToMongoDtoConverter(PostgresService postgresService)
    {
        _postgresService = postgresService;
    }
    
    public mongo.Client.ClientDto ConvertPgClientToMongoClient(pg.ClientDto pgClient)
    {
        // get purchases
        var mongoPurchases = new List<mongo.Client.Purchase>();
        var pgPurchases = _postgresService.GetAllPurchasesByClientId(pgClient.Id);
        foreach (var pgPurchase in pgPurchases)
        {
            // get shop
            var pgShop = _postgresService.GetShop(pgPurchase.IdShop);
            var mongoShop = new mongo.Client.Shop
            {
                IdShop = pgShop.Id,
                Address = pgShop.Address,
                PhoneNumber = pgShop.PhoneNumber,
                EmailAddress = pgShop.EmailAddress
            };
            // get purchased products
            var mongoPurchasedProducts = new List<mongo.Client.PurchasedProduct>();
            var pgProductPurchases = _postgresService.GetAllProductPurchasesByPurchaseId(pgPurchase.Id);
            foreach (var pgProductPurchase in pgProductPurchases)
            {
                var pgProduct = _postgresService.GetProduct(pgProductPurchase.IdProduct);
                // get discount
                mongo.Client.Discount mongoDiscount = null;
                var pgProductDiscounts = _postgresService.GetAllProductDiscountsByProductId(pgProduct.Id);
                foreach (var pgProductDiscount in pgProductDiscounts)
                {
                    var pgDiscount = _postgresService.GetDiscount(pgProductDiscount.IdDiscount);
                    if (pgPurchase?.Date > pgDiscount?.DateFrom && pgPurchase?.Date < pgDiscount?.DateTo)
                        mongoDiscount = new Discount
                        {
                            IdDiscount = pgDiscount.Id,
                            Name = pgDiscount.Name,
                            Percentage = pgDiscount.Percentage,
                            DateFrom = pgDiscount.DateFrom,
                            DateTo = pgDiscount.DateTo
                        };
                }
                mongoPurchasedProducts.Add(new PurchasedProduct
                {
                    IdProduct = pgProduct.Id,
                    Name = pgProduct.Name,
                    Price = pgProduct.Price,
                    ProducerName = pgProduct.ProducerName,
                    Quantity = pgProductPurchase.Quantity,
                    Discount = mongoDiscount
                });
            }
            
            mongoPurchases.Add(new mongo.Client.Purchase
            {
                IdPurchase = pgPurchase.Id,
                Date = pgPurchase.Date,
                Shop = mongoShop,
                PurchasedProducts = mongoPurchasedProducts
            });
        }
        // combine final object
        var mongoClient = new mongo.Client.ClientDto
        {
            Id = pgClient.Id,
            Name = pgClient.Name,
            DateOfBirth = pgClient.DateOfBirth,
            EmailAddress = pgClient.EmailAddress,
            Purchases = mongoPurchases
        };
        return mongoClient;
    }
    
    public mongo.Discount.DiscountDto ConvertPgDiscountToMongoDiscount(pg.DiscountDto pgDiscount)
    {
        // get discounted products
        var mongoDiscountedProducts = new List<DiscountedProduct>();
        var pgProductDiscounts = _postgresService.GetAllProductDiscountsByDiscountId(pgDiscount.Id);
        foreach (var pgProductDiscount in pgProductDiscounts)
        {
            var pgProduct = _postgresService.GetProduct(pgProductDiscount.IdProduct);
            mongoDiscountedProducts.Add(new DiscountedProduct
            {
                IdDiscountedProduct = pgProduct.Id,
                Name = pgProduct.Name,
                Price = pgProduct.Price,
                ProducerName = pgProduct.ProducerName
            });
        }
        
        // combine final object
        var mongoDiscount = new mongo.Discount.DiscountDto
        {
            Id = pgDiscount.Id,
            Name = pgDiscount.Name,
            Percentage = pgDiscount.Percentage,
            DateFrom = pgDiscount.DateFrom,
            DateTo = pgDiscount.DateTo,
            DiscountedProducts = mongoDiscountedProducts
        };
        return mongoDiscount;
    }

    public mongo.Product.ProductDto ConvertPgProductToMongoProduct(pg.ProductDto pgProduct)
    {
        // get discounts
        var mongoDiscounts = new List<mongo.Product.Discount>();
        var pgProductDiscounts = _postgresService.GetAllProductDiscountsByProductId(pgProduct.Id);
        foreach (var pgProductDiscount in pgProductDiscounts)
        {
            var pgDiscount = _postgresService.GetDiscount(pgProductDiscount.IdDiscount);
            mongoDiscounts.Add(new mongo.Product.Discount
            {
                IdDiscount = pgDiscount.Id,
                Name = pgDiscount.Name,
                Percentage = pgDiscount.Percentage,
                DateFrom = pgDiscount.DateFrom,
                DateTo = pgDiscount.DateTo
            });
        }
        
        // combine final object
        var mongoProduct = new mongo.Product.ProductDto
        {
            Id = pgProduct.Id,
            Name = pgProduct.Name,
            Price = pgProduct.Price,
            ProducerName = pgProduct.ProducerName,
            Discounts = mongoDiscounts
        };
        return mongoProduct;
    }

    public mongo.Shop.ShopDto ConvertPgShopToMongoShop(pg.ShopDto pgShop)
    {
        // get purchases
        var mongoPurchases = new List<mongo.Shop.Purchase>();
        var pgPurchases = _postgresService.GetAllPurchasesByShopId(pgShop.Id);
        foreach (var pgPurchase in pgPurchases)
        {
            // get client
            var pgClient = _postgresService.GetClient(pgPurchase.IdClient);
            var mongoClient = new mongo.Shop.Client
            {
                IdClient = pgClient.Id,
                Name = pgClient.Name,
                DateOfBirth = pgClient.DateOfBirth,
                EmailAddress = pgClient.EmailAddress
            };
            
            // get purchased products
            var mongoPurchasedProducts = new List<mongo.Shop.PurchasedProduct>();
            var pgProductPurchases = _postgresService.GetAllProductPurchasesByPurchaseId(pgPurchase.Id);
            foreach (var pgProductPurchase in pgProductPurchases)
            {
                var pgProduct = _postgresService.GetProduct(pgProductPurchase.IdProduct);
                // get discount
                mongo.Shop.Discount mongoDiscount = null;
                var pgProductDiscounts = _postgresService.GetAllProductDiscountsByProductId(pgProduct.Id);
                foreach (var pgProductDiscount in pgProductDiscounts)
                {
                    var pgDiscount = _postgresService.GetDiscount(pgProductDiscount.IdDiscount);
                    if (pgPurchase?.Date > pgDiscount?.DateFrom && pgPurchase?.Date < pgDiscount?.DateTo)
                        mongoDiscount = new mongo.Shop.Discount
                        {
                            IdDiscount = pgDiscount.Id,
                            Name = pgDiscount.Name,
                            Percentage = pgDiscount.Percentage,
                            DateFrom = pgDiscount.DateFrom,
                            DateTo = pgDiscount.DateTo
                        };
                }
                
                mongoPurchasedProducts.Add(new mongo.Shop.PurchasedProduct
                {
                    IdPurchasedProduct = pgProduct.Id,
                    Name = pgProduct.Name,
                    Price = pgProduct.Price,
                    ProducerName = pgProduct.ProducerName,
                    Quantity = pgProductPurchase.Quantity,
                    Discount = mongoDiscount
                });
            }

            mongoPurchases.Add(new mongo.Shop.Purchase
            {
                IdPurchase = pgPurchase.Id,
                Date = pgPurchase.Date,
                Client = mongoClient,
                PurchasedProducts = mongoPurchasedProducts
            });
        }
        
        // combine final object
        var mongoShop = new mongo.Shop.ShopDto
        {
            Id = pgShop.Id,
            Address = pgShop.Address,
            PhoneNumber = pgShop.PhoneNumber,
            EmailAddress = pgShop.EmailAddress,
            Purchases = mongoPurchases
        };
        return mongoShop;
    }
}