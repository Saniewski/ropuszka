namespace Ropuszka.Migration.Core.Models.Mongo.Shop;

public class Purchase
{
    public int IdPurchase { get; set; }
    public DateTime Date { get; set; }
    public Client? Client { get; set; }
    public IEnumerable<PurchasedProduct>? PurchasedProducts { get; set; }
    
    // TODO: pretty print the IEnumerable
    public override string ToString()
    {
        return $@"
{{
    IdPurchase: {this.IdPurchase},
    Date: {this.Date},
    Client: {this.Client},
    PurchasedProducts: {this.PurchasedProducts}
}}
";
    }
}
