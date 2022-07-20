using System.Linq;

namespace Laboratories
{
    public class SettingsButton : RadialButton
    {
        public override bool CheckPossibleAction(Contexts contexts, GameEntity senderEntity)
        {
            return senderEntity.HasDevice &&
                   senderEntity.PossibleActions.values.Contains(Actions.Edit) &&
                   (senderEntity.HasDeviceActive == false || (senderEntity.HasDeviceActive && senderEntity.DeviceActive.value)) &&
                   (senderEntity.HasActivePlacement == false || (senderEntity.HasActivePlacement && senderEntity.ActivePlacement.value));
        }

        protected override void Click(Contexts contexts, GameEntity senderEntity)
        {
            contexts.Ui.ManagerEntity.DeviceSettings.instance.Invoke(contexts, senderEntity);
        }
    }
}