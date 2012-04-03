using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BandaGaraxxjata
{
    public class BlackMusicKey : MusicKey
    {
        string blackkey_normal = @"Resources\Images\pianokeyb.jpg";

        public BlackMusicKey(int iNote, int x, int y)
            : base(iNote, x, y)
        {
            this.Size = new Size(30, 100);
            base.keyImage.ImageLocation = blackkey_normal;
        }

    }
}
