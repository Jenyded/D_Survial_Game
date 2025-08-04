using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class Vector3Utils
    {
        private const float defaultError = 0.001f;

        public static Vector3 SetX(this Vector3 v, float x) => new Vector3(x, v.y, v.z);
        public static Vector3 SetY(this Vector3 v, float y) => new Vector3(v.x, y, v.z);
        public static Vector3 SetZ(this Vector3 v, float z) => new Vector3(v.x, v.y, z);

        public static Vector3 MoveX(this Vector3 v, float x) => new Vector3(v.x + x, v.y, v.z);
        public static Vector3 MoveY(this Vector3 v, float y) => new Vector3(v.x, v.y + y, v.z);
        public static Vector3 MoveZ(this Vector3 v, float z) => new Vector3(v.x, v.y, v.z + z);

        public static Vector3 ScaleInverse(this Vector3 v1, Vector3 v2) => new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);

        public static Vector3 Scaled(this Vector3 v1, Vector3 v2) => new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);

        public static float[] ToArray(this Vector3 v) => new[] {v.x, v.y, v.z};

        public static List<float> ToList(this Vector3 v) => new List<float> {v.x, v.y, v.z};

        public static IEnumerable<float> ToEnumerable(this Vector3 v)
        {
            yield return v.x;
            yield return v.y;
            yield return v.z;
        }

        public static Vector3 Normalize(this Vector3 v, float magnitude) => magnitude > 9.99999974737875E-06 ? v / magnitude : Vector3.zero;

        public static Quaternion ToEuler(this Vector3 v) => Quaternion.Euler(v);

        public static Vector3 Rotate(this Vector3 v, Vector3 axis, float angle) => Quaternion.AngleAxis(angle, axis) * v;

        public static float GetMagnitudeProjected(this Vector3 v, Vector3 onNormal)
        {
            float dotSign = Mathf.Sign(Vector3.Dot(v, onNormal));
            return Vector3.Project(v, onNormal * dotSign).magnitude * dotSign;
        }

        public static Vector3 ToVector3(this IEnumerable<float> enumerable)
        {
            var v = new Vector3();

            int index = 0;
            foreach (var f in enumerable)
            {
                v[index++] = f;
            }

            return v;
        }

        public static Vector3 RotateX(this Vector3 v, float angle) => Quaternion.Euler(angle, 0f, 0f) * v;
        public static Vector3 RotateY(this Vector3 v, float angle) => Quaternion.Euler(0f, angle, 0f) * v;
        public static Vector3 RotateZ(this Vector3 v, float angle) => Quaternion.Euler(0f, 0f, angle) * v;

       /* public static bool IsNearZero(this Vector3 v, float error = defaultError) =>
            v.x.IsNearZero(error) && v.y.IsNearZero(error) && v.z.IsNearZero(error);

        public static bool AlmostEqual(this Vector3 v1, Vector3 v2, float error = defaultError) =>
            v1.x.IsNear(v2.x, error) && v1.y.IsNear(v2.y, error) && v1.z.IsNear(v2.z, error);*/

        public static Vector2 ToVector2(this Vector3 v) => new Vector2(v.x, v.z);

        public static Vector3 RandomDirection() =>
            new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        public static Vector3 SnapTo(this Vector3 v3, float snapAngle)
        {
            float angle = Vector3.Angle(v3, Vector3.up);
            if (angle < snapAngle / 2.0f) // Cannot do cross product 
                return Vector3.up * v3.magnitude; //   with angles 0 & 180
            if (angle > 180.0f - snapAngle / 2.0f)
                return Vector3.down * v3.magnitude;

            float t = Mathf.Round(angle / snapAngle);
            float deltaAngle = (t * snapAngle) - angle;

            Vector3 axis = Vector3.Cross(Vector3.up, v3);
            Quaternion q = Quaternion.AngleAxis(deltaAngle, axis);
            return q * v3;
        }

   /*     public static float ValueOfNonZeroAxis(this Vector3 v)
        {
            if (!v.x.IsNearZero()) return v.x;
            if (!v.y.IsNearZero()) return v.y;
            if (!v.z.IsNearZero()) return v.z;
            return 0;
        }*/
    }
}