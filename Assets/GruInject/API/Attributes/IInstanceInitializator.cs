namespace GruInject.API.Attributes
{
    public interface IInstanceInitializator
    {
        void InitializeGruInstance(GruMonoBehaviour gruMonoBehaviour);
    }
}