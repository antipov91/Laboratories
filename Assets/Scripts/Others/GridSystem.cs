using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GridSystem : MonoBehaviour, IPointerClickHandler
{
    public Action<Vector2> OnClick;
    public Func<Vector2, bool> CheckClickCondition;

    [SerializeField] private Text label;
    [SerializeField] private RectTransform grid;
    [SerializeField] private Vector2 size;

    public Vector2 Size { get { return size; } }

    private void Awake()
    {
        label.text = string.Format("({0:F1} : {1:F1})", 0f, 0f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SetPosition(eventData.position);
    }

    public void SetPosition(Vector3 position)
    {
        var point = grid.InverseTransformPoint(position);
        if (grid.rect.Contains(point))
        {
            var coefficients = size / grid.rect.size;
            var cPoint = point * coefficients;

            if (CheckClickCondition(cPoint))
            {
                label.text = string.Format("({0:F1} : {1:F1})", cPoint.x, cPoint.y);
                OnClick?.Invoke(cPoint);
            }
        }
    }

    public void MoveToCenter()
    {
        var point = Vector2.zero;
        if (grid.rect.Contains(point))
        {
            var coefficients = size / grid.rect.size;
            var cPoint = point * coefficients;

            if (CheckClickCondition(cPoint))
            {
                label.text = string.Format("({0:F1} : {1:F1})", cPoint.x, cPoint.y);
                OnClick?.Invoke(cPoint);
            }
        }
    }

    public Vector2 GetGridPoint(Vector2 worldPoint)
    {
        var point = grid.InverseTransformPoint(worldPoint);
        var coefficients = size / grid.rect.size;
        var cPoint = point * coefficients;
        return cPoint;
    }

    public Vector2 GetWorldPoint(Vector2 point)
    {
        var coefficients = grid.rect.size / size;
        var wPoint = point * coefficients;
        return grid.TransformPoint(wPoint);
    }
}
