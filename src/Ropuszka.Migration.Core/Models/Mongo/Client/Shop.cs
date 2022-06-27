namespace Ropuszka.Migration.Core.Models.Mongo.Client;

public class Shop
{
    public int IdShop { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
    
    public override string ToString()
    {
        return $@"
{{
    IdShop: {this.IdShop},
    Address: {this.Address},
    PhoneNumber: {this.PhoneNumber},
    EmailAddress: {this.EmailAddress}
}}
";
    }
}
