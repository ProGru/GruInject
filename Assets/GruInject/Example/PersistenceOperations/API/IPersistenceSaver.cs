namespace GruInject.Example.PersistenceOperations.API
{
    public interface IPersistenceSaver
    {
        void SaveData(string key, int data);
    }
}