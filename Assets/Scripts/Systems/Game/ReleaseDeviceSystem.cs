using JCMG.EntitasRedux;
using System.Collections.Generic;

namespace Laboratories.Game
{
    public class ReleaseDeviceSystem : ReactiveSystem<GameEntity>
    {
        public ReleaseDeviceSystem(Contexts contexts) : base(contexts.Game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Destroyed.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.HasDevice;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Device.instance.Release();
                entity.RemoveDevice();
            }
        }
    }
}