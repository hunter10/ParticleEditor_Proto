using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace ParticleEditor_Proto
{
    public class Animation
    {
        public struct anidata
        {
            public int num, sx, sy, dx, dy;

            public void init()
            {
                num = -1;
                sx = sy = dx = dy = 0;
            }
        }

        public struct motiondata
        {
            public int count, start;
        }

        Sprite Target = null;
        public anidata[] Anim = null;
        public motiondata[] Motion = null;
        public int TotalFrame = 0, TotalMotion = 0;

        public string filename = null, pathname = null;
        public Rectangle rect;

        public Animation(Sprite target, int count)
        {
            Anim = new anidata[count];
            Motion = new motiondata[count];
            Target = target;
            Clear();
        }

        public void Clear()
        {
            if (Anim != null)
            {
                for (int i = 0; i < Anim.Length; i++) Anim[i].init();
            }
        }

        public string ByteToString(byte[] temp)
        {
            int i;
            for (i = 0; i < temp.Length; i++) if (temp[i] == 0) break;
            return System.Text.Encoding.Default.GetString(temp, 0, i);
        }

        ArrayList name = new ArrayList();

        public string GetName(int motion)
        {
            if (motion < name.Count) return (string)name[motion];
            return null;
        }

        public bool Load(string fname)
        {
            for (int k = fname.Length - 1; k >= 0; k--)
            {
                if (fname[k].Equals('\\'))
                {
                    pathname = fname.Substring(0, k);
                    filename = fname.Substring(k + 1, fname.Length - k - 1);
                    break;
                }
            }
            string fullname = pathname + '\\' + filename.Substring(0, filename.Length - 3) + "ani";

            if (File.Exists(fullname))
            {
                using (FileStream fs = File.OpenRead(fullname))
                {
                    Clear();

                    byte[] value = new byte[4];
                    byte[] version = new byte[6];

                    fs.Read(version, 0, 6);
                    if (!ByteToString(version).Equals("VER2.0")) fs.Seek(0, SeekOrigin.Begin);

                    fs.Read(value, 0, 4);
                    TotalFrame = BitConverter.ToInt32(value, 0);

                    for (int i = 0; i < TotalFrame; i++)
                    {
                        fs.Read(value, 0, 4); Anim[i].num = BitConverter.ToInt32(value, 0);
                        fs.Read(value, 0, 4); Anim[i].sx = BitConverter.ToInt32(value, 0);
                        fs.Read(value, 0, 4); Anim[i].sy = BitConverter.ToInt32(value, 0);

                        if (ByteToString(version).Equals("VER2.0"))
                        {
                            fs.Read(value, 0, 4); Anim[i].dx = BitConverter.ToInt32(value, 0);
                            fs.Read(value, 0, 4); Anim[i].dy = BitConverter.ToInt32(value, 0);
                        }
                    }
                    fs.Read(value, 0, 4);
                    TotalMotion = BitConverter.ToInt32(value, 0);

                    for (int i = 0; i < TotalMotion; i++)
                    {
                        fs.Read(value, 0, 4); Motion[i].count = BitConverter.ToInt32(value, 0);
                        fs.Read(value, 0, 4); Motion[i].start = BitConverter.ToInt32(value, 0);
                    }

                    int read = fs.Read(value, 0, 4);
                    if (read > 0)
                    {
                        name.Clear();
                        int len = BitConverter.ToInt32(value, 0);
                        byte[] temp = new byte[len];
                        fs.Read(temp, 0, len);
                        string str = Encoding.UTF8.GetString(temp, 0, len);
                        string[] text = str.Split('\n');
                        for (int i = 0; i < TotalMotion; i++) name.Add(text[i]);
                    }
                    fs.Close();
                }
                return true;
            }
            else
            {
                MessageBox.Show(fullname + "이 없습니다.");
                return false;
            }
        }

        public int GetWidth(int motion, int frame)
        {
            int num = Motion[motion].start + frame;
            return Target.sprite.Rect[Anim[num].num].Width;
        }

        public int GetHeight(int motion, int frame)
        {
            int num = Motion[motion].start + frame;
            return Target.sprite.Rect[Anim[num].num].Height;
        }

        public int GetFrame(int motion, int frame)
        {
            return Motion[motion].start + frame;
        }

        public void GetDest(float x, float y, int motion, int frame, float scalex, float scaley)
        {
            if (motion < 0 || motion >= TotalMotion) return;
            if (frame < 0) return;
            if (frame >= Motion[motion].count) frame = Motion[motion].count - 1;

            int num = Motion[motion].start + frame;

            if (num < 0 || num >= TotalFrame || Anim[num].num < 0) return;

            int x1 = (int)(x + (Anim[num].sx * scalex));
            int y1 = (int)(y + (Anim[num].sy * scaley));
            int width = (int)(Target.sprite.Rect[Anim[num].num].Width * scalex);
            int height = (int)(Target.sprite.Rect[Anim[num].num].Height * scaley);

            rect = new Rectangle(x1, y1, width, height);
        }

        public void DrawSprite(Graphics g, float x, float y, int motion, int frame, int scale)
        {
            if (motion < 0 || motion >= TotalMotion) return;
            if (frame < 0 || frame >= Motion[motion].count) return;

            int num = Motion[motion].start + frame;

            if (num < 0 || num >= TotalFrame || Anim[num].num < 0) return;

            int x1 = (int)(x + (Anim[num].sx * scale));
            int y1 = (int)(y + (Anim[num].sy * scale));
            int width = (int)(Target.sprite.Rect[Anim[num].num].Width * scale);
            int height = (int)(Target.sprite.Rect[Anim[num].num].Height * scale);

            Rectangle dest = new Rectangle(x1, y1, width, height);
            g.DrawImage(Target.image, dest, Target.sprite.Rect[Anim[num].num], GraphicsUnit.Pixel);
            rect = dest;
        }

        public void DrawSprite(Graphics g, float x, float y, int motion, int frame, float scalex, float scaley, float alpha, float angle)
        {
            if (motion < 0 || motion >= TotalMotion) return;
            if (frame < 0 || frame >= Motion[motion].count) return;

            int num = Motion[motion].start + frame;

            if (num < 0 || num >= TotalFrame || Anim[num].num < 0) return;

            int x1 = (int)(x + (Anim[num].sx * scalex));
            int y1 = (int)(y + (Anim[num].sy * scaley));
            int width = (int)(Target.sprite.Rect[Anim[num].num].Width * scalex);
            int height = (int)(Target.sprite.Rect[Anim[num].num].Height * scaley);

            Rectangle dest = new Rectangle(x1, y1, width, height);

            ColorMatrix matrix = new ColorMatrix();
            matrix.Matrix33 = alpha;
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            g.TranslateTransform(x, y);
            g.RotateTransform(angle);
            g.TranslateTransform(-x, -y);
            g.DrawImage(Target.image, dest, Target.sprite.Rect[Anim[num].num].Left, Target.sprite.Rect[Anim[num].num].Top, Target.sprite.Rect[Anim[num].num].Width, Target.sprite.Rect[Anim[num].num].Height, GraphicsUnit.Pixel, attributes);
            g.ResetTransform();

            rect = dest;
        }

        public void DrawSprite(Microsoft.DirectX.Direct3D.Sprite sprite, float x, float y, int motion, int frame, float scalex, float scaley, float alpha, float angle)
        {
            if (motion < 0 || motion >= TotalMotion) return;
            if (frame < 0 || frame >= Motion[motion].count) return;

            int num = Motion[motion].start + frame;

            if (num < 0 || num >= TotalFrame || Anim[num].num < 0) return;

            int x1 = (int)(x + (Anim[num].sx * scalex));
            int y1 = (int)(y + (Anim[num].sy * scaley));
            int width = (int)(Target.sprite.Rect[Anim[num].num].Width * scalex);
            int height = (int)(Target.sprite.Rect[Anim[num].num].Height * scaley);

            Point center = new Point(-Anim[num].sx + Anim[num].dx, -Anim[num].sy + Anim[num].dy);
            Rectangle sour = new Rectangle(Target.sprite.Rect[Anim[num].num].X, Target.sprite.Rect[Anim[num].num].Y, Target.sprite.Rect[Anim[num].num].Width + 1, Target.sprite.Rect[Anim[num].num].Height + 1);
            drawsprite(sprite, Target.texture, sour, center, angle, new Point((int)x + Anim[num].dx, (int)y + Anim[num].dy), scalex, scaley, Color.FromArgb((int)(alpha * 255), Color.White));

            rect = new Rectangle(x1, y1, width, height);
        }

        public void drawsprite(Microsoft.DirectX.Direct3D.Sprite sprite, Microsoft.DirectX.Direct3D.Texture texture, Rectangle dimension, Point rotationCenter, float rotationAngle, Point position, float sx, float sy, Color color)
        {
            sprite.Transform = Matrix.Scaling(sx, sy, 0) * Matrix.RotationZ((float)(Math.PI * rotationAngle / 180.0)) * Matrix.Translation(position.X, position.Y, 0);
            sprite.Draw(texture, dimension, new Vector3(rotationCenter.X, rotationCenter.Y, 0), new Vector3(0, 0, 0), color);
        }
    }
}
