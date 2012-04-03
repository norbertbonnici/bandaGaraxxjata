using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BandaGaraxxjata
{
    public class MusicKey : System.Windows.Forms.Panel
    {
        public int musicNote;
        public PictureBox keyImage = new PictureBox();
        string whitekey_normal = @"Resources\Images\pianokey.jpg";

        public MusicKey(int iNote, int x, int y)
            : base()
        {
            musicNote = iNote;

            this.Location = new Point(x, y);
            this.Size = new Size(40, 200);
            
            keyImage.ImageLocation = whitekey_normal;
            keyImage.Width = 40;
            keyImage.Height = 200;
            this.Controls.Add(this.keyImage);
            
            keyImage.Visible = true;
            this.Visible = true;
        }

    }
}
