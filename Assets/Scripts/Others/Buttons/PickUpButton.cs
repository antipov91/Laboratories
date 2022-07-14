using System.Linq;
using UnityEngine;

namespace Laboratories
{
    public class PickUpButton : RadialButton
    {
        public override bool CheckPossibleAction(Contexts contexts, GameEntity senderEntity)
        {
            if (senderEntity.HasPossibleActions == false)
                return false;

            return senderEntity.PossibleActions.values.Contains(Actions.PickUp) && senderEntity.HasConnectedCount == false;
        }

        protected override void Click(Contexts contexts, GameEntity senderEntity)
        {
            senderEntity.IsPickuped = true;

            var colliders = LaboratoriesTools.GetAllComponents<Collider>(senderEntity.Transform.instance.gameObject);
            foreach (var collider in colliders)
                collider.enabled = false;

            contexts.Game.PlayerEntity.ReplaceDraggableObject(senderEntity.Id.value);
        }
    }
}