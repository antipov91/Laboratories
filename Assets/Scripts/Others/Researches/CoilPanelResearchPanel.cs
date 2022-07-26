using Laboratories.Devices;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class CoilPanelResearchPanel : ResearchPanel
    {
        private float length;
        private float radius;
        private int count;

        [SerializeField] private Button centerBtn;
        [SerializeField] private Transform labelHandle;

        [SerializeField] private GridSystem gridSystem;

        [SerializeField] private GameObject coilPrefab;
        [SerializeField] private Text label;

        private List<GameObject> coils = new List<GameObject>();

        public override bool CheckCondition(Contexts contexts, GameEntity senderEntity)
        {
            return senderEntity.Device.instance is CoilPanelDevice;
        }

        protected override void OnInvoked()
        {
            //mu = 4f * Mathf.PI * 1e-7f;
            var device = gameEntity.Device.instance as CoilPanelDevice;

            length = device.Length / 100f;
            radius = device.Radius / 100f;
            count = device.Count;

            GenerateSlicedCoil(new Vector2(radius, -length / 2f), count, length / count);
            GenerateSlicedCoil(new Vector2(-radius, -length / 2f), count, length / count);

            gridSystem.OnClick += ClickHandle;
            gridSystem.CheckClickCondition = CheckClickCondition;

            centerBtn.onClick.AddListener(MoveToCenter);

            gridSystem.SetPosition(labelHandle.position);
        }

        private void MoveToCenter()
        {
            gridSystem.MoveToCenter();
        }

        private void ClickHandle(Vector2 position)
        {
            var device = gameEntity.Device.instance as CoilPanelDevice;

            var rb = Vector3.zero;
            foreach (var coilPart in coils)
            {
                var coilPosition = gridSystem.GetGridPoint(coilPart.transform.position);
                var gr = position - coilPosition;
                var r = new Vector3(gr.x, gr.y);
                var dl = Vector3.forward;

                if (coilPosition.x < 0f)
                    dl = Vector3.back;

                var b = 0.4f * Mathf.PI * (float)device.Current * Vector3.Cross(dl, r) / (r.magnitude * r.magnitude * r.magnitude);
                rb += b;
            }

            labelHandle.transform.position = gridSystem.GetWorldPoint(position);
            labelHandle.transform.right = rb;

            label.text = string.Format("{0:F2} ìêÒñ", rb.magnitude);
        }

        private bool CheckClickCondition(Vector2 position)
        {
            var wPosition = gridSystem.GetWorldPoint(position);
            bool isIntersection = false;
            foreach (var coilPart in coils)
            {
                var coilPosition = new Vector2(coilPart.transform.position.x, coilPart.transform.position.y);
                if (Vector2.Distance(coilPosition, wPosition) <= 40f)
                {
                    isIntersection = true;
                    break;
                }
            }
            return !isIntersection;
        }

        private void GenerateSlicedCoil(Vector2 startPosition, int count, float delta)
        {
            for (int i = 0; i < count; i++)
            {
                var gPosition = new Vector2(startPosition.x, i * delta + startPosition.y);
                var slicedCoil = Instantiate(coilPrefab, transform, true);
                slicedCoil.transform.position = gridSystem.GetWorldPoint(gPosition);
                coils.Add(slicedCoil);
            }
        }

        protected override void OnClosed()
        {
            foreach (var coil in coils)
                Destroy(coil.gameObject);

            coils.Clear();

            gridSystem.OnClick -= ClickHandle;
            centerBtn.onClick.RemoveListener(MoveToCenter);
        }
    }
}