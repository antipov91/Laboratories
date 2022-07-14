using JCMG.EntitasRedux;
using Laboratories.Views;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Laboratories.Game
{
    public class InitializeEntitySystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts contexts;

        public InitializeEntitySystem(Contexts contexts) : base(contexts.Game) 
        {
            this.contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InitializeGameObject.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.HasInitializeGameObject;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var blueprint = entity.InitializeGameObject.instance.GetComponent<GameBlueprintBehaviour>();
                blueprint.ApplyToEntity(entity);

                var view = blueprint.GetComponent<GameView>();
                if (view == null)
                    view = blueprint.gameObject.AddComponent<GameView>();

                if (entity.HasName == false)
                    entity.ReplaceName(blueprint.name + "_" + Guid.NewGuid().ToString());

                entity.ReplaceView(view);
                entity.ReplaceTransform(blueprint.GetComponent<Transform>());
                view.OnEntityInitilaized(contexts, entity);

                entity.RemoveInitializeGameObject();
            }
        }
    }
}