using UnityEngine;
using SharpCircuit;

namespace Laboratories.Devices
{
    public class SPDTSwitchDevice : MonoDevice
    {
        [SerializeField] private GameObject onGo;
        [SerializeField] private GameObject offGo;

        private SwitchSPST firstSwitch;
        private SwitchSPST secondSwitch;

        public override void Initialize()
        {
            firstSwitch = new SwitchSPST();
            secondSwitch = new SwitchSPST();

            deviceContext.Create(firstSwitch, joints.Create("in"), joints.Create("out1"));
            deviceContext.Create(secondSwitch, joints["in"], joints.Create("out2"));

            firstSwitch.toggle(true);
            secondSwitch.toggle(false);
        }

        protected override void OnDeviceState(bool isActive)
        {
            firstSwitch.toggle(!isActive);
            secondSwitch.toggle(isActive);

            onGo.gameObject.SetActive(isActive);
            offGo.gameObject.SetActive(!isActive);
        }
    }
}