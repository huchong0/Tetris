namespace Tetris
{
    partial class OpeningForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpeningForm));
            this.ButtonEasy = new System.Windows.Forms.Button();
            this.ButtonNormal = new System.Windows.Forms.Button();
            this.ButtonHard = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonEasy
            // 
            this.ButtonEasy.BackColor = System.Drawing.Color.Transparent;
            this.ButtonEasy.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButtonEasy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEasy.ForeColor = System.Drawing.Color.White;
            this.ButtonEasy.Location = new System.Drawing.Point(127, 185);
            this.ButtonEasy.Name = "ButtonEasy";
            this.ButtonEasy.Size = new System.Drawing.Size(100, 27);
            this.ButtonEasy.TabIndex = 0;
            this.ButtonEasy.Text = "简单";
            this.ButtonEasy.UseVisualStyleBackColor = false;
            this.ButtonEasy.Click += new System.EventHandler(this.ButtonEasy_Click);
            // 
            // ButtonNormal
            // 
            this.ButtonNormal.BackColor = System.Drawing.Color.Transparent;
            this.ButtonNormal.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButtonNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonNormal.ForeColor = System.Drawing.Color.White;
            this.ButtonNormal.Location = new System.Drawing.Point(127, 237);
            this.ButtonNormal.Name = "ButtonNormal";
            this.ButtonNormal.Size = new System.Drawing.Size(100, 27);
            this.ButtonNormal.TabIndex = 1;
            this.ButtonNormal.Text = "普通";
            this.ButtonNormal.UseVisualStyleBackColor = false;
            this.ButtonNormal.Click += new System.EventHandler(this.ButtonNormal_Click);
            // 
            // ButtonHard
            // 
            this.ButtonHard.BackColor = System.Drawing.Color.Transparent;
            this.ButtonHard.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButtonHard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHard.ForeColor = System.Drawing.Color.White;
            this.ButtonHard.Location = new System.Drawing.Point(127, 286);
            this.ButtonHard.Name = "ButtonHard";
            this.ButtonHard.Size = new System.Drawing.Size(100, 27);
            this.ButtonHard.TabIndex = 2;
            this.ButtonHard.Text = "困难";
            this.ButtonHard.UseVisualStyleBackColor = false;
            this.ButtonHard.Click += new System.EventHandler(this.ButtonHard_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Lobster", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Silver;
            this.checkBox1.Location = new System.Drawing.Point(209, 359);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 24);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Transparency";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(127, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 91);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(615, 141);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(10, 10);
            this.axWindowsMediaPlayer1.TabIndex = 5;
            this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer1_PlayStateChange);
            this.axWindowsMediaPlayer1.Enter += new System.EventHandler(this.axWindowsMediaPlayer1_Enter);
            // 
            // OpeningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(740, 449);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ButtonHard);
            this.Controls.Add(this.ButtonNormal);
            this.Controls.Add(this.ButtonEasy);
            this.DoubleBuffered = true;
            this.Name = "OpeningForm";
            this.Text = "Opening";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonEasy;
        private System.Windows.Forms.Button ButtonNormal;
        private System.Windows.Forms.Button ButtonHard;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

