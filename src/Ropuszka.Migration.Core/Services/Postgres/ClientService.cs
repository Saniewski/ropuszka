using Dapper;
using Ropuszka.Migration.Core.DataAccess;
using Ropuszka.Migration.Core.Models.Postgres;

namespace Ropuszka.Migration.Core.Services.Postgres;

public class ClientService : IPostgresService<ClientDto>
{
    public int GetNextId()
    {
        const string query = "SELECT MAX(id) FROM ropuszka.client;";
        var result = PostgresDb.Query(query).First().max;
        return result != null ? (int)result + 1 : 1;
    }

    public void Add(ClientDto client)
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

    public IEnumerable<ClientDto> GetAll()
    {
        const string query = "SELECT * FROM ropuszka.client;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (ClientDto)x);
    }

    public IEnumerable<int> GetAllIds()
    {
        const string query = "SELECT id FROM ropuszka.client;";
        var result = PostgresDb.Query(query);
        return result.Select(x => (int)(x.id));
    }

    public ClientDto? GetById(int id)
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
}