namespace BandaGaraxxjata
{
    partial class Stave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stave));
            this.btUpload = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btUpload
            // 
            this.btUpload.BackColor = System.Drawing.Color.Transparent;
            this.btUpload.BackgroundImage = global::BandaGaraxxjata.Properties.Resources.Button_Upload;
            this.btUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btUpload.Location = new System.Drawing.Point(8, 49);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(34, 34);
            this.btUpload.TabIndex = 0;
            this.btUpload.UseVisualStyleBackColor = false;
            this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
            // 
            // btClear
            // 
            this.btClear.BackColor = System.Drawing.Color.Transparent;
            this.btClear.BackgroundImage = global::BandaGaraxxjata.Properties.Resources.Button_Trash;
            this.btClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btClear.Location = new System.Drawing.Point(8, 89);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(34, 34);
            this.btClear.TabIndex = 1;
            this.btClear.UseVisualStyleBackColor = false;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // Stave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::BandaGaraxxjata.Properties.Resources.bgStave;
            this.ClientSize = new System.Drawing.Size(872, 171);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btUpload);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Stave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BandaGaraxxjata - Stave";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Stave_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Stave_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Stave_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btUpload;
        private System.Windows.Forms.Button btClear;





    }
}