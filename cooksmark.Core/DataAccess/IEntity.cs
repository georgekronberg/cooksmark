namespace cooksmark.Core.DataAccess
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        int SchemaVersion { get; set; }
    }
}