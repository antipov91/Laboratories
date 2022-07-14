using System.Linq;

namespace Laboratories
{
    public class StretchGreyWireButton : RadialButton
    {
        public override bool CheckPossibleAction(Contexts contexts, GameEntity senderEntity)
        {
            return senderEntity.HasSocket &&
                   senderEntity.PossibleActions.values.Contains(Actions.CreateWire) &&
                   contexts.Game.PlayerEntity.HasSelectedSocket == false;
        }

        protected override void Click(Contexts contexts, GameEntity senderEntity)
        {
            var playerEntity = contexts.Game.PlayerEntity;
            playerEntity.ReplaceSelectedSocket(senderEntity.Id.value);
            playerEntity.ReplaceSelectedWirePrefab(WireType.GreyWire);
        }
    }
}