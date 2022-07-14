using System.Linq;

namespace Laboratories
{
    public class RemoveWireButton : RadialButton
    {
        public override bool CheckPossibleAction(Contexts contexts, GameEntity senderEntity)
        {
            return senderEntity.HasPossibleActions &&
                   senderEntity.PossibleActions.values.Contains(Actions.RemoveWire);
        }

        protected override void Click(Contexts contexts, GameEntity senderEntity)
        {
            var firstEntity = contexts.Game.GetEntityWithId(senderEntity.Connected.firstId);
            firstEntity.ReplaceConnectedCount(firstEntity.ConnectedCount.value - 1);
            if (firstEntity.ConnectedCount.value <= 0)
                firstEntity.RemoveConnectedCount();

            var secondEntity = contexts.Game.GetEntityWithId(senderEntity.Connected.secondId);
            secondEntity.ReplaceConnectedCount(secondEntity.ConnectedCount.value - 1);
            if (secondEntity.ConnectedCount.value <= 0)
                secondEntity.RemoveConnectedCount();

            senderEntity.IsDestroyed = true;
        }
    }
}