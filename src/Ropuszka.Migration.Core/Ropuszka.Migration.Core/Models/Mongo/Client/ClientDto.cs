namespace Ropuszka.Migration.Core.Models.Mongo.Client;

public class ClientDto : IModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? EmailAddress { get; set; }
    public IEnumerable<Purchase>? Purchases { get; set; }

    // TODO: pretty print the IEnumerable
    public override string ToString()
    {
        return $@"
{{
    Id: {this.Id},
    Name: {this.Name},
    DateOfBirth: {this.DateOfBirth},
    EmailAddress: {this.EmailAddress},
    Purchases: {this.Purchases}
}}
";
    }
}
