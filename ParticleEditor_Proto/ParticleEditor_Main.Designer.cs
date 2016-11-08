namespace ParticleEditor_Proto
{
    partial class ParticleEditor_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.numeric_TimeInterval = new System.Windows.Forms.NumericUpDown();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveProject = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.OpenProject = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.numeric_gravity = new System.Windows.Forms.NumericUpDown();
            this.lbSprite = new System.Windows.Forms.Label();
            this.numeric_sprite = new System.Windows.Forms.NumericUpDown();
            this.numeric_number = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.NewProject = new System.Windows.Forms.Button();
            this.parPanel1 = new ParticleEditor_Proto.ParticlePanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_TimeInterval)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gravity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_sprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_number)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.numeric_TimeInterval);
            this.splitContainer1.Panel1.Controls.Add(this.btnStop);
            this.splitContainer1.Panel1.Controls.Add(this.btnPlay);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.SaveProject);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.OpenProject);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.NewProject);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.LightBlue;
            this.splitContainer1.Panel2.Controls.Add(this.parPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(988, 591);
            this.splitContainer1.SplitterDistance = 389;
            this.splitContainer1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Time Interval(ms)";
            // 
            // numeric_TimeInterval
            // 
            this.numeric_TimeInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numeric_TimeInterval.Location = new System.Drawing.Point(329, 119);
            this.numeric_TimeInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numeric_TimeInterval.Name = "numeric_TimeInterval";
            this.numeric_TimeInterval.Size = new System.Drawing.Size(50, 21);
            this.numeric_TimeInterval.TabIndex = 7;
            this.numeric_TimeInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numeric_TimeInterval.ValueChanged += new System.EventHandler(this.numeric_TimeInterval_ValueChanged);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(217, 152);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(217, 83);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 5;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(387, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // SaveProject
            // 
            this.SaveProject.BackColor = System.Drawing.Color.Transparent;
            this.SaveProject.BackgroundImage = global::ParticleEditor_Proto.Properties.Resources.media_floppy_3_5_umount;
            this.SaveProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveProject.Location = new System.Drawing.Point(329, 27);
            this.SaveProject.Name = "SaveProject";
            this.SaveProject.Size = new System.Drawing.Size(50, 50);
            this.SaveProject.TabIndex = 2;
            this.SaveProject.UseVisualStyleBackColor = false;
            this.SaveProject.Click += new System.EventHandler(this.SaveProject_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(217, 206);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(162, 283);
            this.treeView1.TabIndex = 3;
            // 
            // OpenProject
            // 
            this.OpenProject.BackColor = System.Drawing.Color.Transparent;
            this.OpenProject.BackgroundImage = global::ParticleEditor_Proto.Properties.Resources.folder_saved_search;
            this.OpenProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenProject.Location = new System.Drawing.Point(273, 27);
            this.OpenProject.Name = "OpenProject";
            this.OpenProject.Size = new System.Drawing.Size(50, 50);
            this.OpenProject.TabIndex = 1;
            this.OpenProject.UseVisualStyleBackColor = false;
            this.OpenProject.Click += new System.EventHandler(this.OpenProject_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numeric_gravity);
            this.panel1.Controls.Add(this.lbSprite);
            this.panel1.Controls.Add(this.numeric_sprite);
            this.panel1.Controls.Add(this.numeric_number);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(11, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 583);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Gravity";
            // 
            // numeric_gravity
            // 
            this.numeric_gravity.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numeric_gravity.Location = new System.Drawing.Point(72, 271);
            this.numeric_gravity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numeric_gravity.Name = "numeric_gravity";
            this.numeric_gravity.Size = new System.Drawing.Size(50, 21);
            this.numeric_gravity.TabIndex = 4;
            // 
            // lbSprite
            // 
            this.lbSprite.AutoSize = true;
            this.lbSprite.Location = new System.Drawing.Point(3, 44);
            this.lbSprite.Name = "lbSprite";
            this.lbSprite.Size = new System.Drawing.Size(37, 12);
            this.lbSprite.TabIndex = 3;
            this.lbSprite.Text = "Sprite";
            // 
            // numeric_sprite
            // 
            this.numeric_sprite.Location = new System.Drawing.Point(106, 35);
            this.numeric_sprite.Name = "numeric_sprite";
            this.numeric_sprite.Size = new System.Drawing.Size(86, 21);
            this.numeric_sprite.TabIndex = 2;
            // 
            // numeric_number
            // 
            this.numeric_number.Location = new System.Drawing.Point(106, 8);
            this.numeric_number.Name = "numeric_number";
            this.numeric_number.Size = new System.Drawing.Size(86, 21);
            this.numeric_number.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number";
            // 
            // NewProject
            // 
            this.NewProject.BackColor = System.Drawing.Color.Transparent;
            this.NewProject.BackgroundImage = global::ParticleEditor_Proto.Properties.Resources.user_trash;
            this.NewProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NewProject.Location = new System.Drawing.Point(217, 27);
            this.NewProject.Name = "NewProject";
            this.NewProject.Size = new System.Drawing.Size(50, 50);
            this.NewProject.TabIndex = 0;
            this.NewProject.UseVisualStyleBackColor = false;
            this.NewProject.Click += new System.EventHandler(this.NewProject_Click);
            // 
            // parPanel1
            // 
            this.parPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.parPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parPanel1.Location = new System.Drawing.Point(0, 0);
            this.parPanel1.Name = "parPanel1";
            this.parPanel1.Size = new System.Drawing.Size(593, 589);
            this.parPanel1.TabIndex = 0;
            // 
            // ParticleEditor_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 591);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ParticleEditor_Main";
            this.Text = "Particle_Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParticleEditor_Main_FormClosing);
            this.Load += new System.EventHandler(this.ParticleEditor_Main_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numeric_TimeInterval)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gravity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_sprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_number)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public ParticlePanel parPanel1;
        private System.Windows.Forms.Button SaveProject;
        private System.Windows.Forms.Button OpenProject;
        private System.Windows.Forms.Button NewProject;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbSprite;
        public System.Windows.Forms.NumericUpDown numeric_sprite;
        public System.Windows.Forms.NumericUpDown numeric_number;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown numeric_gravity;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown numeric_TimeInterval;
    }
}

