namespace Ropuszka.Migration.Core.Models.Mongo.Shop;

public class ShopDto : IModel
{
    public int Id { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
    public IEnumerable<Purchase>? Purchases { get; set; }

    // TODO: pretty print the IEnumerable
    public override string ToString()
    {
        return $@"
{{
    Id: {this.Id},
    Address: {this.Address},
    PhoneNumber: {this.PhoneNumber},
    EmailAddress: {this.EmailAddress},
    Purchases: {this.Purchases}
}}
";
    }
}
