using Dapper;
using Ropuszka.Migration.Core.DataAccess;
using Ropuszka.Migration.Core.Models.Postgres;

namespace Ropuszka.Migration.Core.Services.Postgres;

public class PurchaseService : IPostgresService<PurchaseDto>
{
    public int GetNextId()
    {
        const string query = "SELECT MAX(id) FROM ropuszka.purchase;";
        var result = PostgresDb.Query(query).First().max;
        return result != null ? (int)result + 1 : 1;
    }

    public void Add(PurchaseDto purchase)
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
    public IEnumerable<PurchaseDto> GetAll()
    {
        const string query = "SELECT * FROM ropuszka.purchase;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (PurchaseDto)x);
    }
    
    public IEnumerable<PurchaseDto> GetAllByClientId(int idClient)
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
    
    public IEnumerable<PurchaseDto> GetAllByShopId(int idShop)
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

    public IEnumerable<int> GetAllIds()
    {
        const string query = "SELECT id FROM ropuszka.purchase;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (int)(x.id));
    }

    public PurchaseDto? GetById(int id)
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
}