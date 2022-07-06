using JCMG.EntitasRedux;
using System.Collections.Generic;

namespace Laboratories.Game
{
	public class InteractableSystem : ReactiveSystem<GameEntity>
	{
        private readonly Contexts contexts;

		public InteractableSystem(Contexts contexts) : base(contexts.Game)
        {
            this.contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Clicked);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.IsClicked && entity.HasPossibleActions && entity.HasId;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                contexts.Ui.ManagerEntity.ReplaceInvokeRadialMenuCommand(entity.Id.value);
                entity.IsClicked = false;
            }
        }
    }
}