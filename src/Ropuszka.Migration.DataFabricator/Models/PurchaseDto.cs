namespace Ropuszka.Migration.DataFabricator.Models;

public class PurchaseDto : IModel
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int IdShop { get; set; }
    public int IdClient { get; set; }
    
    public override string ToString()
    {
        return $@"
{{
    Id: {this.Id},
    Date: {this.Date},
    IdShop: {this.IdShop},
    IdClient: {this.IdClient}
}}
";
    }
}
