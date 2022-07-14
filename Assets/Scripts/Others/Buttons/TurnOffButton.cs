using System.Linq;

namespace Laboratories
{
    public class TurnOffButton : RadialButton
    {
        public override bool CheckPossibleAction(Contexts contexts, GameEntity senderEntity)
        {
            return senderEntity.PossibleActions.values.Contains(Actions.TurnOff) &&
                   senderEntity.HasDeviceActive && senderEntity.DeviceActive.value;
        }

        protected override void Click(Contexts contexts, GameEntity senderEntity)
        {
            senderEntity.ReplaceDeviceActive(false);
        }
    }
}