using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace ParticleEditor_Proto
{
    public class Sprite
    {
        public Image image = null;
        public Microsoft.DirectX.Direct3D.Texture texture = null;

        public SpriteRect sprite = null;
        public string image_name = null, filename = null, pathname = null;

        public Sprite(int total)
        {
            sprite = new SpriteRect(total);
            Clear();
        }

        public void Clear()
        {
            sprite.Clear();
        }

        public string ByteToString(byte[] temp)
        {
            int i;
            for (i = 0; i < temp.Length; i++) if (temp[i] == 0) break;
            return System.Text.Encoding.Default.GetString(temp, 0, i);
        }

        public byte[] IntToByte(int val)
        {
            byte[] temp = new byte[4];
            temp[3] = (byte)((val & 0xff000000) >> 24);
            temp[2] = (byte)((val & 0x00ff0000) >> 16);
            temp[1] = (byte)((val & 0x0000ff00) >> 8);
            temp[0] = (byte)((val & 0x000000ff));
            return temp;
        }

        public void LoadImage(string fname)
        {
            for (int k = fname.Length - 1; k >= 0; k--)
            {
                if (fname[k].Equals('\\'))
                {
                    image_name = fname.Substring(k + 1, fname.Length - k - 1);
                    break;
                }
            }
            if (image != null) image.Dispose();

            image = Image.FromFile(fname);
        }

        public void LoadTexture(Device m_device, string fname)
        {
            for (int k = fname.Length - 1; k >= 0; k--)
            {
                if (fname[k].Equals('\\'))
                {
                    image_name = fname.Substring(k + 1, fname.Length - k - 1);
                    break;
                }
            }
            if (texture != null) texture.Dispose();

            texture = TextureLoader.FromFile(m_device, fname, 0, 0, 1, Usage.None, Format.Unknown, Pool.Managed, Filter.None, Filter.None, Color.Magenta.ToArgb());
        }

        public void Load(string fname)
        {
            using (FileStream fs = File.OpenRead(fname))
            {
                Clear();

                for (int k = fname.Length - 1; k >= 0; k--)
                {
                    if (fname[k].Equals('\\'))
                    {
                        pathname = fname.Substring(0, k);
                        filename = fname.Substring(k + 1, fname.Length - k - 1);
                        break;
                    }
                }
                byte[] buffer = new byte[20], value = new byte[4];

                fs.Read(buffer, 0, 20);

                image_name = ByteToString(buffer);
                LoadImage(pathname + '\\' + image_name);

                fs.Read(value, 0, 4);
                int count = BitConverter.ToInt32(value, 0);

                for (int i = 0; i < count; i++)
                {
                    fs.Read(value, 0, 4); sprite.Rect[sprite.Count].X = BitConverter.ToInt32(value, 0);
                    fs.Read(value, 0, 4); sprite.Rect[sprite.Count].Y = BitConverter.ToInt32(value, 0);
                    fs.Read(value, 0, 4); sprite.Rect[sprite.Count].Width = BitConverter.ToInt32(value, 0) - sprite.Rect[sprite.Count].X;
                    fs.Read(value, 0, 4); sprite.Rect[sprite.Count].Height = BitConverter.ToInt32(value, 0) - sprite.Rect[sprite.Count].Y;

                    sprite.Add(sprite.Count);
                }
                sprite.Rect[sprite.Count].Width = sprite.Rect[sprite.Count].Height = 0;
                fs.Close();
            }
        }

        public void LoadDX(Device m_device, string fname)
        {
            // 파일이 없을때 예외처리 있어야 함...
            using (FileStream fs = File.OpenRead(fname))
            {
                Clear();

                for (int k = fname.Length - 1; k >= 0; k--)
                {
                    if (fname[k].Equals('\\'))
                    {
                        pathname = fname.Substring(0, k);
                        filename = fname.Substring(k + 1, fname.Length - k - 1);
                        break;
                    }
                }
                byte[] buffer = new byte[20], value = new byte[4];

                fs.Read(buffer, 0, 20);

                image_name = ByteToString(buffer);
                LoadTexture(m_device, pathname + '\\' + image_name);

                fs.Read(value, 0, 4);
                int count = BitConverter.ToInt32(value, 0);

                for (int i = 0; i < count; i++)
                {
                    fs.Read(value, 0, 4); sprite.Rect[sprite.Count].X = BitConverter.ToInt32(value, 0);
                    fs.Read(value, 0, 4); sprite.Rect[sprite.Count].Y = BitConverter.ToInt32(value, 0);
                    fs.Read(value, 0, 4); sprite.Rect[sprite.Count].Width = BitConverter.ToInt32(value, 0) - sprite.Rect[sprite.Count].X;
                    fs.Read(value, 0, 4); sprite.Rect[sprite.Count].Height = BitConverter.ToInt32(value, 0) - sprite.Rect[sprite.Count].Y;

                    sprite.Add(sprite.Count);
                }
                sprite.Rect[sprite.Count].Width = sprite.Rect[sprite.Count].Height = 0;
                fs.Close();
            }
        }
    }
}
