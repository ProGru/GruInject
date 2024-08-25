namespace GruInject.Example.PersistenceOperations.API
{
    public interface IPersistenceLoader
    {
        public int GetData(string key, int defaultValue);
    }
}