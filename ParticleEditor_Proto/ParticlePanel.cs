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
using System.Runtime.InteropServices;
using System.Media;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

enum EffectType
{
    NORMAL,
    DIFFUSION,
    BUBBLE,
    CLOUD,
    DIRECTION,
}

namespace ParticleEditor_Proto
{
    public partial class ParticlePanel : UserControl
    {
        public Device m_device = null;

        public ParticleEditor_Main owner = null;
        public Image background = null;

        public int ScreenX = 1280, ScreenY = 720;

        public bool LeftClick = false, RightClick = false, active = true, draw = true;

        private int MouseX = 0, MouseY = 0;

        public int CurrentEffect = 0;

        public Particle mypar = new Particle();
        public List<GameObject> gObject = new List<GameObject>();

        public ParticlePanel()
        {
            InitializeComponent();
            this.Focus();
        }

        public void InitGame()
        {
            //if (owner.owner.WindowState == FormWindowState.Minimized) return;

            PresentParameters pp = new PresentParameters();
            pp.Windowed = true;
            pp.SwapEffect = SwapEffect.Discard;

            if (m_device != null)
            {
                m_device.Reset(pp);
                return;
            }
            m_device = new Device(0, DeviceType.Hardware, this, CreateFlags.HardwareVertexProcessing, pp);
        }

        public void RunGame()
        {
            while (active)
            {
                DrawScreen();
                Application.DoEvents();
            }
        }

        public void AddNewEffect()
        {
            Effect temp = new Effect();
            mypar.effect.Add(temp);

            owner.numeric_number.Maximum = mypar.effect.Count - 1;
            SetCurrentInfo(mypar.effect.Count - 1);
        }

        public void SetCurrentInfo(int num)
        {
            owner.numeric_number.Value = num;
            //owner.combo_type.SelectedIndex = mypar.effect[num].type;
            owner.numeric_sprite.Value = mypar.effect[num].sprite;
            //owner.numeric_width.Value = mypar.effect[num].width;
            //owner.numeric_height.Value = mypar.effect[num].height;
            //owner.numeric_count.Value = mypar.effect[num].count;
            //owner.numeric_motion.Value = mypar.effect[num].motion;
            //owner.numeric_frame.Value = decimal.Parse(mypar.effect[num].frame.ToString());
            //owner.numeric_speed.Value = decimal.Parse(mypar.effect[num].speed.ToString());
            //owner.numeric_scalex.Value = decimal.Parse(mypar.effect[num].scalex.ToString());
            //owner.numeric_scaley.Value = decimal.Parse(mypar.effect[num].scaley.ToString());
            //owner.numeric_zoomx.Value = decimal.Parse(mypar.effect[num].zoomx.ToString());
            //owner.numeric_zoomy.Value = decimal.Parse(mypar.effect[num].zoomy.ToString());
            //owner.numeric_trans.Value = decimal.Parse(mypar.effect[num].trans.ToString());
            //owner.numeric_angle.Value = decimal.Parse(mypar.effect[num].angle.ToString());
            //owner.numeric_blend.Value = decimal.Parse(mypar.effect[num].blend.ToString());
            //owner.numeric_horizon.Value = decimal.Parse(mypar.effect[num].horizon.ToString());
            //owner.numeric_rotate.Value = decimal.Parse(mypar.effect[num].rotate.ToString());
            //owner.combo_loop.SelectedIndex = mypar.effect[num].loop ? 0 : 1;
            //owner.numeric_dead.Value = mypar.effect[num].dead;
            //owner.numeric_power.Value = mypar.effect[num].power;
            //owner.numeric_range.Value = mypar.effect[num].range;
            //owner.numeric_gravity.Value = mypar.effect[num].gravity;
            //owner.combo_alpha.SelectedIndex = mypar.effect[num].alpha;
        }

        public Effect GetCurrentInfo(int num)
        {
            //mypar.effect[num].type = (int)owner.combo_type.SelectedIndex;
            mypar.effect[num].sprite = (int)owner.numeric_sprite.Value;
            //mypar.effect[num].width = (int)owner.numeric_width.Value;
            //mypar.effect[num].height = (int)owner.numeric_height.Value;
            //mypar.effect[num].count = (int)owner.numeric_count.Value;
            //mypar.effect[num].motion = (int)owner.numeric_motion.Value;
            //mypar.effect[num].frame = (int)owner.numeric_frame.Value;
            //mypar.effect[num].speed = (float)owner.numeric_speed.Value;
            //mypar.effect[num].scalex = (float)owner.numeric_scalex.Value;
            //mypar.effect[num].scaley = (float)owner.numeric_scaley.Value;
            //mypar.effect[num].zoomx = (float)owner.numeric_zoomx.Value;
            //mypar.effect[num].zoomy = (float)owner.numeric_zoomy.Value;
            //mypar.effect[num].trans = (float)owner.numeric_trans.Value;
            //mypar.effect[num].angle = (float)owner.numeric_angle.Value;
            //mypar.effect[num].blend = (float)owner.numeric_blend.Value;
            //mypar.effect[num].horizon = (float)owner.numeric_horizon.Value;
            //mypar.effect[num].rotate = (float)owner.numeric_rotate.Value;
            //mypar.effect[num].loop = owner.combo_loop.SelectedIndex == 0 ? true : false;
            //mypar.effect[num].dead = (int)owner.numeric_dead.Value;
            //mypar.effect[num].power = (int)owner.numeric_power.Value;
            //mypar.effect[num].range = (int)owner.numeric_range.Value;
            //mypar.effect[num].gravity = (int)owner.numeric_gravity.Value;
            //mypar.effect[num].alpha = (int)owner.combo_alpha.SelectedIndex;

            return mypar.effect[num];
        }

        Random MyRand = new Random();

        public void MakeEffect()
        {
            Effect effect = GetCurrentInfo((int)owner.numeric_number.Value);

            for (int i = 0; i < effect.count; i++)
            {
                GameObject temp = new GameObject();

                float x = MouseX, y = MouseY;

                if (effect.width >= 2) x -= MyRand.Next(effect.width + 1) - effect.width / 2;
                if (effect.height >= 2) y -= MyRand.Next(effect.height + 1) - effect.height / 2;

                temp.SetObject(effect.sprite, effect.type, x, y, effect.motion, effect.frame, effect.scalex, effect.scaley, effect.speed, effect.amount, effect.trans, effect.angle, effect.loop, effect.dead);
                temp.power = effect.power + MyRand.Next(effect.range);
                temp.amount = effect.gravity;
                temp.mx = effect.zoomx;
                temp.my = effect.zoomy;
                temp.horizon = effect.horizon;
                temp.blend = effect.blend;
                temp.rotate = effect.rotate;
                temp.timer = DateTime.Now.Ticks + effect.dead * 10000;

                if (effect.type != (int)EffectType.CLOUD && effect.horizon > 0)
                {
                    int val = (int)(temp.horizon * 100);
                    temp.horizon = (float)(MyRand.Next(val + 1) - (val / 2)) / 100;
                }
                if (temp.type == (int)EffectType.DIFFUSION) temp.direct = MyRand.Next(360);
                if (temp.type == (int)EffectType.DIRECTION) temp.direct = temp.angle;

                gObject.Add(temp);
            }
        }

        private void DrawScreen()
        {
            try
            {
                //if (owner.owner.WindowState == FormWindowState.Minimized) return;

                int x = (this.Width / 2) - (ScreenX / 2), y = (this.Height / 2) - (ScreenY / 2), width = ScreenX - 1, height = ScreenY - 1;

                m_device.Clear(ClearFlags.Target, Color.Gray, 1.0f, 0);
                m_device.BeginScene();

                DrawRectangle(x, y, width, height, Color.Black.ToArgb());

                using (Microsoft.DirectX.Direct3D.Sprite s = new Microsoft.DirectX.Direct3D.Sprite(m_device))
                {
                    s.Begin(SpriteFlags.AlphaBlend);

                    for (int i = 0; i < gObject.Count; i++)
                    {
                        GameObject temp = gObject[i];

                        if (temp.pattern < mypar.TotalPattern)
                        {
                            mypar.DrawParticle(s, temp.x, temp.y, temp);
                            if (temp.dead > 0 && DateTime.Now.Ticks >= temp.timer) { gObject.Remove(temp); i--; }
                        }
                    }

                    s.End();
                }

                m_device.EndScene();
                m_device.Present();
            }

            catch (DirectXException)
            {
                InitGame();
            }
        }

        public void AddParticleSprite(int num, string name)
        {
            for (int i = 0; i < mypar.aniArray[num].TotalMotion; i++)
            {
                owner.treeView1.Nodes[num].Nodes.Add(String.Format("{0:G}번 모션", i));

                for (int k = 0; k < mypar.aniArray[num].Motion[i].count; k++)
                {
                    owner.treeView1.Nodes[num].Nodes[i].Nodes.Add(String.Format("{0:G}번 프레임", k));
                }
            }
            owner.treeView1.Nodes[num].Expand();
        }

        public void DeleteSprite()
        {
            int pattern = owner.treeView1.SelectedNode.Index;

            owner.treeView1.SelectedNode = null;

            gObject.Clear();

            owner.treeView1.Nodes[pattern].Remove();
            mypar.TotalPattern--;

            for (int i = pattern; i < mypar.TotalPattern; i++)
            {
                string fname = mypar.sprArray[i + 1].pathname + '\\' + mypar.sprArray[i + 1].filename;

                mypar.sprArray[i].Load(fname);
                mypar.aniArray[i].Load(fname);
            }
            Focus();
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

        public void LoadEffectFile(string strProgrampath)
        {
            if (strProgrampath == null) return;

            mypar.LoadEffectFile(m_device, strProgrampath);

            gObject.Clear();
            CurrentEffect = 0;

            owner.treeView1.Nodes.Clear();

            for (int i = 0; i < mypar.namelist.Count; i++)
            {
                owner.treeView1.Nodes.Add(String.Format("[{0:G}번] - {1:G}", i, mypar.namelist[i]));
                AddParticleSprite(i, mypar.pathname + '\\' + mypar.namelist[i]);
            }

            owner.numeric_number.Maximum = mypar.effect.Count - 1;
            owner.numeric_number.Value = 0;
            SetCurrentInfo(0);

            owner.treeView1.Focus();
        }

        public void OpenEffectFile()
        {
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();

            myOpenFileDialog.DefaultExt = "*.*";
            myOpenFileDialog.InitialDirectory = ".";
            myOpenFileDialog.Filter = "Effect files (*.ECT)|*.ect|All files (*.*)|*.*";
            myOpenFileDialog.FilterIndex = 1;
            myOpenFileDialog.RestoreDirectory = true;

            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string strPath = Path.GetDirectoryName(myOpenFileDialog.FileName);
                string strProgrampath = myOpenFileDialog.FileName;
                string strProgram = myOpenFileDialog.SafeFileName.Substring(0, myOpenFileDialog.SafeFileName.Length - 4);
                string strExt = myOpenFileDialog.SafeFileName.Substring(myOpenFileDialog.SafeFileName.Length - 4, 4);

                LoadEffectFile(strProgrampath);
            }
        }

        public void SaveEffectFile()
        {
            GetCurrentInfo((int)owner.numeric_number.Value);

            SaveFileDialog myOpenFileDialog = new SaveFileDialog();

            myOpenFileDialog.DefaultExt = "*.*";
            myOpenFileDialog.InitialDirectory = ".";
            myOpenFileDialog.Filter = "Effect files (*.ECT)|*.ect|All files (*.*)|*.*";
            myOpenFileDialog.FilterIndex = 1;
            myOpenFileDialog.RestoreDirectory = true;
            myOpenFileDialog.FileName = mypar.filename;

            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string strPath = Path.GetDirectoryName(myOpenFileDialog.FileName);
                string strProgrampath = myOpenFileDialog.FileName;

                //mypar.SaveEffectFile(strProgrampath);
            }
        }

        public void DrawRectangle(int sx, int sy, int width, int height, int color)
        {
            int ex = sx + width, ey = sy + height;
            CustomVertex.TransformedColored[] vertexes = new CustomVertex.TransformedColored[3];

            m_device.VertexFormat = VertexFormats.Diffuse;

            vertexes[0].Position = new Vector4(sx, sy, 0, 1.0f);
            vertexes[0].Color = color;

            vertexes[1].Position = new Vector4(ex, sy, 0, 1.0f);
            vertexes[1].Color = color;

            vertexes[2].Position = new Vector4(ex, ey, 0, 1.0f);
            vertexes[2].Color = color;

            m_device.DrawUserPrimitives(PrimitiveType.TriangleList, 1, vertexes);

            vertexes[0].Position = new Vector4(sx, sy, 0, 1.0f);
            vertexes[0].Color = color;

            vertexes[1].Position = new Vector4(ex, ey, 0, 1.0f);
            vertexes[1].Color = color;

            vertexes[2].Position = new Vector4(sx, ey, 0, 1.0f);
            vertexes[2].Color = color;

            m_device.DrawUserPrimitives(PrimitiveType.TriangleList, 1, vertexes);
        }




        private void ParticlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Focused)
            {
                MouseX = e.X;
                MouseY = e.Y;

                if (e.Button == MouseButtons.Left)
                {
                    if (!LeftClick)
                        MakeEffect();
                    LeftClick = true;
                }
            }
        }

        private void ParticlePanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) LeftClick = false;
            if (e.Button == MouseButtons.Right) RightClick = false;
        }
    }
}
