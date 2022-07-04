using JCMG.EntitasRedux;

namespace Laboratories.Views
{
    public interface IView
    {
        void OnEntityInitilaized(Contexts contexts, IEntity entity);
        void OnEntityDestroyed();
    }
}