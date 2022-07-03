namespace Ropuszka.Migration.Core.Models.Mongo.Shop;

public class Discount
{
    public int IdDiscount { get; set; }
    public string? Name { get; set; }
    public double Percentage { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    
    public override string ToString()
    {
        return $@"
{{
    IdDiscount: {this.IdDiscount},
    Name: {this.Name},
    Percentage: {this.Percentage},
    DateFrom: {this.DateFrom},
    DateTo: {this.DateTo}
}}
";
    }
}
