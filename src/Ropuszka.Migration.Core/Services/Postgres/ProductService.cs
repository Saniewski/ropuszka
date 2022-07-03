using Dapper;
using Ropuszka.Migration.Core.DataAccess;
using Ropuszka.Migration.Core.Models.Postgres;

namespace Ropuszka.Migration.Core.Services.Postgres;

public class ProductService : IPostgresService<ProductDto>
{
    public int GetNextId()
    {
        const string query = "SELECT MAX(id) FROM ropuszka.product;";
        var result = PostgresDb.Query(query).First().max;
        return result != null ? (int)result + 1 : 1;
    }

    public void Add(ProductDto product)
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

    public IEnumerable<ProductDto> GetAll()
    {
        const string query = "SELECT * FROM ropuszka.product;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (ProductDto)x);
    }

    public IEnumerable<int> GetAllIds()
    {
        const string query = "SELECT id FROM ropuszka.product;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (int)x.id);
    }

    public ProductDto? GetById(int id)
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
}