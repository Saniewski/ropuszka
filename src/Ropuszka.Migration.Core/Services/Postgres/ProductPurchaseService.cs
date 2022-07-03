using Dapper;
using Ropuszka.Migration.Core.DataAccess;
using Ropuszka.Migration.Core.Models.Postgres;

namespace Ropuszka.Migration.Core.Services.Postgres;

public class ProductPurchaseService : IPostgresService<ProductPurchaseDto>
{
    public int GetNextId()
    {
        const string query = "SELECT MAX(id) FROM ropuszka.product_purchase;";
        var result = PostgresDb.Query(query).First().max;
        return result != null ? (int)result + 1 : 1;
    }

    public void Add(ProductPurchaseDto productPurchase)
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

    public IEnumerable<ProductPurchaseDto> GetAll()
    {
        const string query = "SELECT * FROM ropuszka.product_purchase;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (ProductPurchaseDto)x);
    }
    
    public IEnumerable<ProductPurchaseDto> GetAllByPurchaseId(int idPurchase)
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

    // TODO: implement this
    public IEnumerable<int> GetAllIds()
    {
        throw new NotImplementedException();
    }

    // TODO: test and fix
    public ProductPurchaseDto? GetById(int id)
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
}