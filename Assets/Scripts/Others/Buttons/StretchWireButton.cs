using Laboratories.Views;
using System;
using System.Linq;
using UnityEngine;

namespace Laboratories
{
    public class StretchWireButton : RadialButton
    {
        public override bool CheckPossibleAction(Contexts contexts, GameEntity senderEntity)
        {
            return senderEntity.HasSocket &&
                   senderEntity.PossibleActions.values.Contains(Actions.CreateWire) &&
                   contexts.Game.PlayerEntity.HasSelectedSocket &&
                   contexts.Game.PlayerEntity.SelectedSocket.id != senderEntity.Id.value;
        }

        protected override void Click(Contexts contexts, GameEntity senderEntity)
        {
            var playerEntity = contexts.Game.PlayerEntity;
            var config = contexts.Meta.ManagerEntity.GameConfig.instance;

            Wire wire = null;
            switch (playerEntity.SelectedWirePrefab.value)
            {
                case WireType.BlackWire:
                    wire = Instantiate(config.blackWirePrefab);
                    break;
                case WireType.RedWire:
                    wire = Instantiate(config.redWirePrefab);
                    break;
                case WireType.BrownWire:
                    wire = Instantiate(config.brownWirePrefab);
                    break;
                case WireType.PurpleWire:
                    wire = Instantiate(config.purpleWirePrefab);
                    break;
                case WireType.BlueWire:
                    wire = Instantiate(config.blueWirePrefab);
                    break;
                case WireType.GreyWire:
                    wire = Instantiate(config.greyWirePrefab);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var wireEntity = contexts.Game.CreateEntity();
            wireEntity.ReplaceInitializeGameObject(wire.gameObject);

            var firstSocketEntity = contexts.Game.GetEntityWithId(playerEntity.SelectedSocket.id);
            var firstDeviceEntity = contexts.Game.GetEntityWithName(firstSocketEntity.Socket.ownerDeviceName);
            var firstJoint = firstDeviceEntity.Device.instance.GetJoints()[firstSocketEntity.Socket.id];

            var senderDeviceEntity = contexts.Game.GetEntityWithName(senderEntity.Socket.ownerDeviceName);
            var senderJoint = senderDeviceEntity.Device.instance.GetJoints()[senderEntity.Socket.id];
            wireEntity.ReplaceInitializeWire(firstJoint, senderJoint);

            wireEntity.ReplaceConnected(firstDeviceEntity.Id.value, senderDeviceEntity.Id.value);

            if (firstDeviceEntity.HasConnectedCount)
                firstDeviceEntity.ReplaceConnectedCount(firstDeviceEntity.ConnectedCount.value + 1);
            else
                firstDeviceEntity.ReplaceConnectedCount(1);

            if (senderDeviceEntity.HasConnectedCount)
                senderDeviceEntity.ReplaceConnectedCount(senderDeviceEntity.ConnectedCount.value + 1);
            else
                senderDeviceEntity.ReplaceConnectedCount(1);

            wire.Connect(firstSocketEntity.Socket.connectPivot.position, senderEntity.Socket.connectPivot.position, 2.5f);

            playerEntity.RemoveSelectedSocket();
            playerEntity.RemoveSelectedWirePrefab();
        }
    }
}