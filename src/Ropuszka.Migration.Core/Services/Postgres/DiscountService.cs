using Dapper;
using Ropuszka.Migration.Core.DataAccess;
using Ropuszka.Migration.Core.Models.Postgres;

namespace Ropuszka.Migration.Core.Services.Postgres;

public class DiscountService : IPostgresService<DiscountDto>
{
    public int GetNextId()
    {
        const string query = "SELECT MAX(id) FROM ropuszka.discount;";
        var result = PostgresDb.Query(query).First().max;
        return result != null ? (int)result + 1 : 1;
    }

    public void Add(DiscountDto discount)
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

    public IEnumerable<DiscountDto> GetAll()
    {
        const string query = "SELECT * FROM ropuszka.discount;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (DiscountDto)x);
    }

    public IEnumerable<int> GetAllIds()
    {
        const string query = "SELECT id FROM ropuszka.discount;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (int)x.id);
    }

    public DiscountDto? GetById(int id)
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
}