namespace Ropuszka.Migration.Core.Models.Mongo.Product;

public class ProductDto : IModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public string? ProducerName { get; set; }
    public IEnumerable<Discount>? Discounts { get; set; }

    // TODO: pretty print the IEnumerable
    public override string ToString()
    {
        return $@"
{{
    Id: {this.Id},
    Name: {this.Name},
    Price: {this.Price},
    ProducerName: {this.ProducerName},
    Discounts: {this.Discounts}
}}
";
    }
}
