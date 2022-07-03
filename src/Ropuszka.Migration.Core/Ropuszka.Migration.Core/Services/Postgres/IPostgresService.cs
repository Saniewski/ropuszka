namespace Ropuszka.Migration.Core.Services.Postgres;

public interface IPostgresService<T>
{
    public int GetNextId();
    public void Add(T obj);
    public IEnumerable<T> GetAll();
    public IEnumerable<int> GetAllIds();
    public T? GetById(int id);
}