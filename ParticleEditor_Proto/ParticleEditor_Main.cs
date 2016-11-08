using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace ParticleEditor_Proto
{
    public partial class ParticleEditor_Main : Form
    {
        public string LoadFile = null;

        //public Image play = Properties.Resources.play;
        //public Image stop = Properties.Resources.stop;

        public ParticleEditor_Main()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            parPanel1.owner = this;
            
        }

        private void NewProject_Click(object sender, EventArgs e)
        {
            
        }

        private void OpenProject_Click(object sender, EventArgs e)
        {
            parPanel1.OpenEffectFile();
        }

        private void SaveProject_Click(object sender, EventArgs e)
        {

        }

        private void ParticleEditor_Main_Load(object sender, EventArgs e)
        {
            parPanel1.owner = this;
            parPanel1.InitGame();
            parPanel1.RunGame();

            parPanel1.AddNewEffect();

            //numericUpDown2.Value = parPanel1.ScreenX;
            //numericUpDown3.Value = parPanel1.ScreenY;

            //combo_type.SelectedIndex = 0;
            //combo_loop.SelectedIndex = 0;
            numeric_number.Maximum = parPanel1.mypar.effect.Count - 1;
        }

        private void ParticleEditor_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            parPanel1.active = false;
            parPanel1.m_device.Dispose();
            this.Dispose();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parPanel1.OpenEffectFile();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            parPanel1.PlayProcess();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            parPanel1.StopProcess();
        }

        private void numeric_TimeInterval_ValueChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("{0}", numeric_TimeInterval.Value);
            parPanel1.PlayInterval((int)numeric_TimeInterval.Value);
        }
    }
}
