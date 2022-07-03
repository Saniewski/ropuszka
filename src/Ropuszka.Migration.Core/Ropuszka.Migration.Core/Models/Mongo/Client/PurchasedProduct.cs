namespace Ropuszka.Migration.Core.Models.Mongo.Client;

public class PurchasedProduct
{
    public int IdProduct { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public string? ProducerName { get; set; }
    public double Quantity { get; set; }
    public Discount? Discount { get; set; }
    
    public override string ToString()
    {
        return $@"
{{
    IdProduct: {this.IdProduct},
    Name: {this.Name},
    Price: {this.Price},
    ProducerName: {this.ProducerName},
    Quantity: {this.Quantity},
    Discount: {this.Discount}
}}
";
    }
}
