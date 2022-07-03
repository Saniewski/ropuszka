using Dapper;
using Ropuszka.Migration.Core.DataAccess;
using Ropuszka.Migration.Core.Models.Postgres;

namespace Ropuszka.Migration.Core.Services.Postgres;

public class ProductDiscountService : IPostgresService<ProductDiscountDto>
{
    public int GetNextId()
    {
        const string query = "SELECT MAX(id) FROM ropuszka.product_discount;";
        var result = PostgresDb.Query(query).First().max;
        return result != null ? (int)result + 1 : 1;
    }

    public void Add(ProductDiscountDto productDiscount)
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

    public IEnumerable<ProductDiscountDto> GetAll()
    {
        const string query = "SELECT * FROM ropuszka.product_discount;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (ProductDiscountDto)x);
    }
    
    public IEnumerable<ProductDiscountDto> GetAllByDiscountId(int idDiscount)
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
    
    public IEnumerable<ProductDiscountDto> GetAllByProductId(int idProduct)
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

    // TODO: implement this
    public IEnumerable<int> GetAllIds()
    {
        throw new NotImplementedException();
    }

    // TODO: test this
    public ProductDiscountDto? GetById(int id)
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
}