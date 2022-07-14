using JCMG.EntitasRedux;
using System.Collections.Generic;

namespace Laboratories.Game
{
	public class DestroySystem : ReactiveSystem<GameEntity>
	{
        public DestroySystem(Contexts contexts) : base(contexts.Game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Destroyed.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.IsDestroyed;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.HasView)
                {
                    entity.View.instance.OnEntityDestroyed();
                    entity.RemoveView();
                }

                entity.Destroy();
            }
        }
    }
}