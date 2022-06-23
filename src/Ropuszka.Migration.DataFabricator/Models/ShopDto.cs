namespace Ropuszka.Migration.DataFabricator.Models;

public class ShopDto : IModel
{
    public int Id { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    
    public override string ToString()
    {
        return $@"
{{
    Id: {this.Id},
    Address: {this.Address},
    PhoneNumber: {this.PhoneNumber},
    EmailAddress: {this.EmailAddress}
}}
";
    }
}
