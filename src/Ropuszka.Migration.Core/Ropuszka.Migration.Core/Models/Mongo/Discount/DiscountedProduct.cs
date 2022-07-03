namespace Ropuszka.Migration.Core.Models.Mongo.Discount;

public class DiscountedProduct
{
    public int IdDiscountedProduct { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public string? ProducerName { get; set; }
    
    public override string ToString()
    {
        return $@"
{{
    IdDiscountedProduct: {IdDiscountedProduct},
    Name: {this.Name},
    Price: {this.Price},
    ProducerName: {this.ProducerName}
}}
";
    }
}
