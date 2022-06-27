namespace Ropuszka.Migration.Core.Models.Mongo.Discount;

public class DiscountDto : IModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Percentage { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public IEnumerable<DiscountedProduct>? DiscountedProducts { get; set; }

    // TODO: pretty print the IEnumerable
    public override string ToString()
    {
        return $@"
{{
    Id: {this.Id},
    Name: {this.Name},
    Percentage: {this.Percentage},
    DateFrom: {this.DateFrom},
    DateTo: {this.DateTo},
    DiscountedProducts: {this.DiscountedProducts}
}}
";
    }
}
