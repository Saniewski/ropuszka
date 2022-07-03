namespace Ropuszka.Migration.Core.Models.Mongo.Shop;

public class Client
{
    public int IdClient { get; set; }
    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? EmailAddress { get; set; }
    
    public override string ToString()
    {
        return $@"
{{
    IdClient: {this.IdClient},
    Name: {this.Name},
    DateOfBirth: {this.DateOfBirth},
    EmailAddress: {this.EmailAddress}
}}
";
    }
}
