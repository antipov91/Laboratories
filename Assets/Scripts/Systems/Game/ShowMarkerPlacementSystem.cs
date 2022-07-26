using JCMG.EntitasRedux;
using System.Collections.Generic;
using UnityEngine;

namespace Laboratories.Game
{
    public class ShowMarkerPlacementSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts contexts;

        public ShowMarkerPlacementSystem(Contexts contexts) : base(contexts.Game) 
        {
            this.contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Pickuped.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.IsPickuped && entity.HasPlacements;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                foreach (var placement in entity.Placements.values)
                {
                    var marker = Object.Instantiate(contexts.Meta.ManagerEntity.GameConfig.instance.markerPlacement, placement.transform);

                    var markerEntity = contexts.Game.CreateEntity();
                    markerEntity.ReplaceInitializeGameObject(marker.gameObject);
                }
            }
        }
    }
}
