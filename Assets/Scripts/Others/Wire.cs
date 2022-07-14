using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Laboratories
{
    public class Wire : MonoBehaviour
    {
        [SerializeField] private int count = 10;
        [SerializeField] private float height = 0.1f;
        [SerializeField] private Transform firtsConnect;
        [SerializeField] private Transform secondConnect;
        
        private LineRenderer lineRenderer;

        private SphereCollider sphereCollider;
        private Vector3 startPosition;
        private Vector3 endPosition;
        private Vector3 previouseStartPosition;
        private Vector3 previouseEndPosition;
        private float previouseHeight;
        private int previouseCount;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            sphereCollider = GetComponent<SphereCollider>();
        }

        private void Update()
        {
            if (startPosition == previouseStartPosition &&
                endPosition == previouseEndPosition &&
                previouseHeight == height &&
                previouseCount == count)
                return;

            previouseStartPosition = startPosition;
            previouseEndPosition = endPosition;
            previouseHeight = height;
            previouseCount = count;

            var points = new Vector3[7];
            var direction = endPosition - startPosition;

            points[0] = startPosition;
            points[1] = startPosition + 0.9f * height * Vector3.up;
            points[2] = startPosition + height * Vector3.up + 0.1f * height * direction.normalized;

            points[3] = startPosition + height * Vector3.up + direction / 2f;

            points[4] = endPosition + height * Vector3.up - 0.1f * height * direction.normalized;
            points[5] = endPosition + 0.9f * height * Vector3.up;
            points[6] = endPosition;

            var linePoints = GetLinePoints(points).ToArray();
            lineRenderer.positionCount = linePoints.Length;
            lineRenderer.SetPositions(linePoints);

            var center = (points[0] + points[1] + points[2] + points[3] + points[4] + points[5] + points[6]) / (float)points.Length;

            transform.position = Vector3.zero;

            sphereCollider.center = center;
            
            firtsConnect.position = points[0];
            firtsConnect.rotation = Quaternion.identity;
            secondConnect.position = points[6];
            secondConnect.rotation = Quaternion.identity;
        }

        public void Connect(Vector3 start, Vector3 end, float velocity)
        {
            startPosition = start;
            endPosition = start;
            
            StartCoroutine(ConnectAnimation(GetPointsOfSegment(start, end), velocity));
        }

        private IEnumerator ConnectAnimation(Vector3[] path, float velocity)
        {
            startPosition = path[0];
            for (int i = 1; i < path.Length; i++)
            {
                while (startPosition != path[i])
                {
                    startPosition = Vector3.MoveTowards(startPosition, path[i], Time.deltaTime * velocity);
                    yield return new WaitForEndOfFrame();
                }
            }
        }

        public void SetStartPosition(Vector3 position)
        {
            startPosition = position;
        }

        public void SetEndPosition(Vector3 position)
        {
            endPosition = position;
        }

        public void SetCount(int count)
        {
            this.count = count;
        }

        public void SetHeight(float height)
        {
            this.height = height;
        }

        private Vector3[] GetPointsOfSegment(Vector3 start, Vector3 end)
        {
            var points = new Vector3[7];
            var direction = end - start;

            points[0] = start;
            points[1] = start + 0.9f * height * Vector3.up;
            points[2] = start + height * Vector3.up + 0.1f * height * direction.normalized;

            points[3] = start + height * Vector3.up + direction / 2f;

            points[4] = end + height * Vector3.up - 0.1f * height * direction.normalized;
            points[5] = end + 0.9f * height * Vector3.up;
            points[6] = end;

            return GetLinePoints(points).ToArray();
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