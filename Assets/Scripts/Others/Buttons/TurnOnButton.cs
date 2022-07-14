using System.Linq;

namespace Laboratories
{
    public class TurnOnButton : RadialButton
    {
        public override bool CheckPossibleAction(Contexts contexts, GameEntity senderEntity)
        {
            return senderEntity.PossibleActions.values.Contains(Actions.TurnOn) &&
                   senderEntity.HasDeviceActive && senderEntity.DeviceActive.value == false;
        }

        protected override void Click(Contexts contexts, GameEntity senderEntity)
        {
            senderEntity.ReplaceDeviceActive(true);
        }
    }
}