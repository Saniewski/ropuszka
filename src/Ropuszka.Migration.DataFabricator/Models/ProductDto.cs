namespace Ropuszka.Migration.DataFabricator.Models;

public class ProductDto : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string ProducerName { get; set; }
    
    public override string ToString()
    {
        return $@"
{{
    Id: {this.Id},
    Name: {this.Name},
    Price: {this.Price},
    ProducerName: {this.ProducerName}
}}
";
    }
}
