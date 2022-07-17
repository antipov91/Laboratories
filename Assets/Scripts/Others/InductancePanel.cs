using System.Collections.Generic;
using UnityEngine;

public class InductancePanel : MonoBehaviour
{
    [SerializeField] private float length = 0.5f;
    [SerializeField] private float radius = 0.25f;
    [SerializeField] private int count = 20;

    [SerializeField] private float mu = 1.1f;
    [SerializeField] private float current = 2;

    [SerializeField] private Transform label;

    [SerializeField] private GridSystem gridSystem;

    [SerializeField] private GameObject coilPrefab;
    

    private List<GameObject> coils = new List<GameObject>();

    private void Start()
    {
        mu = 4f * Mathf.PI * 1e-7f;
        var delta = length / count;
        GenerateSlicedCoil(new Vector2(radius, -length / 2f), count, length / count);
        GenerateSlicedCoil(new Vector2(-radius, -length / 2f), count, length / count);
    }

    private void OnEnable()
    {
        gridSystem.OnClick += ClickHandle;
        gridSystem.CheckClickCondition = CheckClickCondition;
    }

    private void ClickHandle(Vector2 position)
    {
        var rb = Vector3.zero;
        foreach (var coilPart in coils)
        {
            var coilPosition = gridSystem.GetGridPoint(coilPart.transform.position);
            var gr = position - coilPosition;
            var r = new Vector3(gr.x, gr.y);
            var dl = Vector3.forward;

            if (coilPosition.x < 0f)
                dl = Vector3.back;
                
            var b = current * (Vector3.Cross(dl, r)) / (r.magnitude * r.magnitude * r.magnitude);
            rb += b;
        }

        label.transform.position = gridSystem.GetWorldPoint(position);
        label.transform.right = rb;

        UnityEngine.Debug.Log(rb);
    }

    private bool CheckClickCondition(Vector2 position)
    {
        var wPosition = gridSystem.GetWorldPoint(position);
        bool isIntersection = false;
        foreach (var coilPart in coils)
        {
            var coilPosition = new Vector2(coilPart.transform.position.x, coilPart.transform.position.y);
            if (Vector2.Distance(coilPosition, wPosition) <= 20f)
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

    private void OnDisable()
    {
        gridSystem.OnClick -= ClickHandle;
    }
}