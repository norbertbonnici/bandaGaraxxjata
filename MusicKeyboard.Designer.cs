namespace BandaGaraxxjata
{
    partial class MusicKeyboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicKeyboard));
            this.keyHolder = new System.Windows.Forms.Panel();
            this.dummyKey = new System.Windows.Forms.Panel();
            this.textBox = new System.Windows.Forms.TextBox();
            this.bPlay = new System.Windows.Forms.Button();
            this.cbRecord = new System.Windows.Forms.CheckBox();
            this.bDelete = new System.Windows.Forms.Button();
            this.labelTempo = new System.Windows.Forms.Label();
            this.tbTempo = new System.Windows.Forms.TextBox();
            this.groupPlayback = new System.Windows.Forms.GroupBox();
            this.songProgress = new System.Windows.Forms.ProgressBar();
            this.cbLoop = new System.Windows.Forms.CheckBox();
            this.bStop = new System.Windows.Forms.Button();
            this.bSpace = new System.Windows.Forms.Button();
            this.cbStave = new System.Windows.Forms.CheckBox();
            this.groupPlayback.SuspendLayout();
            this.SuspendLayout();
            // 
            // keyHolder
            // 
            this.keyHolder.BackColor = System.Drawing.Color.Transparent;
            this.keyHolder.Location = new System.Drawing.Point(0, 0);
            this.keyHolder.Name = "keyHolder";
            this.keyHolder.Size = new System.Drawing.Size(653, 203);
            this.keyHolder.TabIndex = 0;
            // 
            // dummyKey
            // 
            this.dummyKey.BackColor = System.Drawing.Color.Transparent;
            this.dummyKey.Location = new System.Drawing.Point(453, 236);
            this.dummyKey.Name = "dummyKey";
            this.dummyKey.Size = new System.Drawing.Size(24, 20);
            this.dummyKey.TabIndex = 1;
            // 
            // textBox
            // 
            this.textBox.Enabled = false;
            this.textBox.Location = new System.Drawing.Point(234, 236);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(201, 20);
            this.textBox.TabIndex = 2;
            this.textBox.TabStop = false;
            this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bPlay
            // 
            this.bPlay.BackgroundImage = global::BandaGaraxxjata.Properties.Resources.Button_Play_Off_Normal;
            this.bPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bPlay.ForeColor = System.Drawing.Color.Black;
            this.bPlay.Location = new System.Drawing.Point(6, 19);
            this.bPlay.Name = "bPlay";
            this.bPlay.Size = new System.Drawing.Size(34, 34);
            this.bPlay.TabIndex = 4;
            this.bPlay.TabStop = false;
            this.bPlay.UseVisualStyleBackColor = true;
            this.bPlay.Click += new System.EventHandler(this.bPlay_Click);
            // 
            // cbRecord
            // 
            this.cbRecord.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbRecord.BackColor = System.Drawing.Color.Transparent;
            this.cbRecord.BackgroundImage = global::BandaGaraxxjata.Properties.Resources.Button_Record_Off_Normal;
            this.cbRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbRecord.ForeColor = System.Drawing.Color.White;
            this.cbRecord.Location = new System.Drawing.Point(24, 236);
            this.cbRecord.Name = "cbRecord";
            this.cbRecord.Size = new System.Drawing.Size(34, 34);
            this.cbRecord.TabIndex = 5;
            this.cbRecord.TabStop = false;
            this.cbRecord.UseVisualStyleBackColor = false;
            this.cbRecord.CheckedChanged += new System.EventHandler(this.cbRecord_CheckedChanged);
            // 
            // bDelete
            // 
            this.bDelete.BackColor = System.Drawing.Color.Transparent;
            this.bDelete.BackgroundImage = global::BandaGaraxxjata.Properties.Resources.Button_Trash;
            this.bDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bDelete.Location = new System.Drawing.Point(141, 236);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(34, 34);
            this.bDelete.TabIndex = 6;
            this.bDelete.TabStop = false;
            this.bDelete.UseVisualStyleBackColor = false;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // labelTempo
            // 
            this.labelTempo.AutoSize = true;
            this.labelTempo.BackColor = System.Drawing.Color.Transparent;
            this.labelTempo.ForeColor = System.Drawing.Color.White;
            this.labelTempo.Location = new System.Drawing.Point(499, 28);
            this.labelTempo.Name = "labelTempo";
            this.labelTempo.Size = new System.Drawing.Size(75, 13);
            this.labelTempo.TabIndex = 7;
            this.labelTempo.Text = "Tempo (BPM):";
            // 
            // tbTempo
            // 
            this.tbTempo.Location = new System.Drawing.Point(580, 25);
            this.tbTempo.Name = "tbTempo";
            this.tbTempo.Size = new System.Drawing.Size(49, 20);
            this.tbTempo.TabIndex = 8;
            this.tbTempo.TabStop = false;
            this.tbTempo.Text = "120";
            this.tbTempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupPlayback
            // 
            this.groupPlayback.BackColor = System.Drawing.Color.Transparent;
            this.groupPlayback.Controls.Add(this.songProgress);
            this.groupPlayback.Controls.Add(this.cbLoop);
            this.groupPlayback.Controls.Add(this.tbTempo);
            this.groupPlayback.Controls.Add(this.bStop);
            this.groupPlayback.Controls.Add(this.labelTempo);
            this.groupPlayback.Controls.Add(this.bPlay);
            this.groupPlayback.ForeColor = System.Drawing.Color.Silver;
            this.groupPlayback.Location = new System.Drawing.Point(18, 290);
            this.groupPlayback.Name = "groupPlayback";
            this.groupPlayback.Size = new System.Drawing.Size(637, 81);
            this.groupPlayback.TabIndex = 9;
            this.groupPlayback.TabStop = false;
            this.groupPlayback.Text = "Playback";
            // 
            // songProgress
            // 
            this.songProgress.Location = new System.Drawing.Point(6, 59);
            this.songProgress.Name = "songProgress";
            this.songProgress.Size = new System.Drawing.Size(625, 10);
            this.songProgress.TabIndex = 9;
            // 
            // cbLoop
            // 
            this.cbLoop.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbLoop.BackgroundImage = global::BandaGaraxxjata.Properties.Resources.Button_Cycle_Off_Normal;
            this.cbLoop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbLoop.Location = new System.Drawing.Point(123, 19);
            this.cbLoop.Name = "cbLoop";
            this.cbLoop.Size = new System.Drawing.Size(34, 34);
            this.cbLoop.TabIndex = 6;
            this.cbLoop.TabStop = false;
            this.cbLoop.UseVisualStyleBackColor = true;
            this.cbLoop.CheckedChanged += new System.EventHandler(this.cbLoop_CheckedChanged);
            // 
            // bStop
            // 
            this.bStop.BackgroundImage = global::BandaGaraxxjata.Properties.Resources.Button_Stop_Normal;
            this.bStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bStop.ForeColor = System.Drawing.Color.Black;
            this.bStop.Location = new System.Drawing.Point(46, 19);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(34, 34);
            this.bStop.TabIndex = 5;
            this.bStop.TabStop = false;
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bSpace
            // 
            this.bSpace.BackColor = System.Drawing.Color.Transparent;
            this.bSpace.BackgroundImage = global::BandaGaraxxjata.Properties.Resources.Button_Add;
            this.bSpace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bSpace.Location = new System.Drawing.Point(101, 236);
            this.bSpace.Name = "bSpace";
            this.bSpace.Size = new System.Drawing.Size(34, 34);
            this.bSpace.TabIndex = 10;
            this.bSpace.TabStop = false;
            this.bSpace.UseVisualStyleBackColor = false;
            this.bSpace.Click += new System.EventHandler(this.bSpace_Click);
            // 
            // cbStave
            // 
            this.cbStave.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbStave.BackColor = System.Drawing.Color.Transparent;
            this.cbStave.BackgroundImage = global::BandaGaraxxjata.Properties.Resources.Button_Stave;
            this.cbStave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cbStave.Checked = true;
            this.cbStave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStave.ForeColor = System.Drawing.Color.White;
            this.cbStave.Location = new System.Drawing.Point(613, 236);
            this.cbStave.Name = "cbStave";
            this.cbStave.Size = new System.Drawing.Size(34, 34);
            this.cbStave.TabIndex = 11;
            this.cbStave.TabStop = false;
            this.cbStave.UseVisualStyleBackColor = false;
            this.cbStave.CheckedChanged += new System.EventHandler(this.cbStave_CheckedChanged);
            // 
            // MusicKeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::BandaGaraxxjata.Properties.Resources.kb_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(676, 386);
            this.Controls.Add(this.cbStave);
            this.Controls.Add(this.bSpace);
            this.Controls.Add(this.groupPlayback);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.cbRecord);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.dummyKey);
            this.Controls.Add(this.keyHolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MusicKeyboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BandaGaraxxjata - Keyboard";
            this.groupPlayback.ResumeLayout(false);
            this.groupPlayback.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel keyHolder;
        private System.Windows.Forms.Panel dummyKey;
        public System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button bPlay;
        private System.Windows.Forms.CheckBox cbRecord;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Label labelTempo;
        private System.Windows.Forms.TextBox tbTempo;
        private System.Windows.Forms.GroupBox groupPlayback;
        private System.Windows.Forms.ProgressBar songProgress;
        private System.Windows.Forms.CheckBox cbLoop;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bSpace;
        public System.Windows.Forms.CheckBox cbStave;

    }
}

