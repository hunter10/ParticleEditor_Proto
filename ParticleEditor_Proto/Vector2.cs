using System;
using System.Drawing;

namespace ParticleEditor_Proto
{
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        readonly public static Vector2 Zero = new Vector2(0, 0);
        readonly public static Vector2 One = new Vector2(1, 1);
        readonly public static Vector2 Right = new Vector2(1, 0);
        readonly public static Vector2 Down = new Vector2(0, 1);
        readonly public static Vector2 Up = new Vector2(0, -1);
        readonly public static Vector2 Left = new Vector2(-1, 0);




        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }
        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X * b.X, a.Y * b.Y);
        }
        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.X * b, a.Y * b);
        }
        public static Vector2 operator *(float b, Vector2 a)
        {
            return new Vector2(a.X * b, a.Y * b);
        }
        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X / b.X, a.Y / b.Y);
        }
        public static Vector2 operator /(Vector2 a, float b)
        {
            return new Vector2(a.X / b, a.Y / b);
        }


        public PointF ToPointF()
        {
            return new PointF(X, Y);
        }

        public static Vector2 Lerp(Vector2 v0, Vector2 v1, float t)
        {
            Vector2 vv = new Vector2(0, 0);
            vv = v0 * (1.0f - t) + v1 * t;
            return vv;
        }

        public static float Distance(Vector2 a, Vector2 b)
        {
            Vector2 vector = new Vector2(a.X - b.X, a.Y - b.Y);
            return (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static float Magnitude(Vector2 a)
        {
            return (float)Math.Sqrt(a.X * a.X + a.Y * a.Y);
        }

        public static float SqrMagnitude(Vector2 a)
        {
            return a.X * a.X + a.Y * a.Y;
        }
        public static Vector2 Normalize(Vector2 vec)
        {
            float len = (float)Math.Sqrt((vec.X * vec.X) + (vec.Y * vec.Y));
            float x = vec.X / len;
            float y = vec.Y / len;
            return new Vector2(x, y);
        }

        public static float Dot(Vector2 a, Vector2 b)
        {
            return (a.X * b.X + a.Y * b.Y);
        }


        public static float Cross(Vector2 a, Vector2 b)
        {
            float x = (a.X * b.Y - a.Y * b.X);
            return x;
        }


        public static Vector2 Projection(Vector2 v1, Vector2 v2)
        {
            return (v2 * (Dot(v1, v2) / (float)Math.Pow(Magnitude(v2), 2)));
        }

    }







    //--------------------------------------------
    //------------------- Ray --------------------
    //--------------------------------------------
    public class Ray
    {
        public Vector2 origin;
        public Vector2 normalized;

        public Ray(Vector2 pos, Vector2 dir)
        {
            origin = pos;
            normalized = dir;
        }
    }
}
