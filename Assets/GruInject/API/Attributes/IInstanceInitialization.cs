namespace GruInject.API.Attributes
{
    public interface IInstanceInitialization
    {
        void InitializeGruInstance(GruMonoBehaviour gruMonoBehaviour);
    }
}