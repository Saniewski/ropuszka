namespace Ropuszka.Migration.Core.Models;

public interface IModel
{
    public int Id { get; set; }
    
    public string ToString();
}
