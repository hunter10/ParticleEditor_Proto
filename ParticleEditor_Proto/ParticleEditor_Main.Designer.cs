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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSprite = new System.Windows.Forms.Label();
            this.numeric_sprite = new System.Windows.Forms.NumericUpDown();
            this.numeric_number = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SaveProject = new System.Windows.Forms.Button();
            this.OpenProject = new System.Windows.Forms.Button();
            this.NewProject = new System.Windows.Forms.Button();
            this.numeric_gravity = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.parPanel1 = new ParticleEditor_Proto.ParticlePanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_sprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_number)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gravity)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.parPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.LightBlue;
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.treeView1);
            this.splitContainer1.Panel2.Controls.Add(this.SaveProject);
            this.splitContainer1.Panel2.Controls.Add(this.OpenProject);
            this.splitContainer1.Panel2.Controls.Add(this.NewProject);
            this.splitContainer1.Size = new System.Drawing.Size(988, 591);
            this.splitContainer1.SplitterDistance = 587;
            this.splitContainer1.TabIndex = 0;
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
            this.panel1.Location = new System.Drawing.Point(192, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 583);
            this.panel1.TabIndex = 4;
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
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(3, 59);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(162, 283);
            this.treeView1.TabIndex = 3;
            // 
            // SaveProject
            // 
            this.SaveProject.BackColor = System.Drawing.Color.Transparent;
            this.SaveProject.BackgroundImage = global::ParticleEditor_Proto.Properties.Resources.media_floppy_3_5_umount;
            this.SaveProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveProject.Location = new System.Drawing.Point(115, 3);
            this.SaveProject.Name = "SaveProject";
            this.SaveProject.Size = new System.Drawing.Size(50, 50);
            this.SaveProject.TabIndex = 2;
            this.SaveProject.UseVisualStyleBackColor = false;
            this.SaveProject.Click += new System.EventHandler(this.SaveProject_Click);
            // 
            // OpenProject
            // 
            this.OpenProject.BackColor = System.Drawing.Color.Transparent;
            this.OpenProject.BackgroundImage = global::ParticleEditor_Proto.Properties.Resources.folder_saved_search;
            this.OpenProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenProject.Location = new System.Drawing.Point(59, 3);
            this.OpenProject.Name = "OpenProject";
            this.OpenProject.Size = new System.Drawing.Size(50, 50);
            this.OpenProject.TabIndex = 1;
            this.OpenProject.UseVisualStyleBackColor = false;
            this.OpenProject.Click += new System.EventHandler(this.OpenProject_Click);
            // 
            // NewProject
            // 
            this.NewProject.BackColor = System.Drawing.Color.Transparent;
            this.NewProject.BackgroundImage = global::ParticleEditor_Proto.Properties.Resources.user_trash;
            this.NewProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NewProject.Location = new System.Drawing.Point(3, 3);
            this.NewProject.Name = "NewProject";
            this.NewProject.Size = new System.Drawing.Size(50, 50);
            this.NewProject.TabIndex = 0;
            this.NewProject.UseVisualStyleBackColor = false;
            this.NewProject.Click += new System.EventHandler(this.NewProject_Click);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Gravity";
            // 
            // parPanel1
            // 
            this.parPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.parPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parPanel1.Location = new System.Drawing.Point(0, 0);
            this.parPanel1.Name = "parPanel1";
            this.parPanel1.Size = new System.Drawing.Size(585, 589);
            this.parPanel1.TabIndex = 0;
            // 
            // ParticleEditor_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 591);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ParticleEditor_Main";
            this.Text = "Particle_Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParticleEditor_Main_FormClosing);
            this.Load += new System.EventHandler(this.ParticleEditor_Main_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_sprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_number)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_gravity)).EndInit();
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
    }
}

