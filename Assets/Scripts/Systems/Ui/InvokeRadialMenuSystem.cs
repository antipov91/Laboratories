using JCMG.EntitasRedux;
using System.Collections.Generic;

namespace Laboratories.Ui
{
    public class InvokeRadialMenuSystem : ReactiveSystem<UiEntity>
    {
        private readonly Contexts contexts;

        public InvokeRadialMenuSystem(Contexts contexts) : base(contexts.Ui)
        {
            this.contexts = contexts;
        }

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.InvokeRadialMenuCommand);
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.HasInvokeRadialMenuCommand;
        }

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var entity in entities)
            {
                var senderEntity = contexts.Game.GetEntityWithId(entity.InvokeRadialMenuCommand.gameEntityId);

                contexts.Ui.ManagerEntity.RadialMenu.instance.Invoke(contexts, senderEntity);

                contexts.Meta.ManagerEntity.ReplaceGameState(GameState.Focused);
                entity.RemoveInvokeRadialMenuCommand();
            }
        }
    }
}