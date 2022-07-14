using JCMG.EntitasRedux;
using System.Collections.Generic;

namespace Laboratories.Game
{
    public class InitializeDeviceSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts contexts;

        public InitializeDeviceSystem(Contexts contexts) : base(contexts.Game) 
        {
            this.contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Device);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.HasDevice;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
                entity.Device.instance.Initialize(contexts, entity);
        }
    }
}