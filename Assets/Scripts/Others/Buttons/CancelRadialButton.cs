namespace Laboratories
{
    public class CancelRadialButton : RadialButton
    {
        public override bool CheckPossibleAction(Contexts contexts, GameEntity senderEntity)
        {
            return true;
        }

        protected override void Click(Contexts contexts, GameEntity senderEntity)
        {
            
        }
    }
}