using System.Collections.Generic;
using UnityEngine;

namespace Laboratories
{
    public class Wire : MonoBehaviour
    {
        [SerializeField] private int count = 10;
        [SerializeField] private float height = 0.1f;
        [SerializeField] private Transform start;
        [SerializeField] private Transform end;

        private LineRenderer lineRenderer;

        private Vector3 previouseStartPosition;
        private Vector3 previouseEndPosition;
        private float previouseHeight;
        private int previouseCount;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            if (start.position == previouseStartPosition &&
                end.position == previouseEndPosition &&
                previouseHeight == height &&
                previouseCount == count)
                return;

            previouseStartPosition = start.position;
            previouseEndPosition = end.position;
            previouseHeight = height;
            previouseCount = count;

            var points = new Vector3[7];
            var direction = end.position - start.position;

            points[0] = start.position;
            points[1] = start.position + 0.9f * height * Vector3.up;
            points[2] = start.position + height * Vector3.up + 0.1f * height * direction.normalized;

            points[3] = start.position + height * Vector3.up + direction / 2f;

            points[4] = end.position + height * Vector3.up - 0.1f * height * direction.normalized;
            points[5] = end.position + 0.9f * height * Vector3.up;
            points[6] = end.position;

            var linePoints = GetLinePoints(points).ToArray();
            lineRenderer.positionCount = linePoints.Length;
            lineRenderer.SetPositions(linePoints);
        }

        public void SetStartPosition(Vector3 position)
        {
            start.position = position;
        }

        public void SetEndPosition(Vector3 position)
        {
            end.position = position;
        }

        public void SetCount(int count)
        {
            this.count = count;
        }

        public void SetHeight(float height)
        {
            this.height = height;
        }

        private List<Vector3> GetLinePoints(Vector3[] points)
        {
            var waypoints = new List<Vector3>();
            for (int i = 0; i < points.Length - 3; i += 3)
            {
                var p0 = points[i];
                var p1 = points[i + 1];
                var p2 = points[i + 2];
                var p3 = points[i + 3];

                if (i == 0)
                    waypoints.Add(GetBezierPoint(p0, p1, p2, p3, 0f));

                for (int j = 1; j <= count; j++)
                {
                    float t = (float)j / count;
                    waypoints.Add(GetBezierPoint(p0, p1, p2, p3, t));
                }
            }
            return waypoints;
        }

        public Vector3 GetBezierPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            Vector3 p01 = Vector3.Lerp(p0, p1, t);
            Vector3 p12 = Vector3.Lerp(p1, p2, t);
            Vector3 p23 = Vector3.Lerp(p2, p3, t);

            Vector3 p012 = Vector3.Lerp(p01, p12, t);
            Vector3 p123 = Vector3.Lerp(p12, p23, t);

            return Vector3.Lerp(p012, p123, t);
        }
    }
}