using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/*
 * Say Hello to Roovle
 * The code f*cker
 */

namespace BandaGaraxxjata
{
    public class Noti : System.Windows.Forms.Panel
    {
        private static int totalNotes = 36;//Roovle sets limits to the total notes
        private string path = @"Resources\Images\";
        //Roovle sets paths for images
        private int min = 20; 
        private int interval = 15;

        public struct nota
        {
            public int y;
            public int duration;
            public string accidental;
            public int pitch;
            public string mod;
        };
        
        private static nota[] noti = new nota[totalNotes];
        //Roovle makes an array of structures
        public nota[] xebaNoti
        {
            get { return noti; }
            set { noti = value; }
        }//And gets happy about it
        
        public Noti()
        {
            for (int i = 0; i < xebaNoti.Length; i++)
            {
                xebaNoti[i].duration = 0;
                xebaNoti[i].accidental = "blank";//blank = sole and # = sharp
                xebaNoti[i].y = 0;
                xebaNoti[i].pitch = 0;
                xebaNoti[i].mod = null;
            }//Roovle inits all notes with zeros and nulls
        }

        public void drawNote(PaintEventArgs hagu, int id, int x, int y, string acc, string mod)
        {
            pingiNota(hagu, id, x, y, acc, mod);
        }

        public void drawNote(PaintEventArgs hagu)
        {
            pingiCleff(hagu);
        }

        private void pingiNota(PaintEventArgs picasso, int id, int x, int y, string acc, string mod)
        {
            Bitmap mappa = new Bitmap(path + id + mod + ".png");
            Bitmap sharp = new Bitmap(path + acc + ".bmp");
            //Bitmap ledger = new Bitmap(path + line + ".bmp");
            //Bitmap rest = new Bitmap(path + mistrieh + "r.bmp");
            sharp.MakeTransparent(); //ghax nisthi mix xemx!
            picasso.Graphics.DrawImage(mappa, x, y, mappa.Width, mappa.Height);
            //picasso.Graphics.DrawImage(ledger, x, y, ledger.Width, ledger.Height);
            //picasso.Graphics.DrawImage(rest, x, 45, rest.Width, rest.Height);
            picasso.Graphics.DrawImage(sharp, x-5, y-5, sharp.Width, sharp.Height);
        }

        private void pingiCleff(PaintEventArgs picasso)
        {
            Bitmap cleff = new Bitmap(path + "treble.png");
            //cleff.MakeTransparent(); //Roovle demands transperency which is not needed
            picasso.Graphics.DrawImage(cleff, 50, 23, cleff.Width, cleff.Height);
        }

        private int noteToInt(int nota)
        {
            int position = -1; //Roovle spitts a -1 when disgusted by your data
            for (int i = min; i <= ((interval * 7) + min); i += interval)
            {
                if (nota >= (i - 1) && nota <= (i + 1))
                    position = i - 28;//Roovle happy with lines
                else if (!(i == ((interval * 7) + min)))
                {
                    if (nota >= (2 + i) && nota <= (i + interval + 2))
                        position = i - 20;//Roovle happy with empty spaces
                }
            }
            return position;//Roovle emmits answer
        }

        public int yToPitch(int y, string acc)
        {
            int pitch = 0; //Roovle spitts a 0 when disgusted by your data
            int[] ommok = { 25, 24, 22, 20, 18, 17, 15, 13, 12, 10, 8, 6, 5, 3, 1 };

            if ((y >= min) && (y <= ((interval * 7) + min)))
            {
                for (int i = min; i <= ((interval * 7) + min); i += interval)
                {
                    if (y >= (i - 1) && y <= (i + 1))
                    {//Roovle happy with lines
                        pitch = ommok[(2 * ((i - min) / 15))];
                        break;
                    }
                    else if (y >= (2 + i) && y <= (i + interval - 2))
                    {//Roovle happy with empty spaces
                        pitch = ommok[((2 * ((i - min) / 15)) + 1)];
                        break;
                    }
                }
                if (acc == "#") { if (pitch != 25) pitch++; }
            }
            return pitch; //Roovle emmits answer
        }

        public int pitchToY(int pitch)
        {
            int[] ommok = { 25, 24, 22, 20, 18, 17, 15, 13, 12, 10, 8, 6, 5, 3, 1 };
            //Possible natural notes in Roovle's mother's purse
            int index = -1;
            for (int i = 0; i < ommok.Length; i++)
            {
                if (pitch == ommok[i])
                {
                    index = i;//Roovle found index for a natural note
                    break;
                }
            }

            if (index == -1)
            {//The note wasn't in your mother's purse
                for (int i = 0; i < ommok.Length - 1; i++)
                {
                    if ((pitch > ommok[i + 1]) && ((pitch < ommok[i])))
                    {
                        index = i + 1;//Roovle found the index of an accidental
                        break;
                    }

                }
            }

            if (pitch <= 25 && pitch >= 1 && index != 1)
            {
                for (int i = min; i <= ((interval * 7) + min); i += interval)
                {
                    if ((2 * ((i - min) / 15)) == index)
                        return i - 28; 
                    if (((2 * ((i - min) / 15)) + 1) == index)
                        return i - 20;
                }
            }
            return 0;
        }

        public int msToDuration(int ms)
        {
            if (ms == 0)
                return 0;
            else if (ms <= 63 && ms > 0)
                return 1;
            else if (ms <= 125 && ms > 63)
                return 2;
            else if (ms <= 250 && ms > 125)
                return 3;
            else if (ms <= 500 && ms > 250)
                return 4;
            else return 5;
        }
        
        private int locationToX(int x)
        {
            int position = -1;
            if (x >= 110 & x <= 820)
            {
                for (int i = 110; i <= 820; i += 20)
                {
                    if ((x >= (i - 9)) && (x <= (i + 9)))
                        position = (i - 110) / 20;
                }
            }
            return position;
        }
        
        public void changeNote(int x)
        {
            ibdelTulTaNota(x);
            //Askes the great Roovle to change the epic note
        }
        
        public void changeNote(int x, bool acc)
        {
            ibdelAccTaNota(x, acc);
            //Askes the great Roovle to change the accident of a note
        }

        public void changeNote(int x, int y)
        {
            zidJewMexxiNota(x, y);
            //Askes the great Roovle to add or move an epic note
        }

        public void changeNote(int i, int pitch, int ms, string acc)
        {
            zidNota(i, pitch, ms, acc);
            //Askes the great Roovle to add or move an epic note
        }

        private void ibdelTulTaNota(int x)
        {
            int identita = locationToX(x);//Roovle knows where your mum lives
            if (identita != -1)//Roovle only works with good data
            {
                //First things first, Roovle changes the note, coz he has big furry balls
                if (xebaNoti[identita].duration == 5)//Roovle first checks if the the note is a whole note
                    xebaNoti[identita].duration = 0; //If true, it goes back to nothing, coz, banana
                else xebaNoti[identita].duration++;//Else Roovle just increments the id counter
            }
        }
        
        private void ibdelAccTaNota(int x, bool acc)
        {
            int identita = locationToX(x);//Roovle knows where you live
            if (identita != -1)//Roovle only works with good data
            {
                if (xebaNoti[identita].accidental == "#")
                {
                    xebaNoti[identita].pitch--;
                    xebaNoti[identita].accidental = "blank";
                }
                else
                {
                    xebaNoti[identita].accidental = "#";
                    xebaNoti[identita].pitch++;
                }
            }
        }
        
        private void zidJewMexxiNota(int x, int y) //Roovle approved code
        {
            int _y = noteToInt(y);
            int identita = locationToX(x);//Roovle knows where you live 

            if (_y != -1 && identita != -1)//Roovle only works with good data
            {
                xebaNoti[identita].y = _y; //Roovle sets new location
                xebaNoti[identita].pitch = yToPitch(y,xebaNoti[identita].accidental);
                if (xebaNoti[identita].duration == 0)
                    xebaNoti[identita].duration = 3; //Roovle sets new note
                //Roovle chose the Crotchet as it's the most used note
                if (_y <= 45)
                {
                    xebaNoti[identita].y = _y + 21;
                    xebaNoti[identita].mod = "i";
                }
                else xebaNoti[identita].mod = null;
            }
        }

        private void zidNota(int identita, int pitch, int ms, string acc) //Roovle approved code
        {
            int y = pitchToY(pitch);
            if (pitch != -1 && identita != -1)//Roovle only works with good data
            {
                xebaNoti[identita].y = y; //Roovle sets new location
                xebaNoti[identita].pitch = pitch;
                xebaNoti[identita].duration = msToDuration(ms); //Roovle sets new note
                //Roovle chose the Crotchet as it's the most used note
                if (y <= 45)
                {
                    xebaNoti[identita].y = y + 21;
                    xebaNoti[identita].mod = "i";
                }
                else xebaNoti[identita].mod = null;
                xebaNoti[identita].accidental = acc;
            }
        }
    }
}