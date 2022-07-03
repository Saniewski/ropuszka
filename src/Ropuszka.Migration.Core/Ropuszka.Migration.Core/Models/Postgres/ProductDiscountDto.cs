namespace Ropuszka.Migration.Core.Models.Postgres;

public class ProductDiscountDto : IModel
{
    public int Id { get; set; }
    public int IdProduct { get; set; }
    public int IdDiscount { get; set; }
    
    public override string ToString()
    {
        return $@"
{{
    Id: {this.Id},
    IdProduct: {this.IdProduct},
    IdDiscount: {this.IdDiscount}
}}
";
    }
}
