using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
namespace ConsoleApp1
{
    class MyShape
    {
        public List<Vector2> MyPoints = new List<Vector2>();
        public Vector2 position = new Vector2();
        public List<Vector2> myGlobal = new List<Vector2>();
        public Color myColor;
        public AABB myBox = new AABB();
        public void Draw()
        {
            Vector2 Last = new Vector2();
            for (int idx = 0; idx < MyPoints.Count; idx++)
            {
                if (idx > 0)
                {
                    Vector2 tmp = position + Last;
                    Vector2 tmp2 = position + MyPoints[idx];
                    Raylib.Raylib.DrawLineEx(new Raylib.Vector2(tmp.x, tmp.y), new Raylib.Vector2(tmp2.x, tmp2.y), 2, myColor);
                }
                Last = MyPoints[idx];
            }
        }
    }

    public class AABB
    {
        Vector2 min = new Vector2(float.NegativeInfinity,
                                  float.NegativeInfinity);

        Vector2 max = new Vector2(float.PositiveInfinity,
                                  float.PositiveInfinity);

        public AABB()
        {

        }

        public AABB(Vector2 min, Vector2 max)
        {
            this.min = min;
            this.max = max;
        }

        public Vector2 Center()
        {
            return (min + max) * 0.5f;
        }

        public Vector2 Extents()
        {
            return new Vector2(Math.Abs(max.x - min.x) * 0.5f,
                               Math.Abs(max.y - min.y) * 0.5f);
        }

        public List<Vector2> Corners()
        {
            //ignoring z axis for 2D
            List<Vector2> corners = new List<Vector2>();
            corners[0] = min;
            corners[1] = new Vector2(min.x, max.y);
            corners[2] = max;
            corners[3] = new Vector2(max.x, min.y);
            return corners;
        }

        public void Fit(List<Vector2> points)
        {
            //invalidate the extends
            min = new Vector2(float.PositiveInfinity,
                              float.PositiveInfinity);

            max = new Vector2(float.NegativeInfinity,
                              float.NegativeInfinity);

            //find min and max of the points
            foreach (Vector2 p in points)
            {
                min = Vector2.Min(min, p);
                max = Vector2.Max(max, p);
            }

        }

        public bool Overlaps(Vector2 p)
        {
            //test for not overlapped as it exits faster
            return !(p.x < min.x || p.y < min.y || p.x > max.x || p.y > max.y);
        }

        public bool Overlaps(AABB other)
        {
            return !(max.x < other.min.x || max.y < other.min.y || min.x > other.max.x || min.y > other.max.y);
        }

        public Vector2 ClosestPoint(Vector2 p)
        {
            return Vector2.Clamp(p, min, max);
        }
    }

    public struct Vector2
    {
        public float x, y;

        public Vector2(float a, float b)
        {
            x = a;
            y = b;

        }
        public static Vector2 operator *(Vector2 lhs, float rhs)
        {
            return new Vector2(
            lhs.x * rhs,
            lhs.y * rhs);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(
            a.x - b.x,
            a.y - b.y);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        public float Dot(Vector2 rhs, float x, float y)
        {
            return x * rhs.x + y * rhs.y;
        }

        public float MagnitudeSqr()
        {
            return x * x + y * y;
        }

        public static Vector2 Min(Vector2 a, Vector2 b)
        {
            return new Vector2(Math.Min(a.x, b.x), Math.Min(a.y, b.y));
        }

        public static Vector2 Max(Vector2 a, Vector2 b)
        {
            return new Vector2(Math.Max(a.x, b.x), Math.Max(a.y, b.y));
        }

        public static Vector2 Clamp(Vector2 t, Vector2 a, Vector2 b)
        {
            return Max(a, Min(b, t));
        }

    }
}
