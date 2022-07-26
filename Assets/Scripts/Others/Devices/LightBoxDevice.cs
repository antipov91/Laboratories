using UnityEngine;

namespace Laboratories.Devices
{
    public class LightBoxDevice : MonoDevice
    {
        [SerializeField] private GameObject light;

        public override void Initialize()
        {
            light.SetActive(false);
        }

        protected override void OnDeviceState(bool isActive)
        {
            light.SetActive(isActive);
        }
    }
}