using System.Linq;

namespace Laboratories
{
    public class ResearchButton : RadialButton
    {
        public override bool CheckPossibleAction(Contexts contexts, GameEntity senderEntity)
        {
            return senderEntity.HasDevice &&
                   senderEntity.PossibleActions.values.Contains(Actions.Research);
        }

        protected override void Click(Contexts contexts, GameEntity senderEntity)
        {
            contexts.Ui.ManagerEntity.Researches.instance.Invoke(contexts, senderEntity);
        }
    }
}