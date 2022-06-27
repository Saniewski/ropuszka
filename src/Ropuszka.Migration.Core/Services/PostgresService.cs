using Dapper;
using Ropuszka.Migration.Core.DataAccess;
using Ropuszka.Migration.Core.Models.Postgres;

namespace Ropuszka.Migration.Core.Services;

public class PostgresService
{
    public int GetNextIdForTable(string tableName)
    {
        var query = $"SELECT MAX(id) FROM ropuszka.{tableName}";
        var result = PostgresDb.Query(query).First().max;
        return result != null ? (int)result + 1 : 1;
    }

    public void AddClient(ClientDto client)
    {
        const string query = @"
INSERT INTO ropuszka.client (
    id,
    name,
    date_of_birth,
    email_address
) VALUES (
    @id,
    @name,
    @date_of_birth,
    @email_address
);
";
        var parameters = new DynamicParameters(new
        {
            id = client.Id,
            name = client.Name,
            date_of_birth = client.DateOfBirth,
            email_address = client.EmailAddress
        });
        var result = PostgresDb.Query(query, parameters);
    }

    // TODO: test and fix
    public IEnumerable<ClientDto> GetAllClients()
    {
        const string query = "SELECT * FROM ropuszka.client;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (ClientDto)x);
    }
    
    public IEnumerable<int> GetAllClientIds()
    {
        const string query = "SELECT id FROM ropuszka.client;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (int)(x.id));
    }

    public ClientDto? GetClient(int id)
    {
        const string query = @"
SELECT * FROM ropuszka.client
WHERE id = @id;
";
        var parameters = new DynamicParameters(new
        {
            id = id
        });
        var result = PostgresDb.Query(query, parameters);
        return result.Select(x => new ClientDto
        {
            Id = (int)x.id,
            Name = (string)x.name,
            DateOfBirth = (DateTime)x.date_of_birth,
            EmailAddress = (string)x.email_address
        }).FirstOrDefault();
    }
    
    public void AddDiscount(DiscountDto discount)
    {
        const string query = @"
INSERT INTO ropuszka.discount (
    id,
    name,
    percentage,
    date_from,
    date_to
) VALUES (
    @id,
    @name,
    @percentage,
    @date_from,
    @date_to
);
";
        var parameters = new DynamicParameters(new
        {
            id = discount.Id,
            name = discount.Name,
            percentage = discount.Percentage,
            date_from = discount.DateFrom,
            date_to = discount.DateTo
        });
        var result = PostgresDb.Query(query, parameters);
    }
    
    // TODO: test and fix
    public IEnumerable<DiscountDto> GetAllDiscounts()
    {
        const string query = "SELECT * FROM ropuszka.discount;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (DiscountDto)x);
    }
    
    public IEnumerable<int> GetAllDiscountIds()
    {
        const string query = "SELECT id FROM ropuszka.discount;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (int)x.id);
    }
    
    public DiscountDto? GetDiscount(int id)
    {
        const string query = @"
SELECT * FROM ropuszka.discount
WHERE id = @id;
";
        var parameters = new DynamicParameters(new
        {
            id = id
        });
        var result = PostgresDb.Query(query, parameters);
        return result.Select(x => new DiscountDto
        {
            Id = (int)x.id,
            Name = (string)x.name,
            Percentage = (double)x.percentage,
            DateFrom = (DateTime)x.date_from,
            DateTo = (DateTime)x.date_to
        }).FirstOrDefault();
    }
    
    public void AddProduct(ProductDto product)
    {
        const string query = @"
INSERT INTO ropuszka.product (
    id,
    name,
    price,
    producer_name
) VALUES (
    @id,
    @name,
    @price,
    @producer_name
);
";
        var parameters = new DynamicParameters(new
        {
            id = product.Id,
            name = product.Name,
            price = product.Price,
            producer_name = product.ProducerName
        });
        var result = PostgresDb.Query(query, parameters);
    }
    
    // TODO: test and fix
    public IEnumerable<ProductDto> GetAllProducts()
    {
        const string query = "SELECT * FROM ropuszka.product;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (ProductDto)x);
    }
    
    public IEnumerable<int> GetAllProductIds()
    {
        const string query = "SELECT id FROM ropuszka.product;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (int)x.id);
    }
    
    public ProductDto? GetProduct(int id)
    {
        const string query = @"
SELECT * FROM ropuszka.product
WHERE id = @id;
";
        var parameters = new DynamicParameters(new
        {
            id = id
        });
        var result = PostgresDb.Query(query, parameters);
        return result.Select(x => new ProductDto
        {
            Id = (int)x.id,
            Name = (string)x.name,
            Price = (double)x.price,
            ProducerName = (string)x.producer_name
        }).FirstOrDefault();
    }
    
    public void AddProductDiscount(ProductDiscountDto productDiscount)
    {
        const string query = @"
INSERT INTO ropuszka.product_discount (
    id,
    id_product,
    id_discount
) VALUES (
    @id,
    @id_product,
    @id_discount
);
";
        var parameters = new DynamicParameters(new
        {
            id = productDiscount.Id,
            id_product = productDiscount.IdProduct,
            id_discount = productDiscount.IdDiscount
        });
        var result = PostgresDb.Query(query, parameters);
    }
    
    // TODO: test and fix
    public IEnumerable<ProductDiscountDto> GetAllProductDiscounts()
    {
        const string query = "SELECT * FROM ropuszka.product_discount;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (ProductDiscountDto)x);
    }
    
    public IEnumerable<ProductDiscountDto> GetAllProductDiscountsByDiscountId(int idDiscount)
    {
        const string query = "SELECT * FROM ropuszka.product_discount WHERE id_discount = @id_discount;";
        var parameters = new DynamicParameters(new
        {
            id_discount = idDiscount
        });
        var result = PostgresDb.Query(query, parameters);
        return result.Select(x => new ProductDiscountDto
        {
            Id = (int)x.id,
            IdProduct = (int)x.id_product,
            IdDiscount = (int)x.id_discount
        });
    }
    
    public IEnumerable<ProductDiscountDto> GetAllProductDiscountsByProductId(int idProduct)
    {
        const string query = "SELECT * FROM ropuszka.product_discount WHERE id_product = @id_product;";
        var parameters = new DynamicParameters(new
        {
            id_product = idProduct
        });
        var result = PostgresDb.Query(query, parameters);
        return result.Select(x => new ProductDiscountDto
        {
            Id = (int)x.id,
            IdProduct = (int)x.id_product,
            IdDiscount = (int)x.id_discount
        });
    }

    // TODO: test and fix
    public ProductDiscountDto? GetProductDiscount(int id)
    {
        const string query = @"
SELECT * FROM ropuszka.product_discount
WHERE id = @id;
";
        var parameters = new DynamicParameters(new
        {
            id = id
        });
        var result = PostgresDb.Query(query, parameters).FirstOrDefault();
        return result is null ? null : new ProductDiscountDto
        {
            Id = (int)result.id,
            IdProduct = (int)result.id_product,
            IdDiscount = (int)result.id_discount
        };
    }
    
    public void AddProductPurchase(ProductPurchaseDto productPurchase)
    {
        const string query = @"
INSERT INTO ropuszka.product_purchase (
    id,
    id_product,
    id_purchase,
    quantity
) VALUES (
    @id,
    @id_product,
    @id_purchase,
    @quantity
);
";
        var parameters = new DynamicParameters(new
        {
            id = productPurchase.Id,
            id_product = productPurchase.IdProduct,
            id_purchase = productPurchase.IdPurchase,
            quantity = productPurchase.Quantity
        });
        var result = PostgresDb.Query(query, parameters);
    }
    
    // TODO: test and fix
    public IEnumerable<ProductPurchaseDto> GetAllProductPurchases()
    {
        const string query = "SELECT * FROM ropuszka.product_purchase;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (ProductPurchaseDto)x);
    }
    
    public IEnumerable<ProductPurchaseDto> GetAllProductPurchasesByPurchaseId(int idPurchase)
    {
        const string query = "SELECT * FROM ropuszka.product_purchase WHERE id_purchase = @id_purchase;";
        var parameters = new DynamicParameters(new
        {
            id_purchase = idPurchase
        });
        var result = PostgresDb.Query(query, parameters);
        return result.Select(x => new ProductPurchaseDto
        {
            Id = (int)x.id,
            IdProduct = (int)x.id_product,
            IdPurchase = (int)x.id_purchase,
            Quantity = (int)x.quantity
        });
    }
    
    // TODO: test and fix
    public ProductPurchaseDto? GetProductPurchase(int id)
    {
        const string query = @"
SELECT * FROM ropuszka.product_purchase
WHERE id = @id;
";
        var parameters = new DynamicParameters(new
        {
            id = id
        });
        var result = PostgresDb.Query(query, parameters);
        return result.Select(x => new ProductPurchaseDto
        {
            Id = (int)x.id,
            IdProduct = (int)x.id_product,
            IdPurchase = (int)x.id_purchase,
            Quantity = (int)x.quantity
        }).FirstOrDefault();
    }
    
    public void AddPurchase(PurchaseDto purchase)
    {
        const string query = @"
INSERT INTO ropuszka.purchase (
    id,
    date,
    id_shop,
    id_client
) VALUES (
    @id,
    @date,
    @id_shop,
    @id_client
);
";
        var parameters = new DynamicParameters(new
        {
            id = purchase.Id,
            date = purchase.Date,
            id_shop = purchase.IdShop,
            id_client = purchase.IdClient
        });
        var result = PostgresDb.Query(query, parameters);
    }
    
    // TODO: test and fix
    public IEnumerable<PurchaseDto> GetAllPurchases()
    {
        const string query = "SELECT * FROM ropuszka.purchase;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (PurchaseDto)x);
    }
    
    public IEnumerable<PurchaseDto> GetAllPurchasesByClientId(int idClient)
    {
        const string query = "SELECT * FROM ropuszka.purchase WHERE id_client = @id_client;";
        var parameters = new DynamicParameters(new
        {
            id_client = idClient
        });
        var result = PostgresDb.Query(query, parameters);
        return result.Select(x => new PurchaseDto
        {
            Id = (int)x.id,
            Date = (DateTime)x.date,
            IdShop = (int)x.id_shop,
            IdClient = (int)x.id_client
        });
    }
    
    public IEnumerable<PurchaseDto> GetAllPurchasesByShopId(int idShop)
    {
        const string query = "SELECT * FROM ropuszka.purchase WHERE id_shop = @id_shop;";
        var parameters = new DynamicParameters(new
        {
            
        });
        var result = PostgresDb.Query(query, parameters);
        return result.Select(x => new PurchaseDto
        {
            Id = (int)x.id,
            Date = (DateTime)x.date,
            IdShop = (int)x.id_shop,
            IdClient = (int)x.id_client
        });
    }
    
    // TODO: test and fix
    public PurchaseDto? GetPurchase(int id)
    {
        const string query = @"
SELECT * FROM ropuszka.purchase
WHERE id = @id;
";
        var parameters = new DynamicParameters(new
        {
            id = id
        });
        var result = PostgresDb.Query(query, parameters);
        return result.Select(x => new PurchaseDto
        {
            Id = (int)x.id,
            Date = (DateTime)x.date,
            IdShop = (int)x.id_shop,
            IdClient = (int)x.id_client
        }).FirstOrDefault();
    }
    
    public void AddShop(ShopDto shop)
    {
        const string query = @"
INSERT INTO ropuszka.shop (
    id,
    address,
    phone_number,
    email_address
) VALUES (
    @id,
    @address,
    @phone_number,
    @email_address
);
";
        var parameters = new DynamicParameters(new
        {
            id = shop.Id,
            address = shop.Address,
            phone_number = shop.PhoneNumber,
            email_address = shop.EmailAddress
        });
        var result = PostgresDb.Query(query, parameters);
    }
    
    // TODO: test and fix
    public IEnumerable<ShopDto> GetAllShops()
    {
        const string query = "SELECT * FROM ropuszka.shop;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (ShopDto)x);
    }
    
    public IEnumerable<int> GetAllShopIds()
    {
        const string query = "SELECT id FROM ropuszka.shop;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (int)x.id);
    }
    
    public ShopDto? GetShop(int id)
    {
        const string query = @"
SELECT * FROM ropuszka.shop
WHERE id = @id;
";
        var parameters = new DynamicParameters(new
        {
            id = id
        });
        var result = PostgresDb.Query(query, parameters);
        return result.Select(x => new ShopDto
        {
            Id = (int)x.id,
            Address = (string)x.address,
            PhoneNumber = (string)x.phone_number,
            EmailAddress = (string)x.email_address
        }).FirstOrDefault();
    }
}
