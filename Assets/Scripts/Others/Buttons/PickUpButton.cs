using System.Linq;

namespace Laboratories
{
    public class PickUpButton : RadialButton
    {
        public override bool CheckPossibleAction(Contexts contexts, GameEntity senderEntity)
        {
            if (senderEntity.HasPossibleActions == false)
                return false;

            return senderEntity.PossibleActions.values.Contains(Actions.PickUp);
        }

        protected override void Click(Contexts contexts, GameEntity senderEntity)
        {
            senderEntity.IsPickuped = true;
            contexts.Game.PlayerEntity.ReplaceDraggableObject(senderEntity.Id.value);
        }
    }
}