namespace Ropuszka.Migration.Core.Models.Mongo.Client;

public class Purchase
{
    public int IdPurchase { get; set; }
    public DateTime Date { get; set; }
    public Shop? Shop { get; set; }
    public IEnumerable<PurchasedProduct>? PurchasedProducts { get; set; }

    // TODO: pretty print the IEnumerable
    public override string ToString()
    {
        return $@"
{{
    IdPurchase: {this.IdPurchase},
    Date: {this.Date},
    Shop: {this.Shop},
    PurchasedProducts: {this.PurchasedProducts}
}}
";
    }
}
