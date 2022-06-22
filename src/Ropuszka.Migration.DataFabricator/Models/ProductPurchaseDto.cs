namespace Ropuszka.Migration.DataFabricator.Models;

public class ProductPurchaseDto : IModel
{
    public int Id { get; set; }
    public int IdProduct { get; set; }
    public int IdPurchase { get; set; }
    public int Quantity { get; set; }
    
    public override string ToString()
    {
        return $@"
{{
    Id: {this.Id},
    IdProduct: {this.IdProduct},
    IdPurchase: {this.IdPurchase},
    Quantity: {this.Quantity}
}}
";
    }
}
