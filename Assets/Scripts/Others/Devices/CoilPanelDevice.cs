using SharpCircuit;
using UnityEngine;

namespace Laboratories.Devices
{
    public class CoilPanelDevice : MonoDevice
    {
        public double Inductance
        {
            get { return inductorElm.inductance; }
            set { inductorElm.inductance = value; }
        }

        public double Current { get { return inductorElm.getCurrent(); } }

        public float MinInductance { get { return minValue; } }
        public float MaxInductance { get { return maxValue; } }

        public float Length { get; set; }
        public float MinLength { get { return minLength; } }
        public float MaxLength { get { return maxLength; } }

        public float Radius { get; set; }
        public float MinRadius { get { return minRadius; } }
        public float MaxRadius { get { return maxRadius; } }

        public int Count { get; set; }
        public int MinCount { get { return minCount; } }
        public int MaxCount { get { return maxCount; } }

        [SerializeField] private float initValue = 0.1f;
        [SerializeField] private float minValue = 0.01f;
        [SerializeField] private float maxValue = 1f;

        [SerializeField] private float initLength = 0.2f;
        [SerializeField] private float minLength = 0.1f;
        [SerializeField] private float maxLength = 0.3f;

        [SerializeField] private float initRadius = 0.05f;
        [SerializeField] private float minRadius = 0.1f;
        [SerializeField] private float maxRadius = 0.15f;

        [SerializeField] private int initCount = 20;
        [SerializeField] private int minCount = 10;
        [SerializeField] private int maxCount = 30;

        private InductorElm inductorElm;

        public override void Initialize()
        {
            Length = initLength;
            Radius = initRadius;
            Count = initCount;

            inductorElm = new InductorElm(initValue);
            deviceContext.Create(inductorElm, joints.Create("in"), joints.Create("out"));
        }
    }
}