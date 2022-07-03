namespace Ropuszka.Migration.Core.Models.Mongo.Shop;

public class PurchasedProduct
{
    public int IdPurchasedProduct { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public string? ProducerName { get; set; }
    public double Quantity { get; set; }
    public Discount? Discount { get; set; }
    
    public override string ToString()
    {
        return $@"
{{
    IdPurchasedProduct: {IdPurchasedProduct},
    Name: {this.Name},
    Price: {this.Price},
    ProducerName: {this.ProducerName},
    Quantity: {this.Quantity},
    Discount: {this.Discount}
}}
";
    }
}
