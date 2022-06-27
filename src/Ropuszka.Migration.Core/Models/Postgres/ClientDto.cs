namespace Ropuszka.Migration.Core.Models.Postgres;

public class ClientDto : IModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? EmailAddress { get; set; }
    
    public override string ToString()
    {
        return $@"
{{
    Id: {this.Id},
    Name: {this.Name},
    DateOfBirth: {this.DateOfBirth},
    EmailAddress: {this.EmailAddress}
}}
";
    }
}
