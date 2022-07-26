using JCMG.EntitasRedux;
using System.Collections.Generic;

namespace Laboratories.Game
{
    public class HideMarkerPlacementSystem : ReactiveSystem<GameEntity>
    {
        private Contexts contexts;
        private IGroup<GameEntity> markerEntities;

        public HideMarkerPlacementSystem(Contexts contexts) : base(contexts.Game) 
        {
            this.contexts = contexts;
            markerEntities = contexts.Game.GetGroup(GameMatcher.MarkerPlacement);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Pickuped.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.IsPickuped == false;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var markerEntity in markerEntities.GetEntities())
                markerEntity.IsDestroyed = true;
        }
    }
}