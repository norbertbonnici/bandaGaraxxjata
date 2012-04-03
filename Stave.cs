using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//Foo Bars are yummy!
//No moor bullshit
//http://www.youtube.com/watch?v=MdpwVEUMzW8&feature=player_embedded 

namespace BandaGaraxxjata
{
    public partial class Stave : Form
    {
        static int min = 50;//Roovle sets limits!
        static int interval = 15;//Roovle sets the stave interval
        int h = interval*4; //Roovle sets the total height
        int width = 800; //Roovle sets the width of the stave
        //Roovle creates an instance of the Noti class
        Noti roovle = new Noti();
        private MusicKeyboard pjanu;

        public Stave(MusicKeyboard mk)
        {
            InitializeComponent();
            //Roovle inits the stave class 
            this.Width = width + 80;
            this.Height = 190;
            pjanu = mk;
        }

        private void Stave_Paint(object sender, PaintEventArgs picasso)
        {
            System.Drawing.Graphics objGraffiku;
            objGraffiku = this.CreateGraphics();
            Pen pinna = new Pen(System.Drawing.Color.Black, 2);
            //Roovle preapres the pen to paint the stave
            for (int i = min; i <= h+min; i+=interval)
                objGraffiku.DrawLine(pinna, min, i, width + min, i);
            objGraffiku.DrawLine(pinna, min, min, min, h + min);
            //Roovle draws coke lines like a now rich meth head
            roovle.drawNote(picasso);
            //Roovle asks picasso to draw a nice treble cleff
            
            for (int i = 0; i <= 35; i++)
            {
                roovle.drawNote(
                    picasso, roovle.xebaNoti[i].duration, 
                    ((i + 1) * 20) + 80, roovle.xebaNoti[i].y, 
                    roovle.xebaNoti[i].accidental, roovle.xebaNoti[i].mod
                    ); 
                //Roovle draws empty notes like a baws
            }
        }
        
        private void Stave_MouseDown(object sender, MouseEventArgs gurdien)
        {
            //Roovle steals coordinates from deadmau5
            int x = gurdien.X;
            int y = gurdien.Y;
            //Roovle checks for which button was pressed and acts accordingly
            if (gurdien.Button == MouseButtons.Right)
                roovle.changeNote(x);
            else if (gurdien.Button == MouseButtons.Left)
                roovle.changeNote(x, y);
            else if (gurdien.Button == MouseButtons.Middle)
                roovle.changeNote(x, true);
            this.Refresh();
            //Roovle asks your mum to go and take a shower after banging her....
        }

        private void btUpload_Click(object sender, EventArgs e)
        {
            pjanu.disablePlayback();//Clears previous stuff
            for (int i = 0; i < 36; i++)
            {
                int temp = roovle.xebaNoti[i].duration;
                if (temp == 0)
                {// Insert gap in recording
                    pjanu.recording.Add(-1);
                    pjanu.keytimings.Add(0);
                }
                else
                {// Add key to recording
                    pjanu.recording.Add(roovle.xebaNoti[i].pitch);
                    pjanu.keytimings.Add(-1);
                }
                pjanu.enablePlayback();
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 36; i++)
            {//bad roovle, clean roovle
                roovle.xebaNoti[i].duration = 0;
                roovle.xebaNoti[i].accidental = "blank";
                roovle.xebaNoti[i].pitch = 0;
                roovle.xebaNoti[i].y = 0;
                roovle.xebaNoti[i].mod = null;
            }
            this.Refresh();
        }

        public void addNoteFromKeyboard(int pitch, long ms)
        {// Passing noteID (pitch) and duration from MusicKeyboard in realtime, like a boss
            int duration = (int)ms;
            if (roovle.xebaNoti[35].duration == 0)
            {
                string acc = "blank";
                int[] sharp = { 2, 4, 7, 9, 11, 14, 16, 19, 21, 23 };
                for (int i = 35; i >= 0; i--)
                {//Roovle searches for an empty place on the stave 
                    if (i == 0)
                    {
                        for (int j = 0; j < sharp.Length; j++)
                        {
                            if (pitch == sharp[j])
                                acc = "#";
                        }
                        roovle.changeNote(0, pitch, duration, acc);
                        break;
                    }
                    else if (roovle.xebaNoti[i - 1].duration != 0)
                    {//Found and the latested data is deposited
                        for (int j = 0; j < sharp.Length; j++)
                        {
                            if (pitch == sharp[j])
                                acc = "#";
                        }
                        roovle.changeNote(i, pitch, duration, acc);
                        break;
                    }
                }
                this.Refresh();
            }
        }

        private void Stave_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hides stave window instead of closing it
            if (e.CloseReason != CloseReason.FormOwnerClosing)
            {
                this.Hide();
                pjanu.cbStave.Checked = false;
                e.Cancel = true; // cancels the close event
            }
        }
    }
}