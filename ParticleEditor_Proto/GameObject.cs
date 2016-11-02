using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;

namespace ParticleEditor_Proto
{
    public class GameObject
    {
        public class ActType
        {
            public static int REMOVE = 0;
            public static int REMOVEONARRIVAL = 1;
            public static int REMOVEFIRSTFRAME = 2;
            public static int REMOVELASTFRAME = 3;
            public static int REMOVEBOXCOLLISION = 4;
            public static int REMOVECIRCLECOLLISION = 5;
            public static int REMOVERECTOVER = 6;
            public static int REMOVERECTUNDER = 7;

            public static int MOVELINEAR = 20;
            public static int MOVEACCELERATE = 21;
            public static int MOVEDECELERATE = 22;
            public static int MOVEPATH = 23;
            public static int ADDFRAMELOOP = 24;
            public static int SUBFRAMELOOP = 25;
            public static int ADDFRAME = 26;
            public static int SUBFRAME = 27;
            public static int ZOOM = 28;
            public static int MOTION = 29;
            public static int MOTIONRECT = 30;
            public static int MOTIONBOXCOLLISION = 31;
            public static int MOTIONCIRCLECOLLISION = 32;
            public static int TRANSIN = 33;
            public static int TRANSOUT = 34;
            public static int ANGLE = 35;
            public static int SETZOOM = 36;
            public static int HIDE = 37;
            public static int SHAKE = 38;
            public static int MOVEAXIS = 39;
            public static int MOVEANGLE = 40;
            public static int JUMPING = 41;
            public static int AUTOPLAY = 42;
            public static int MOVEPOS = 43;
            public static int PLAY = 44;
            public static int SCROLL = 45;
        }
        public ArrayList ActList = new ArrayList();

        public class ActData
        {
            public int type, motion, auto;
            public long timer, delay, removetimer;
            public float radius, speed, angle, framerate, xratio, yratio;
            public Rectangle bounds;
            public GameObject target;
            public float x, y, power, gravity;
            public bool loop = false, first = false;
        }

        public void Remove(long millseconds)
        {
            ActData temp = new ActData();
            temp.timer = DateTime.Now.Ticks + (millseconds * 10000);
            temp.type = ActType.REMOVE;
            ActList.Add(temp);
        }

        public void MoveLinear(float tx, float ty, float movespeed, long delay)
        {
            //if ( (int)tx != (int)x || (int)ty != (int)y )
            {
                ActData temp = new ActData();
                temp.type = ActType.MOVELINEAR;
                temp.x = tx;
                temp.y = ty;
                temp.speed = movespeed;
                temp.delay = DateTime.Now.Ticks + (delay * 10000);
                ActList.Add(temp);
            }
        }

        public void MoveDecelerate(float tx, float ty, float power, long delay)
        {
            //if ( (int)tx != (int)x || (int)ty != (int)y )
            {
                ActData temp = new ActData();
                temp.type = ActType.MOVEDECELERATE;
                temp.x = tx;
                temp.y = ty;
                temp.power = power;
                temp.delay = DateTime.Now.Ticks + (delay * 10000);
                ActList.Add(temp);
            }
        }

        public void MovePosition(float tx, float ty, long delay)
        {
            //if ((int)tx != (int)x || (int)ty != (int)y)
            {
                ActData temp = new ActData();
                temp.type = ActType.MOVEPOS;
                temp.x = tx;
                temp.y = ty;
                temp.delay = DateTime.Now.Ticks + (delay * 10000);
                ActList.Add(temp);
            }
        }

        public void MoveRolling(float xspeed, float yspeed, int xsize, int ysize)
        {
            ActData temp = new ActData();
            temp.type = ActType.SCROLL;
            temp.x = xspeed;
            temp.y = yspeed;
            temp.xratio = xsize;
            temp.yratio = ysize;
            ActList.Add(temp);
        }

        public void PlayAni(long duration, long delay)
        {
            ActData temp = new ActData();
            temp.type = ActType.PLAY;
            temp.timer = duration == 0 ? 0 : DateTime.Now.Ticks + ((delay + duration) * 10000);
            temp.delay = DateTime.Now.Ticks + (delay * 10000);
            temp.loop = loop == 0 ? false : true;
            temp.auto = auto;
            ActList.Add(temp);
            temp = null;
        }

        public void Zoom(float xratio, float yratio, long duration, long delay)
        {
            ActData temp = new ActData();
            temp.type = ActType.ZOOM;
            temp.xratio = xratio;
            temp.yratio = yratio;
            temp.timer = duration == 0 ? 0 : DateTime.Now.Ticks + ((delay + duration) * 10000);
            temp.delay = DateTime.Now.Ticks + (delay * 10000);
            ActList.Add(temp);
            temp = null;
        }

        public void TransIn(long duration, long delay)
        {
            ActData temp = new ActData();
            temp.type = ActType.TRANSIN;
            temp.delay = DateTime.Now.Ticks + (delay * 10000);
            temp.timer = duration * 10000;
            ActList.Add(temp);
            temp = null;
        }

        public void TransOut(long duration, long delay)
        {
            ActData temp = new ActData();
            temp.type = ActType.TRANSOUT;
            temp.delay = DateTime.Now.Ticks + (delay * 10000);
            temp.timer = duration * 10000;
            ActList.Add(temp);
            temp = null;
        }

        public void Angle(float value, long duration, long delay)
        {
            ActData temp = new ActData();
            temp.type = ActType.ANGLE;
            temp.framerate = value;
            temp.delay = DateTime.Now.Ticks + (delay * 10000);
            temp.timer = duration * 10000;
            ActList.Add(temp);
            temp = null;
        }

        public int x1, y1, x2, y2;
        public int pattern = 0, type = 0, unique = 0, motion = 0, effect = 0, energy = 100, show = 1, drag = 0, move = 0, auto = 1, loop = 1, dead = 0, particle = -1, period = 100, answer = 0;
        public float mx, my, ox, oy, x = 0, y = 0, frame, speed = 0, trans = 1.0f, scalex = 1.0f, scaley = 1.0f, angle = 0, power = 0, delay = 0, direct = 0, amount = 0, blend = 0, horizon = 0;
        public float osx = 0, osy = 0, rotate = 0, saveangle = 0;
        public byte[,] soundname = new byte[10, 20];
        public bool select = false, remove = false, click = false, disable = false;
        public long timer, ptimer;
        public int qtype, qcount, correct;
        public Rectangle rect;

        public GameObject target = null;


        public GameObject()
        {
            Init();
            rect = new Rectangle();
        }

        public void Init()
        {
            pattern = 0;
            type = 0;
            unique = 0;
            x = 0;
            y = 0;
            motion = 0;
            frame = 0;
            speed = 0;
            effect = 0;
            trans = 1.0f;
            energy = 100;
            scalex = 1.0f;
            scaley = 1.0f;
            x1 = y1 = x2 = y2 = 0;
            angle = 0;
            select = false;
            target = null;

            rect.Width = 0;
            rect.Height = 0;

            ptimer = DateTime.Now.Ticks;

            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 20; k++) soundname[i, k] = 0;
            }
            show = 1;
            drag = 0;

            ActList.Clear();
        }

        public void SetObject(int _sprnum, int _type, float _x, float _y, int _motion, float _frame, float _sx, float _sy, float _speed, float _amount, float _trans, float _angle, bool _loop, int _dead)
        {
            Init();

            pattern = _sprnum;
            type = _type;
            x = ox = _x;
            y = oy = _y;
            motion = _motion;
            frame = _frame;
            scalex = _sx;
            scaley = _sy;
            speed = _speed;
            amount = _amount;
            trans = _trans;
            angle = _angle;
            loop = _loop ? 1 : 0;
            dead = _dead;
        }

        public void CopyTo(GameObject target)
        {
            target.pattern = this.pattern;
            target.type = this.type;
            target.unique = this.unique;
            target.ox = this.ox;
            target.oy = this.oy;
            target.x = this.x;
            target.y = this.y;
            target.motion = this.motion;
            target.frame = this.frame;
            target.speed = this.speed;
            target.effect = this.effect;
            target.drag = this.drag;
            target.trans = this.trans;
            target.energy = this.energy;
            target.scalex = this.scalex;
            target.scaley = this.scaley;
            target.show = this.show;
            target.x1 = this.x1;
            target.y1 = this.y1;
            target.x2 = this.x2;
            target.y2 = this.y2;
            target.select = this.select;
            target.angle = this.angle;
            target.auto = this.auto;
            target.loop = this.loop;
            target.delay = this.delay;
            target.direct = this.direct;
            target.power = this.power;
            target.move = this.move;
            target.amount = this.amount;
            target.rect = this.rect;
            target.qtype = this.qtype;
            target.qcount = this.qcount;
            target.correct = this.correct;
            target.target = this.target;

            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 20; k++) target.soundname[i, k] = soundname[i, k];
            }
        }

        public void Zoom(float sx, float sy)
        {
            scalex += sx;
            scaley += sy;
        }

        private byte[] IntToByte(int val)
        {
            byte[] temp = new byte[4];
            temp[3] = (byte)((val & 0xff000000) >> 24);
            temp[2] = (byte)((val & 0x00ff0000) >> 16);
            temp[1] = (byte)((val & 0x0000ff00) >> 8);
            temp[0] = (byte)((val & 0x000000ff));
            return temp;
        }

        public byte[] GetByte72()
        {
            int offset = 0;
            byte[] data = new byte[72];

            Buffer.BlockCopy(IntToByte(pattern), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(type), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(unique), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte((int)x), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte((int)y), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(motion), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte((int)frame), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte((int)(speed * 100)), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(effect), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte((int)(trans * 100)), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(energy), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte((int)(scalex * 100)), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte((int)(scaley * 100)), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(show), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(x1), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(y1), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(x2), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(y2), 0, data, offset, 4); offset += 4;

            return data;
        }

        public void FromByte72(byte[] temp)
        {
            int offset = 0;

            pattern = BitConverter.ToInt32(temp, offset); offset += 4;
            type = BitConverter.ToInt32(temp, offset); offset += 4;
            unique = BitConverter.ToInt32(temp, offset); offset += 4;
            x = BitConverter.ToInt32(temp, offset); offset += 4;
            y = BitConverter.ToInt32(temp, offset); offset += 4;
            motion = BitConverter.ToInt32(temp, offset); offset += 4;
            frame = BitConverter.ToInt32(temp, offset); offset += 4;
            speed = (float)BitConverter.ToInt32(temp, offset) / 100; offset += 4;
            effect = BitConverter.ToInt32(temp, offset); offset += 4;
            trans = (float)BitConverter.ToInt32(temp, offset) / 100; offset += 4;
            energy = BitConverter.ToInt32(temp, offset); offset += 4;
            scalex = (float)BitConverter.ToInt32(temp, offset) / 100; offset += 4;
            scaley = (float)BitConverter.ToInt32(temp, offset) / 100; offset += 4;
            show = BitConverter.ToInt32(temp, offset); offset += 4;
            x1 = BitConverter.ToInt32(temp, offset); offset += 4;
            y1 = BitConverter.ToInt32(temp, offset); offset += 4;
            x2 = BitConverter.ToInt32(temp, offset); offset += 4;
            y2 = BitConverter.ToInt32(temp, offset); offset += 4;
        }


        public byte[] GetByte308() // 저장할때
        {
            int offset = 0;
            byte[] data = new byte[308];

            Buffer.BlockCopy(IntToByte(pattern), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(type), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(unique), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte((int)x), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte((int)y), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(motion), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte((int)frame), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte((int)(speed * 100)), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte((int)(amount * 100)), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(drag), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte((int)(trans * 100)), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(energy), 0, data, offset, 4); offset += 4; // unused
            Buffer.BlockCopy(IntToByte((int)(scalex * 100)), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte((int)(scaley * 100)), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte((int)(angle * 100)), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(show), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(auto), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(loop), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(particle), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(period), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(rect.X), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(rect.Y), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(rect.Width), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(rect.Height), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(qtype), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(qcount), 0, data, offset, 4); offset += 4;
            Buffer.BlockCopy(IntToByte(correct), 0, data, offset, 4); offset += 4;

            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 20; k++) data[offset++] = soundname[i, k];
            }
            return data;
        }

        public void FromByte308(byte[] temp) // 로딩할때
        {
            int offset = 0;

            pattern = BitConverter.ToInt32(temp, offset); offset += 4;
            type = BitConverter.ToInt32(temp, offset); offset += 4;
            unique = BitConverter.ToInt32(temp, offset); offset += 4;
            x = BitConverter.ToInt32(temp, offset); offset += 4;
            y = BitConverter.ToInt32(temp, offset); offset += 4;
            motion = BitConverter.ToInt32(temp, offset); offset += 4;
            frame = BitConverter.ToInt32(temp, offset); offset += 4;
            speed = (float)BitConverter.ToInt32(temp, offset) / 100; offset += 4;
            amount = (float)BitConverter.ToInt32(temp, offset) / 100; offset += 4;
            drag = BitConverter.ToInt32(temp, offset); offset += 4;
            trans = (float)BitConverter.ToInt32(temp, offset) / 100; offset += 4;
            energy = BitConverter.ToInt32(temp, offset); offset += 4; // unused
            scalex = (float)BitConverter.ToInt32(temp, offset) / 100; offset += 4;
            scaley = (float)BitConverter.ToInt32(temp, offset) / 100; offset += 4;
            angle = (float)BitConverter.ToInt32(temp, offset) / 100; offset += 4;
            show = BitConverter.ToInt32(temp, offset); offset += 4;
            auto = BitConverter.ToInt32(temp, offset); offset += 4;
            loop = BitConverter.ToInt32(temp, offset); offset += 4;
            particle = BitConverter.ToInt32(temp, offset); offset += 4;
            period = BitConverter.ToInt32(temp, offset); offset += 4;
            rect.X = BitConverter.ToInt32(temp, offset); offset += 4;
            rect.Y = BitConverter.ToInt32(temp, offset); offset += 4;
            rect.Width = BitConverter.ToInt32(temp, offset); offset += 4;
            rect.Height = BitConverter.ToInt32(temp, offset); offset += 4;
            qtype = BitConverter.ToInt32(temp, offset); offset += 4;
            qcount = BitConverter.ToInt32(temp, offset); offset += 4;
            correct = BitConverter.ToInt32(temp, offset); offset += 4;

            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 20; k++) soundname[i, k] = temp[offset++];
            }
        }

        public void SetSoundName(int num, string text)
        {
            byte[] temp = System.Text.Encoding.ASCII.GetBytes(text);
            for (int i = 0; i < 20; i++) if (i < temp.Length) soundname[num, i] = temp[i]; else soundname[num, i] = 0;
        }

        public string GetSoundName(int num)
        {
            int i;
            byte[] temp = new byte[20];
            for (i = 0; i < 20; i++) { temp[i] = soundname[num, i]; if (temp[i] == 0) break; }
            return Encoding.UTF8.GetString(temp, 0, i);
        }

        public void DoComponent(float sx, float sy, int screenx, int screeny)
        {
            long currentTimer = DateTime.Now.Ticks;

            for (int i = 0; i < ActList.Count; i++)
            {
                ActData temp = (ActData)ActList[i];

                if (temp.type == ActType.REMOVE)
                {
                    if (currentTimer >= temp.timer)
                    {
                        remove = true;
                        ActList.RemoveAt(i--);
                    }
                }
                else if (temp.type == ActType.PLAY)
                {
                    if (currentTimer >= temp.delay)
                    {
                        auto = loop = 1;

                        if (temp.timer > 0 && currentTimer >= temp.timer)
                        {
                            auto = temp.auto;
                            loop = temp.loop ? 1 : 0;
                            ActList.RemoveAt(i--);
                        }
                    }
                }
                else if (temp.type == ActType.ZOOM)
                {
                    if (currentTimer >= temp.delay)
                    {
                        Zoom(temp.xratio, temp.yratio);
                        if (temp.timer > 0 && currentTimer >= temp.timer) ActList.RemoveAt(i--);
                    }
                }
                else if (temp.type == ActType.TRANSIN)
                {
                    if (currentTimer >= temp.delay)
                    {
                        trans = Math.Min(1, (float)(currentTimer - temp.delay) / (float)temp.timer);
                        if (trans >= 1.0f) ActList.RemoveAt(i--);
                    }
                }
                else if (temp.type == ActType.TRANSOUT)
                {
                    if (currentTimer >= temp.delay)
                    {
                        trans = 1.0f - Math.Min(1, (float)(currentTimer - temp.delay) / (float)temp.timer);
                        if (trans <= 0) ActList.RemoveAt(i--);
                    }
                }
                else if (temp.type == ActType.ANGLE)
                {
                    if (currentTimer >= temp.delay)
                    {
                        angle += temp.framerate;
                        if (temp.timer > 0 && currentTimer >= temp.timer) ActList.RemoveAt(i--);
                    }
                }
                else if (temp.type == ActType.MOVELINEAR)
                {
                    if (currentTimer >= temp.delay)
                    {
                        if (MovetoPos(temp.x, temp.y, temp.speed)) ActList.RemoveAt(i--);
                    }
                }
                else if (temp.type == ActType.MOVEDECELERATE)
                {
                    if (currentTimer >= temp.delay)
                    {
                        x += (temp.x - x) / temp.power;
                        y += (temp.y - y) / temp.power;

                        if ((int)temp.x == (int)x && (int)temp.y == (int)y) ActList.RemoveAt(i--);
                    }
                }
                else if (temp.type == ActType.MOVEPOS)
                {
                    if (currentTimer >= temp.delay)
                    {
                        x = temp.x;
                        y = temp.y;

                        if ((int)temp.x == (int)x && (int)temp.y == (int)y) ActList.RemoveAt(i--);
                    }
                }
                else if (temp.type == ActType.SCROLL)
                {
                    if (temp.x < 0)
                    {
                        x += temp.x;
                        if (x + rect.Width < sx) x += temp.xratio;
                    }
                    if (temp.x > 0)
                    {
                        x += temp.x;
                        if (x >= sx + screenx) x -= temp.xratio;
                    }
                    if (temp.y < 0)
                    {
                        y += temp.y;
                        if (y + rect.Height < sy) y += temp.yratio;
                    }
                    if (temp.y > 0)
                    {
                        y += temp.y;
                        if (y >= sy + screeny) y -= temp.yratio;
                    }
                }
            }
        }

        public double GetAngle(float targetx, float targety)
        {
            float distX = targetx - x;
            float distY = targety - y;

            double angle = ((Math.Atan2((double)distY, (double)distX) * 180) / 3.141592653589793) + 90;
            if (angle < 0) angle += 360;

            return angle;
        }

        public void MovebyAngle(float angle, float distance)
        {
            if (angle < 0) angle += 360;
            if (angle >= 360) angle -= 360;

            x += (float)Math.Sin(angle * 0.0174532925) * distance;
            y -= (float)Math.Cos(angle * 0.0174532925) * distance;
        }

        public bool MovetoPos(float tx, float ty, float distance)
        {
            float sx = x, sy = y;

            MovebyAngle((float)GetAngle(tx, ty), distance);

            if (sx < x)
            {
                if (x >= tx) x = tx;
            }
            else if (sx > x)
            {
                if (x <= tx) x = tx;
            }

            if (sy < y)
            {
                if (y >= ty) y = ty;
            }
            else if (sy > y)
            {
                if (y <= ty) y = ty;
            }
            if ((int)x == (int)tx && (int)y == (int)ty) return true; else return false;
        }

    }
}
