using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;


namespace ParticleEditor_Proto
{
    class DXDraw
    {
        public static void DrawTextFont(Device device, Microsoft.DirectX.Direct3D.Font f, string text, int sx, int sy, Color color)
        {
            using (Microsoft.DirectX.Direct3D.Sprite s = new Microsoft.DirectX.Direct3D.Sprite(device))
            {
                s.Begin(SpriteFlags.AlphaBlend);

                f.DrawText(s, text, new Point(sx, sy), color);

                s.End();
                s.Dispose();

            }
        }

        /// <summary>
        /// 다이렉트엑스 디바이스에 원본 텍스쳐를 그림.
        /// </summary>
        /// <param name="device"></param>
        /// <param name="texture"></param>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="size">확대,축소된 사이즈</param>
        public static void DrawTexture(Device device, Texture texture, int sx, int sy, Size size)
        {
            DrawTexture(device, texture, Rectangle.Empty, sx, sy, size, 100);
        }

        /// <summary>
        /// 다이렉트엑스 디바이스에 부분 텍스쳐를 그림.
        /// </summary>
        /// <param name="device"></param>
        /// <param name="texture"></param>
        /// <param name="sx">그려질 x</param>
        /// <param name="sy">그려질 y</param>
        /// <param name="size"> 확대,축소된 사이즈</param>
        /// <param name="rc">원본이미지에서 그려질 영역</param>
        public static void DrawTexture(Device device, Texture texture, Rectangle rc, int sx, int sy, Size size)
        {
            DrawTexture(device, texture, rc, sx, sy, size, 100);
        }

        /// <summary>
        /// devixe에 texture rc만큼 size로 sx,sy에 alpha값으로 그림.
        /// </summary>
        /// <param name="device"></param>
        /// <param name="texture"></param>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="size">확대,축소 사이즈</param>
        /// <param name="rc">원본 texture에서 그려질 영역</param>
        /// <param name="alpha">투명 알파값 100 ~ 0:완전투명</param>
        public static void DrawTexture(Device device, Texture texture, Rectangle rc, int sx, int sy, Size size, int alpha)
        {
            using (Microsoft.DirectX.Direct3D.Sprite s = new Microsoft.DirectX.Direct3D.Sprite(device))
            {
                s.Begin(SpriteFlags.AlphaBlend);
                s.Draw2D(texture, rc, size, new Point(0, 0), 0.0f, new Point(sx, sy), Color.FromArgb(((255 * alpha) / 100), 255, 255, 255));
                s.End();
                s.Dispose();
            }
        }

        public static void DrawLine(Device device, int sx, int sy, int ex, int ey, Color color)
        {
            CustomVertex.TransformedColored[] vertexes = new CustomVertex.TransformedColored[2];
            device.VertexFormat = CustomVertex.TransformedColored.Format;

            vertexes[0].Position = new Vector4(sx, sy, 0, 2.0f);
            vertexes[0].Color = color.ToArgb();

            vertexes[1].Position = new Vector4(ex, ey, 0, 2.0f);
            vertexes[1].Color = color.ToArgb();

            device.DrawUserPrimitives(PrimitiveType.LineList, 1, vertexes);
        }
        public static void DrawLine(Device device, float sx, float sy, float ex, float ey, Color color)
        {
            CustomVertex.TransformedColored[] vertexes = new CustomVertex.TransformedColored[2];
            device.VertexFormat = CustomVertex.TransformedColored.Format;

            vertexes[0].Position = new Vector4(sx, sy, 0, 2.0f);
            vertexes[0].Color = color.ToArgb();

            vertexes[1].Position = new Vector4(ex, ey, 0, 2.0f);
            vertexes[1].Color = color.ToArgb();

            device.DrawUserPrimitives(PrimitiveType.LineList, 1, vertexes);
        }

        public static void DrawRectangle(Device device, int sx, int sy, int width, int height, Color color)
        {
            int ex = sx + width, ey = sy + height;
            DrawLine(device, sx, sy, ex, sy, color);
            DrawLine(device, sx, ey, ex, ey, color);
            DrawLine(device, sx, sy, sx, ey, color);
            DrawLine(device, ex, sy, ex, ey, color);
        }

        public static void DrawFillRectangle(Device device, int sx, int sy, int width, int height, Color color)
        {
            int ex = sx + width, ey = sy + height;
            CustomVertex.TransformedColored[] vertexes = new CustomVertex.TransformedColored[3];

            device.VertexFormat = CustomVertex.TransformedColored.Format;

            vertexes[0].Position = new Vector4(sx, sy, 0, 1.0f);
            vertexes[0].Color = color.ToArgb();

            vertexes[1].Position = new Vector4(ex, sy, 0, 1.0f);
            vertexes[1].Color = color.ToArgb();

            vertexes[2].Position = new Vector4(ex, ey, 0, 1.0f);
            vertexes[2].Color = color.ToArgb();

            device.DrawUserPrimitives(PrimitiveType.TriangleList, 1, vertexes);

            vertexes[0].Position = new Vector4(sx, sy, 0, 1.0f);
            vertexes[0].Color = color.ToArgb();

            vertexes[1].Position = new Vector4(ex, ey, 0, 1.0f);
            vertexes[1].Color = color.ToArgb();

            vertexes[2].Position = new Vector4(sx, ey, 0, 1.0f);
            vertexes[2].Color = color.ToArgb();

            device.DrawUserPrimitives(PrimitiveType.TriangleList, 1, vertexes);

            return;
        }

        public static void DrawScreenGrid(Device device, int grid, int startx, int starty, int width, int height, Color color)
        {
            int Grid = grid;
            int HarfGrid = grid / 2;

            for (int y = starty; y < starty + height + Grid; y += Grid)
            {
                for (int x = startx; x < startx + width + HarfGrid; x += HarfGrid)
                    DrawFillRectangle(device, x, y + (((x / HarfGrid) % 2) * HarfGrid), HarfGrid, HarfGrid, color);
            }
        }

        public static void DrawScreenCenterGrid(Device device, int grid, int startx, int starty, int width, int height, Color color)
        {
            int Grid = grid;
            int HarfGrid = grid / 2;

            //DrawFillRectangle(device, startx, starty, width, height, color);

            for (int y = starty + (height / 2); y > starty; y -= Grid)
            {
                for (int x = startx + (width / 2); x < startx + width - HarfGrid; x += HarfGrid)
                {
                    DrawFillRectangle(device, x, y - (x / HarfGrid % 2 * HarfGrid), HarfGrid, HarfGrid, color);
                }

                for (int x = startx + (width / 2); x > startx; x -= HarfGrid)
                {
                    DrawFillRectangle(device, x, y - (x / HarfGrid % 2 * HarfGrid), HarfGrid, HarfGrid, color);
                }
            }

            for (int y = starty + (height / 2) + Grid; y < starty + height; y += Grid)
            {
                for (int x = startx + (width / 2); x < startx + width - HarfGrid; x += HarfGrid)
                {
                    DrawFillRectangle(device, x, y - (x / HarfGrid % 2 * HarfGrid), HarfGrid, HarfGrid, color);
                }

                for (int x = startx + (width / 2); x > startx; x -= HarfGrid)
                {
                    DrawFillRectangle(device, x, y - (x / HarfGrid % 2 * HarfGrid), HarfGrid, HarfGrid, color);
                }
            }
        }


        public static void DrawCircle(Device device, float x, float y, int size, Color color)
        {
            int side = 16;
            float angle = 360f / (float)side * cMath.DEG;
            for (int i = 0; i < side; i++)
            {
                float ang = i * angle;
                float Cos = (float)Math.Cos(ang) * size; float Sin = (float)Math.Sin(ang) * size;

                float ang2 = (i + 1) * angle;
                float Cos2 = (float)Math.Cos(ang2) * size; float Sin2 = (float)Math.Sin(ang2) * size;
                DrawLine(device, (int)(x + Cos), (int)(y + Sin), (int)(x + Cos2), (int)(y + Sin2), color);
            }
        }
    }
}
