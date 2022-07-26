using JCMG.EntitasRedux;

namespace Laboratories.Game
{
    public class SceneCleanupSystem : ITearDownSystem
    {
        private readonly Contexts contexts;

        public SceneCleanupSystem(Contexts contexts)
        {
            this.contexts = contexts;
        }

        public void TearDown()
        {
            foreach (var entity in contexts.Game.GetEntities())
            {
                if (entity.HasView)
                    entity.View.instance.OnEntityDestroyed();

                entity.Destroy();
            }

            contexts.Reset();
        }
    }
}
