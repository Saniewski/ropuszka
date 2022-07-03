using Dapper;
using Ropuszka.Migration.Core.DataAccess;
using Ropuszka.Migration.Core.Models.Postgres;

namespace Ropuszka.Migration.Core.Services.Postgres;

public class ShopService : IPostgresService<ShopDto>
{
    public int GetNextId()
    {
        const string query = "SELECT MAX(id) FROM ropuszka.shop;";
        var result = PostgresDb.Query(query).First().max;
        return result != null ? (int)result + 1 : 1;
    }

    public void Add(ShopDto shop)
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

    public IEnumerable<ShopDto> GetAll()
    {
        const string query = "SELECT * FROM ropuszka.shop;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (ShopDto)x);
    }

    public IEnumerable<int> GetAllIds()
    {
        const string query = "SELECT id FROM ropuszka.shop;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (int)x.id);
    }

    public ShopDto? GetById(int id)
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