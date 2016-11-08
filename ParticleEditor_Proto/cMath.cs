using System;
using System.Collections.Generic;
using Microsoft.DirectX;

namespace ParticleEditor_Proto
{
    public class cMath
    {
        public const float RAD = 180 / (float)Math.PI;
        public const float DEG = (float)Math.PI / 180;


        //-----------------ooo Math 선형 보간 ------------------------
        public static Vector2 Lerp(Vector2 v0, Vector2 v1, float t)
        {
            Vector2 vv = new Vector2(0, 0);
            vv = v0 * (1.0f - t) + v1 * t;
            return vv;
        }
        public static float Lerp(float v0, float v1, float t)
        {
            float vv = 0;
            vv = v0 * (1.0f - t) + v1 * t;
            return vv;
        }
        public static double Lerp(double v0, double v1, double t)
        {
            double vv = 0;
            vv = v0 * (1.0 - t) + v1 * t;
            return vv;
        }
        public static float InverseLerp(float v0, float v1, float t)
        {
            return (t - v0) / (v1 - v0);
        }



        // Cosine 보간
        public static float CosineInterpolate(float y1, float y2, float mu)
        {
            float mu2;
            mu2 = (1 - (float)Math.Cos(mu * Math.PI)) / 2;
            return (y1 * (1 - mu2) + y2 * mu2);
        }


        public static Vector2 RotateRadians(Vector2 v, float radians)
        {
            float ca = (float)Math.Cos(radians);
            float sa = (float)Math.Sin(radians);
            return new Vector2(ca * v.X - sa * v.Y, sa * v.X + ca * v.Y);
        }
        public static Vector3 RotateRadians(Vector3 v, float radians)
        {
            float ca = (float)Math.Cos(radians);
            float sa = (float)Math.Sin(radians);
            return new Vector3(ca * v.X - sa * v.Y, sa * v.X + ca * v.Y, 0);
        }




        public static float Clamp(float val, float min, float max)
        {
            if (val < min) return min;
            if (val > max) return max;
            return val;
        }
        public static int Clamp(int val, int min, int max)
        {
            if (val < min) return min;
            if (val > max) return max;
            return val;
        }



        //  find the point on the line AB which is the projection of the point C:
        static public Vector2 pointLineProj(Vector2 pA, Vector2 pB, Vector2 pC)
        {
            Vector2 vAB = pB - pA;
            Vector2 vAC = pC - pA;
            float d = Vector2.Dot(Vector2.Normalize(vAB), Vector2.Normalize(vAC));
            Vector2 ppos = pA + (vAB * (d * (Vector2.Magnitude(vAC) / Vector2.Magnitude(vAB))));
            return ppos;
        }
        static public Vector2 pointLineProj2(Vector2 pA, Vector2 pB, Vector2 pC)            // 범위를 벋어나지 않는다
        {
            Vector2 vAB = pB - pA;
            Vector2 vAC = pC - pA;
            float d = Vector2.Dot(Vector2.Normalize(vAB), Vector2.Normalize(vAC));
            Vector2 ppos = pA + (vAB * (d * (Vector2.Magnitude(vAC) / Vector2.Magnitude(vAB))));

            float dis0 = Vector2.Distance(pA, pB);
            float dis1 = Vector2.Distance(pA, ppos);
            float dis2 = Vector2.Distance(pB, ppos);
            if (dis0 < dis1) ppos = pB;
            if (dis0 < dis2) ppos = pA;
            if (float.IsNaN(ppos.X)) ppos = pC;
            return ppos;
        }

        public static Vector2 LineIntersection(Vector2 A, Vector2 B, Vector2 C, Vector2 D)
        {
            float Ax = A.X;
            float Ay = A.Y;
            float Bx = B.X;
            float By = B.Y;
            float Cx = C.X;
            float Cy = C.Y;
            float Dx = D.X;
            float Dy = D.Y;

            float distAB, theCos, theSin, newX, ABpos;
            if (Ax == Bx && Ay == By || Cx == Dx && Cy == Dy) return Vector2.Zero;

            Bx -= Ax; By -= Ay;
            Cx -= Ax; Cy -= Ay;
            Dx -= Ax; Dy -= Ay;

            distAB = (float)Math.Sqrt(Bx * Bx + By * By);

            theCos = Bx / distAB;
            theSin = By / distAB;
            newX = Cx * theCos + Cy * theSin;
            Cy = Cy * theCos - Cx * theSin; Cx = newX;
            newX = Dx * theCos + Dy * theSin;
            Dy = Dy * theCos - Dx * theSin; Dx = newX;

            if (Cy == Dy) return Vector2.Zero;

            ABpos = Dx + (Cx - Dx) * Dy / (Dy - Cy);
            float X = Ax + ABpos * theCos;
            float Y = Ay + ABpos * theSin;
            return new Vector2(X, Y);
        }






        //----------------- spline ---------------
        public static float catmullrom(float t, float p0, float p1, float p2, float p3)
        {
            t = Clamp(t, 0f, 1f);
            return 0.5f * (
                          (2 * p1) +
                          (-p0 + p2) * t +
                          (2 * p0 - 5 * p1 + 4 * p2 - p3) * t * t +
                          (-p0 + 3 * p1 - 3 * p2 + p3) * t * t * t
                          );
        }
        public static Vector2 catmullrom(float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
        {
            t = Clamp(t, 0f, 1f);
            return 0.5f * (
                          (2 * p1) +
                          (-1 * p0 + p2) * t +
                          (2 * p0 - 5 * p1 + 4 * p2 - p3) * t * t +
                          (-1 * p0 + 3 * p1 - 3 * p2 + p3) * t * t * t
                          );
        }


        // Spline 에서 Length 길이의 위치값을 리턴한다
        // posArr 는 Vector 배열
        public static Vector2 LengthInterpSpline(List<Vector2> posArr, float value, int interpolate = 1)
        {
            if (posArr.Count < 3) return Vector2.Zero;

            List<Vector2> newArr = new List<Vector2>();
            for (int i = 0; i < posArr.Count - 1; i++)
            {
                Vector2 pos0, pos1, pos2, pos3;

                if (i == 0)
                {
                    pos0 = posArr[i];
                    pos1 = posArr[i];
                    pos2 = posArr[i + 1];
                    pos3 = posArr[i + 2];
                    newArr.Add(pos1);

                    for (int j = 1; j < interpolate + 1; j++)
                    {
                        float step = (float)(j) / (float)(interpolate + 1);
                        Vector2 pos = cMath.catmullrom(step, pos0, pos1, pos2, pos3); newArr.Add(pos);
                    }
                }
                else if (i >= posArr.Count - 2)
                {
                    pos0 = posArr[i - 1];
                    pos1 = posArr[i];
                    pos2 = posArr[i + 1];
                    pos3 = posArr[i + 1];
                    newArr.Add(pos1);

                    for (int j = 1; j < interpolate + 1; j++)
                    {
                        float step = (float)(j) / (float)(interpolate + 1);
                        Vector2 pos = cMath.catmullrom(step, pos0, pos1, pos2, pos3); newArr.Add(pos);
                    }

                    newArr.Add(pos2);
                }
                else
                {
                    pos0 = posArr[i - 1];
                    pos1 = posArr[i];
                    pos2 = posArr[i + 1];
                    pos3 = posArr[i + 2];
                    newArr.Add(pos1);

                    for (int j = 1; j < interpolate + 1; j++)
                    {
                        float step = (float)(j) / (float)(interpolate + 1);
                        Vector2 pos = cMath.catmullrom(step, pos0, pos1, pos2, pos3); newArr.Add(pos);
                    }
                }
            }

            // 전체 길이를 구한다
            float total_len = 0;
            for (int i = 0; i < newArr.Count - 1; i++)
            {
                Vector2 p0 = newArr[i];
                Vector2 p1 = newArr[i + 1];

                float dis = Vector2.Distance(p0, p1);
                total_len += dis;
            }

            // 전체 길이에서 찾는다
            float v = Lerp(0, total_len, value);
            float add_len = 0;
            for (int i = 0; i < newArr.Count; i++)
            {
                Vector2 p0, p1;
                if (i >= newArr.Count - 1)
                {
                    p0 = newArr[i - 1];
                    p1 = newArr[i];
                }
                else
                {
                    p0 = newArr[i];
                    p1 = newArr[i + 1];
                }
                float dis = Vector2.Distance(p0, p1);

                if (v <= add_len)
                {
                    if (i == 0)
                    {
                        p0 = newArr[i];
                        p1 = newArr[i + 1];
                        dis = Vector2.Distance(p0, p1);
                        float per = InverseLerp(0, dis, v);
                        Vector2 find = Vector2.Lerp(p0, p1, per);
                        return find;
                    }
                    else
                    {
                        p0 = newArr[i - 1];
                        p1 = newArr[i];
                        dis = Vector2.Distance(p0, p1);
                        float per = InverseLerp(add_len - dis, add_len, v);
                        Vector2 find = Vector2.Lerp(p0, p1, per);
                        return find;
                    }
                }
                add_len += dis;
            }
            return Vector2.Zero;
        }


        // Spline으로 point 위치를 찾는다
        public static Vector2 FindInterpSpline(List<Vector2> arr, Vector2 point, int interpolate)
        {
            List<Vector2> posArr = new List<Vector2>();
            float inc = 1f / interpolate;
            for (int i = 0; i < interpolate; i++)
            {
                float v = inc * i;
                Vector2 sp = cMath.LengthInterpSpline(arr, v, 10);
                v = inc * (i + 1);
                Vector2 ep = cMath.LengthInterpSpline(arr, v, 10);

                Vector2 p = pointLineProj2(sp, ep, point);
                posArr.Add(p);
            }

            float min = float.MaxValue;
            int find = 0;
            for (int i = 0; i < posArr.Count; i++)
            {
                float dis = Vector2.Distance(point, posArr[i]);
                if (dis < min)
                {
                    min = dis;
                    find = i;
                }
            }
            return posArr[find];
        }

        /*
            public static Vector2 FindInterpSplineDir(List<Vector2> arr, Vector2 dir)
            {
                List<Vector2> posArr = new List<Vector2>();
                int interpolate = 10;
                float inc = 1f / interpolate;
                for (int i = 0; i < interpolate; i++)
                {
                    float v = inc * i;
                    Vector2 sp = cMath.LengthInterpSpline(arr, v, 10);
                    v = inc * (i + 1);
                    Vector2 ep = cMath.LengthInterpSpline(arr, v, 10);

                    Vector2 p = pointLineProj2(sp, ep, point);
                    posArr.Add(p);
                }

                float min = float.MaxValue;
                int find = 0;
                for (int i = 0; i < posArr.Count; i++)
                {
                    float dis = Vector2.Distance(point, posArr[i]);
                    if (dis < min)
                    {
                        min = dis;
                        find = i;
                    }
                }
                return posArr[find];
            }
        */





        //--------------------------------------------------------------------------
        //---------------- Rotate2() : 회전
        //--------------------------------------------------------------------------
        public static Vector2 Rotate2(Vector2 pos, float angle)
        {
            return Rotate2(pos.X, pos.Y, angle);
        }
        public static Vector2 Rotate2(float x, float y, float angle)
        {
            float radian = angle * ((float)Math.PI * 2) / 360.0f;
            float sin = (float)Math.Sin(radian);
            float cos = (float)Math.Cos(radian);
            return new Vector2(x * cos - y * sin, x * sin + y * cos);
        }
    }
}
