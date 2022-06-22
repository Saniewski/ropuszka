using Dapper;
using Ropuszka.Migration.DataFabricator.Helpers;
using Ropuszka.Migration.DataFabricator.Models;

namespace Ropuszka.Migration.DataFabricator.Services;

public class RopuszkaService
{
    public int GetNextIdForTable(string tableName)
    {
        var query = $"SELECT MAX(id) FROM ropuszka.{tableName}";
        var result = AppDb.Query(query).First().max;
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
        var result = AppDb.Query(query, parameters);
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
        var result = AppDb.Query(query, parameters);
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
        var result = AppDb.Query(query, parameters);
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
        var result = AppDb.Query(query, parameters);
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
        var result = AppDb.Query(query, parameters);
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
        var result = AppDb.Query(query, parameters);
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
        var result = AppDb.Query(query, parameters);
    }
}