namespace Ropuszka.Migration.Core.Models.Postgres;

public class DiscountDto : IModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Percentage { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    
    public override string ToString()
    {
        return $@"
{{
    Id: {this.Id},
    Name: {this.Name},
    Percentage: {this.Percentage},
    DateFrom: {this.DateFrom},
    DateTo: {this.DateTo}
}}
";
    }
}
