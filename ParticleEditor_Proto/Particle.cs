using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace ParticleEditor_Proto
{
    public class Effect
    {
        public int sprite = 0, type = 0, width = 1, height = 1, count = 1, motion = 0, power = 0, range = 0, gravity = 0, dead = 0, alpha = 0;
        public float frame = 0, speed = 0, amount = 0, scalex = 1.0f, scaley = 1.0f, trans = 1.0f, angle = 0, zoomx = 0, zoomy = 0, blend = 0, horizon = 0, rotate = 0;
        public bool loop = true;
    }

    public class Particle
    {
        public string pathname, filename = null, rootpath = "";

        public float[] SinTBL = new float[360], CosTBL = new float[360];

        public Sprite[] sprArray = new Sprite[100];
        public Animation[] aniArray = new Animation[100];

        public List<Effect> effect = new List<Effect>();
        public int TotalPattern = 0;

        public List<string> namelist = new List<string>();


        public Particle()
        {
            for (int i = 0; i < 360; i++)
            {
                SinTBL[i] = (float)Math.Sin((double)i * 0.0174532925);
                CosTBL[i] = (float)Math.Cos((double)i * 0.0174532925);
            }
        }

        public void AddSprite(Microsoft.DirectX.Direct3D.Device m_device, string fname)
        {
            sprArray[TotalPattern] = null;
            aniArray[TotalPattern] = null;

            sprArray[TotalPattern] = new Sprite(10000);
            aniArray[TotalPattern] = new Animation(sprArray[TotalPattern], 10000);

            sprArray[TotalPattern].LoadDX(m_device, fname);
            aniArray[TotalPattern].Load(fname);

            TotalPattern++;
        }

        public void DrawParticle(PaintEventArgs e, float x, float y, GameObject temp, double DeltaTime)
        {
            temp.frame += temp.speed * (float)DeltaTime;

            if (temp.frame >= aniArray[temp.pattern].Motion[temp.motion].count)
            {
                temp.frame = temp.loop == 1 ? 0 : aniArray[temp.pattern].Motion[temp.motion].count - 1;
            }
            aniArray[temp.pattern].DrawSprite(e.Graphics, x, y, temp.motion, (int)temp.frame, temp.scalex, temp.scaley, temp.trans, temp.angle);

            temp.x += temp.horizon * (float)DeltaTime;
            temp.angle += temp.rotate * (float)DeltaTime;

            temp.trans += temp.blend * (float)DeltaTime;

            if (temp.trans < 0) temp.trans = 0;
            if (temp.trans > 1) temp.trans = 1;

            if (temp.type == (int)EffectType.NORMAL)
            {
                if (temp.amount > 0)
                {
                    temp.y -= (temp.power / 100) * (float)DeltaTime;
                    temp.power -= temp.amount * (float)DeltaTime;
                }
            }
            else if (temp.type == (int)EffectType.DIFFUSION)
            {
                temp.x += (SinTBL[(int)temp.direct] * temp.power / 100) * (float)DeltaTime;
                temp.y -= (CosTBL[(int)temp.direct] * temp.power / 100) * (float)DeltaTime;
                temp.power -= temp.amount * (float)DeltaTime;
                if (temp.power < 100) temp.power = 100;
            }
            else if (temp.type == (int)EffectType.DIRECTION)
            {
                temp.x += (SinTBL[(int)temp.direct] * temp.power / 100) * (float)DeltaTime;
                temp.y -= (CosTBL[(int)temp.direct] * temp.power / 100) * (float)DeltaTime;
                temp.power -= temp.amount * (float)DeltaTime;
                if (temp.power < 100) temp.power = 100;
            }
            else if (temp.type == (int)EffectType.BUBBLE)
            {
                if (temp.move++ % 20 < 10) temp.Zoom(0.005f, 0.005f); else temp.Zoom(-0.005f, -0.005f);

                if (temp.power > 100)
                {
                    temp.x += (SinTBL[(int)temp.angle] * temp.power / 100) * (float)DeltaTime;
                    temp.y -= (CosTBL[(int)temp.angle] * temp.power / 100) * (float)DeltaTime;

                    temp.power -= temp.amount * (float)DeltaTime;
                    if (temp.power < 100) temp.power = 100;
                }
                temp.y -= 1.0f * (float)DeltaTime;
            }
            else if (temp.type == (int)EffectType.CLOUD)
            {
                temp.x += (SinTBL[(int)temp.speed] * temp.power / 100) * (float)DeltaTime;
                temp.y -= (CosTBL[(int)temp.speed] * temp.power / 100) * (float)DeltaTime;
                temp.power -= temp.amount * (float)DeltaTime;
                if (temp.power < 100) temp.power = 100;
            }
            temp.scalex += temp.mx * (float)DeltaTime;
            if (temp.mx < 0 && temp.scalex < 0) temp.scalex = 0;

            temp.scaley += temp.my * (float)DeltaTime;
            if (temp.my < 0 && temp.scaley < 0) temp.scaley = 0;
        }

        public void DrawParticle(Microsoft.DirectX.Direct3D.Sprite sprite, float x, float y, GameObject temp)
        {
            temp.frame += temp.speed;

            if (temp.frame >= aniArray[temp.pattern].Motion[temp.motion].count)
            {
                temp.frame = temp.loop == 1 ? 0 : aniArray[temp.pattern].Motion[temp.motion].count - 1;
            }
            aniArray[temp.pattern].DrawSprite(sprite, x, y, temp.motion, (int)temp.frame, temp.scalex, temp.scaley, temp.trans, temp.angle);

            temp.x += temp.horizon;
            temp.angle += temp.rotate;

            temp.trans += temp.blend;

            if (temp.trans < 0) temp.trans = 0;
            if (temp.trans > 1) temp.trans = 1;

            if (temp.type == (int)EffectType.NORMAL)
            {
                if (temp.amount > 0)
                {
                    temp.y -= (temp.power / 100);
                    temp.power -= temp.amount;
                }
            }
            else if (temp.type == (int)EffectType.DIFFUSION)
            {
                temp.x += (SinTBL[(int)temp.direct] * temp.power / 100);
                temp.y -= (CosTBL[(int)temp.direct] * temp.power / 100);
                temp.power -= temp.amount;
                if (temp.power < 100) temp.power = 100;
            }
            else if (temp.type == (int)EffectType.DIRECTION)
            {
                temp.x += (SinTBL[(int)temp.direct] * temp.power / 100);
                temp.y -= (CosTBL[(int)temp.direct] * temp.power / 100);
                temp.power -= temp.amount;
                if (temp.power < 100) temp.power = 100;
            }
            else if (temp.type == (int)EffectType.BUBBLE)
            {
                if (temp.move++ % 20 < 10) temp.Zoom(0.005f, 0.005f); else temp.Zoom(-0.005f, -0.005f);

                if (temp.power > 100)
                {
                    temp.x += (SinTBL[(int)temp.angle] * temp.power / 100);
                    temp.y -= (CosTBL[(int)temp.angle] * temp.power / 100);

                    temp.power -= temp.amount;
                    if (temp.power < 100) temp.power = 100;
                }
                temp.y -= 1.0f;
            }
            else if (temp.type == (int)EffectType.CLOUD)
            {
                temp.x += (SinTBL[(int)temp.speed] * temp.power / 100);
                temp.y -= (CosTBL[(int)temp.speed] * temp.power / 100);
                temp.power -= temp.amount;
                if (temp.power < 100) temp.power = 100;
            }
            temp.scalex += temp.mx;
            if (temp.mx < 0 && temp.scalex < 0) temp.scalex = 0;

            temp.scaley += temp.my;
            if (temp.my < 0 && temp.scaley < 0) temp.scaley = 0;
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

        public void LoadEffectFile(Microsoft.DirectX.Direct3D.Device m_device, string strProgrampath)
        {
            if (strProgrampath == null) return;

            for (int k = strProgrampath.Length - 1; k >= 0; k--)
            {
                if (strProgrampath[k].Equals('\\'))
                {
                    pathname = strProgrampath.Substring(0, k);
                    filename = strProgrampath.Substring(k + 1, strProgrampath.Length - k - 1);
                    break;
                }
            }

            using (FileStream fs = File.OpenRead(strProgrampath))
            {
                rootpath = pathname;

                effect.Clear();
                TotalPattern = 0;

                byte[] buffer = new byte[20], value = new byte[4];

                fs.Read(value, 0, 4);
                int total = BitConverter.ToInt32(value, 0);

                namelist.Clear();

                for (int i = 0; i < total; i++)
                {
                    fs.Read(buffer, 0, 20);
                    string fname = ByteToString(buffer);
                    namelist.Add(fname);
                    AddSprite(m_device, pathname + '\\' + fname);
                }
                fs.Read(value, 0, 4);
                int totaleffect = BitConverter.ToInt32(value, 0);

                for (int i = 0; i < totaleffect; i++)
                {
                    Effect temp = new Effect();
                    fs.Read(value, 0, 4); temp.type = BitConverter.ToInt32(value, 0);
                    fs.Read(value, 0, 4); temp.sprite = BitConverter.ToInt32(value, 0);
                    fs.Read(value, 0, 4); temp.width = BitConverter.ToInt32(value, 0);
                    fs.Read(value, 0, 4); temp.height = BitConverter.ToInt32(value, 0);
                    fs.Read(value, 0, 4); temp.count = BitConverter.ToInt32(value, 0);
                    fs.Read(value, 0, 4); temp.motion = BitConverter.ToInt32(value, 0);
                    fs.Read(value, 0, 4); temp.frame = BitConverter.ToInt32(value, 0);
                    fs.Read(value, 0, 4); temp.speed = (float)BitConverter.ToInt32(value, 0) / 1000;
                    fs.Read(value, 0, 4); temp.scalex = (float)BitConverter.ToInt32(value, 0) / 1000;
                    fs.Read(value, 0, 4); temp.scaley = (float)BitConverter.ToInt32(value, 0) / 1000;
                    fs.Read(value, 0, 4); temp.zoomx = (float)BitConverter.ToInt32(value, 0) / 1000;
                    fs.Read(value, 0, 4); temp.zoomy = (float)BitConverter.ToInt32(value, 0) / 1000;
                    fs.Read(value, 0, 4); temp.trans = (float)BitConverter.ToInt32(value, 0) / 1000;
                    fs.Read(value, 0, 4); temp.angle = (float)BitConverter.ToInt32(value, 0) / 1000;
                    fs.Read(value, 0, 4); temp.loop = BitConverter.ToInt32(value, 0) == 1 ? true : false;
                    fs.Read(value, 0, 4); temp.dead = BitConverter.ToInt32(value, 0);
                    fs.Read(value, 0, 4); temp.power = BitConverter.ToInt32(value, 0);
                    fs.Read(value, 0, 4); temp.gravity = BitConverter.ToInt32(value, 0);
                    fs.Read(value, 0, 4); temp.range = BitConverter.ToInt32(value, 0);
                    fs.Read(value, 0, 4); temp.blend = (float)BitConverter.ToInt32(value, 0) / 1000;
                    fs.Read(value, 0, 4); temp.horizon = (float)BitConverter.ToInt32(value, 0) / 1000;
                    fs.Read(value, 0, 4); temp.rotate = (float)BitConverter.ToInt32(value, 0) / 1000;
                    fs.Read(value, 0, 4); temp.alpha = BitConverter.ToInt32(value, 0);
                    effect.Add(temp);
                }
                fs.Close();
            }
        }

        public void SaveEffectFile(string strProgrampath)
        {
            using (FileStream fs = File.OpenWrite(strProgrampath))
            {
                byte[] buffer = new byte[20];

                fs.Write(IntToByte(TotalPattern), 0, 4);

                for (int i = 0; i < TotalPattern; i++)
                {
                    byte[] temp = System.Text.Encoding.ASCII.GetBytes(sprArray[i].filename);
                    for (int k = 0; k < 20; k++) if (k < temp.Length) buffer[k] = temp[k]; else buffer[k] = 0;
                    fs.Write(buffer, 0, 20);
                }
                fs.Write(IntToByte(effect.Count), 0, 4); // 총 이펙트 개수

                for (int i = 0; i < effect.Count; i++)
                {
                    fs.Write(IntToByte(effect[i].type), 0, 4);
                    fs.Write(IntToByte(effect[i].sprite), 0, 4);
                    fs.Write(IntToByte(effect[i].width), 0, 4);
                    fs.Write(IntToByte(effect[i].height), 0, 4);
                    fs.Write(IntToByte(effect[i].count), 0, 4);
                    fs.Write(IntToByte(effect[i].motion), 0, 4);
                    fs.Write(IntToByte((int)effect[i].frame), 0, 4);
                    fs.Write(IntToByte((int)(effect[i].speed * 1000)), 0, 4);
                    fs.Write(IntToByte((int)(effect[i].scalex * 1000)), 0, 4);
                    fs.Write(IntToByte((int)(effect[i].scaley * 1000)), 0, 4);
                    fs.Write(IntToByte((int)(effect[i].zoomx * 1000)), 0, 4);
                    fs.Write(IntToByte((int)(effect[i].zoomy * 1000)), 0, 4);
                    fs.Write(IntToByte((int)(effect[i].trans * 1000)), 0, 4);
                    fs.Write(IntToByte((int)(effect[i].angle * 1000)), 0, 4);
                    fs.Write(IntToByte(effect[i].loop ? 1 : 0), 0, 4);
                    fs.Write(IntToByte(effect[i].dead), 0, 4);
                    fs.Write(IntToByte(effect[i].power), 0, 4);
                    fs.Write(IntToByte(effect[i].gravity), 0, 4);
                    fs.Write(IntToByte(effect[i].range), 0, 4);
                    fs.Write(IntToByte((int)(effect[i].blend * 1000)), 0, 4);
                    fs.Write(IntToByte((int)(effect[i].horizon * 1000)), 0, 4);
                    fs.Write(IntToByte((int)(effect[i].rotate * 1000)), 0, 4);
                    fs.Write(IntToByte(effect[i].alpha), 0, 4);
                }
                fs.Close();
            }
        }

        Random MyRand = new Random();

        public void MakeEffect(int num, int x, int y, List<GameObject> array)
        {
            if (num < effect.Count)
            {
                Effect eff = effect[num];

                for (int i = 0; i < eff.count; i++)
                {
                    float px = x, py = y;
                    GameObject temp = new GameObject();

                    if (eff.width >= 2) px -= MyRand.Next(eff.width + 1) - eff.width / 2;
                    if (eff.height >= 2) py -= MyRand.Next(eff.height + 1) - eff.height / 2;

                    temp.SetObject(eff.sprite, eff.type, px, py, eff.motion, eff.frame, eff.scalex, eff.scaley, eff.speed, eff.amount, eff.trans, eff.angle, eff.loop, eff.dead);
                    temp.power = eff.power + MyRand.Next(eff.range);
                    temp.amount = eff.gravity;
                    temp.mx = eff.zoomx;
                    temp.my = eff.zoomy;
                    temp.horizon = eff.horizon;
                    temp.blend = eff.blend;
                    temp.rotate = eff.rotate;
                    temp.timer = DateTime.Now.Ticks + eff.dead * 10000;

                    if (eff.type != (int)EffectType.CLOUD && eff.horizon != 0)
                    {
                        int val = (int)(eff.horizon * 100);
                        temp.horizon = (float)(MyRand.Next(val + 1) - (val / 2)) / 100;
                    }
                    if (temp.type == (int)EffectType.DIFFUSION) temp.direct = MyRand.Next(360);
                    if (temp.type == (int)EffectType.DIRECTION) temp.direct = temp.angle;

                    array.Add(temp);
                }
            }
        }
    }
}
