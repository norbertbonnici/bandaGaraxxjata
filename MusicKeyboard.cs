using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace BandaGaraxxjata
{
    public partial class MusicKeyboard : Form
    {
        System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
        Timer playback = new Timer();
        Stopwatch keytimer = new Stopwatch();
        public List<int> recording = new List<int>();
        public List<long> keytimings = new List<long>();
        MusicKey[] keys = new MusicKey[25];

        int playCount = 0;
        double songProgressValue = 0;
        
        Stave staff;

        string sounds_location = @"Resources\Sounds\";

        string whitekey_normal = @"Resources\Images\pianokey.jpg";
        string whitekey_down = @"Resources\Images\pianokey_down.jpg";
        string blackkey_normal = @"Resources\Images\pianokeyb.jpg";
        string blackkey_down = @"Resources\Images\pianokeyb_down.jpg";

        string button_loop_off = @"Resources\Images\Button_Cycle_Off_Normal.png";
        string button_loop_on = @"Resources\Images\Button_Cycle_On_Normal.png";
        string button_play_off = @"Resources\Images\Button_Play_Off_Normal.png";
        string button_play_on = @"Resources\Images\Button_Play_On_Normal.png";
        string button_record_off = @"Resources\Images\Button_Record_Off_Normal.png";
        string button_record_on = @"Resources\Images\Button_Record_On_Normal.png";

        public MusicKeyboard()
        {
            // Set location of windows
            int pos_x = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 4;
            int pos_y = 40;
            this.Location = new Point(pos_x, pos_y);
            staff = new Stave(this);
            staff.Location = new Point(pos_x, pos_y + 430);
            
            InitializeComponent();
            
            this.Load +=new EventHandler(MusicKeyboard_Load);
            playback.Tick += new EventHandler(playback_Tick);

            bDelete.Enabled = false;
            bPlay.Enabled = false;
            bStop.Enabled = false;
            bSpace.Enabled = false;
        }

        private void MusicKeyboard_Load(object sender, EventArgs e)
        {
            MusicKey myMusicKey;
            BlackMusicKey myBlackMusicKey;
            int setId = 1;
            this.KeyPreview = true;

            // White piano keys
            for (int i = 0; i < 15; i++)
            {
                myMusicKey = new MusicKey(setId, (i + 1) * 40, 0);

                keys[setId-1] = myMusicKey;

                myMusicKey.keyImage.MouseDown += new MouseEventHandler(dummyKey_MouseDown);
                myMusicKey.keyImage.MouseUp += new MouseEventHandler(dummyKey_MouseUp);
                this.keyHolder.Controls.Add(myMusicKey);
                if ((setId == 5) || (setId == 12) || (setId == 17) || (setId == 24))
                    setId++;
                else
                setId += 2;
            }

            // Start from half the first white button
            int xOffset = 25;
            setId = 2;

            // Black piano keys
            for (int i = 15; i < 25; i++)
            {
                myBlackMusicKey = new BlackMusicKey(setId, xOffset + 40, 0);

                keys[setId-1] = myBlackMusicKey;

                myBlackMusicKey.keyImage.MouseDown += new MouseEventHandler(dummyKey_MouseDown);
                myBlackMusicKey.keyImage.MouseUp += new MouseEventHandler(dummyKey_MouseUp);
                this.keyHolder.Controls.Add(myBlackMusicKey);
                this.keyHolder.Controls[this.keyHolder.Controls.Count - 1].BringToFront();
                if ((setId == 4) || (setId == 11) || (setId == 16))
                {
                    xOffset += 80;
                    setId += 3;
                }
                else
                {
                    xOffset += 40;
                    setId += 2;
                }
            }

            staff.Show(this); // Show stave window
        }

        public void dummyKey_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (MusicKey mk in this.keyHolder.Controls)
                if (sender == mk.keyImage)
                {
                    // Copying value to local variable is recommended when calling methods, such as ToString()
                    int note = mk.musicNote;

                    // Output ID of key pressed
                    textBox.Text = "Key pressed: " + note.ToString();
                    playKey(mk.musicNote);

                    // Highlight selected key
                    if (mk.GetType().ToString().Contains("BlackMusicKey"))
                        mk.keyImage.ImageLocation = blackkey_down;
                    else
                        mk.keyImage.ImageLocation = whitekey_down;

                    if (cbRecord.Checked)
                    {
                        recording.Add(mk.musicNote);

                        // Stopwatch used to time the duration of the key
                        keytimer.Reset();
                        keytimer.Start();
                    }

                    if (recording.Count > 0)
                        enablePlayback();
                }
        }

        private void dummyKey_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (MusicKey mk in this.keyHolder.Controls)
                if (sender == mk.keyImage)
                {
                    // Stop key playback
                    myPlayer.Stop();

                    if (cbRecord.Checked)
                    {
                        // Pass key id and duration to stave, and store the duration
                        keytimings.Add(keytimer.ElapsedMilliseconds);
                        staff.addNoteFromKeyboard(mk.musicNote, keytimer.ElapsedMilliseconds);
                        keytimer.Stop();
                    }

                    // Return image state to normal
                    if (mk.GetType().ToString().Contains("BlackMusicKey"))
                        mk.keyImage.ImageLocation = blackkey_normal;
                    else
                        mk.keyImage.ImageLocation = whitekey_normal;
                }
        }

        public void enablePlayback()
        {
            bDelete.Enabled = true;
            bPlay.Enabled = true;
        }

        public void disablePlayback()
        {
            recording.Clear();
            keytimings.Clear();
            bDelete.Enabled = false;
            bPlay.Enabled = false;
            textBox.Text = null;
            songProgress.Value = 0;
        }

        public void playKey(int id)
        {
            string soundfile = sounds_location + id + ".wav";
            myPlayer.SoundLocation = soundfile;
            myPlayer.LoadTimeout = 1000;
            myPlayer.Play();
        }

        private void bPlay_Click(object sender, EventArgs e)
        {
            // Convert BPM to Milliseconds
            int bpm = Int32.Parse(tbTempo.Text.ToString());
            int ms = Convert.ToInt32(60000 / bpm);

            // Update button image
            bPlay.BackgroundImage = System.Drawing.Image.FromFile(button_play_on);

            playCount = 0;
            songProgressValue = 0;
            songProgress.Value = 0;
            bStop.Enabled = true;

            // BPM determines interval between each key
            playback.Interval = ms;
            playback.Start();
        }

        private void playback_Tick(object sender, EventArgs e)
        {
            MusicKey mk2;

            if (playCount < recording.Count)
            {
                textBox.Text = "Playing song...";
                if (recording[playCount] != -1)
                {
                    if (playCount == 0)
                        highlightKey(-1, recording[playCount]);
                    else
                        highlightKey(recording[playCount-1] ,recording[playCount]);
                    playKey(recording[playCount]);
                }
                if (recording[playCount] == -1)
                {
                    if (recording[playCount - 1] - 1 > -1)
                    {
                        mk2 = keys[recording[playCount - 1] - 1];
                        if (mk2.GetType().ToString().Contains("BlackMusicKey"))
                            keys[recording[playCount - 1] - 1].keyImage.ImageLocation = blackkey_normal;
                        else
                            keys[recording[playCount - 1] - 1].keyImage.ImageLocation = whitekey_normal;
                    }
                }
                playCount++;

                songProgressValue = (double)playCount / recording.Count;
                songProgressValue = songProgressValue * 100;
                songProgress.Value = (int)Math.Round((double)songProgressValue);

            }
            else
            {
                if (cbLoop.Checked)
                {
                    if (recording[playCount - 1] - 1 > -1)
                    {
                        mk2 = keys[recording[playCount - 1] - 1];
                        if (mk2.GetType().ToString().Contains("BlackMusicKey"))
                            keys[recording[playCount - 1] - 1].keyImage.ImageLocation = blackkey_normal;
                        else
                            keys[recording[playCount - 1] - 1].keyImage.ImageLocation = whitekey_normal;
                    }

                    // Play song in loop mode
                    songProgress.Value = 0;
                    playKey(recording[0]);
                    playCount = 1;
                    songProgressValue = (double)playCount / recording.Count;
                    songProgressValue = songProgressValue * 100;
                    songProgress.Value = (int)Math.Round((double)songProgressValue);

                    mk2 = keys[recording[playCount - 1] - 1];
                    if (mk2.GetType().ToString().Contains("BlackMusicKey"))
                        keys[recording[playCount - 1] - 1].keyImage.ImageLocation = blackkey_down;
                    else
                        keys[recording[playCount - 1] - 1].keyImage.ImageLocation = whitekey_down;
                }
                else {
                    // Song ended
                    textBox.Text = "Song ended";
                    playback.Stop();
                    bStop.Enabled = false;
                    bPlay.BackgroundImage = System.Drawing.Image.FromFile(button_play_off);

                    // Reset last key played to normal state
                    if (recording[playCount - 1] - 1 > -1)
                    {
                        mk2 = keys[recording[playCount - 1] - 1];
                        if (mk2.GetType().ToString().Contains("BlackMusicKey"))
                            keys[recording[playCount - 1] - 1].keyImage.ImageLocation = blackkey_normal;
                        else
                            keys[recording[playCount - 1] - 1].keyImage.ImageLocation = whitekey_normal;
                    }
                }
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            disablePlayback();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            playback.Stop();//Stop playback
            textBox.Text = "Song stopped";
            songProgress.Value = 0;
            bStop.Enabled = false;
            bPlay.BackgroundImage = System.Drawing.Image.FromFile(button_play_off);
            // Reset the last key played back to normal state

            // Make sure that at least a single key has been played
            if (playCount != 0)
            {
                // Make sure that there is a previous key
                if (recording[playCount - 1] - 1 > -1)
                {
                    MusicKey mk2 = keys[recording[playCount - 1] - 1];
                    if (mk2.GetType().ToString().Contains("BlackMusicKey"))
                        keys[recording[playCount - 1] - 1].keyImage.ImageLocation = blackkey_normal;
                    else
                        keys[recording[playCount - 1] - 1].keyImage.ImageLocation = whitekey_normal;
                }
            }

        }

        private void bSpace_Click(object sender, EventArgs e)
        {
            // Inserts a gap into the recording to separate notes
            if (cbRecord.Checked)
            {
                recording.Add(-1);
                staff.addNoteFromKeyboard(0, 0);
            }
        }

        private void cbRecord_CheckedChanged(object sender, EventArgs e)
        {
            // Changes the image of the record button depending on whether it is checked or not
            if (cbRecord.Checked == true)
            {
                bSpace.Enabled = true;
                cbRecord.BackgroundImage = System.Drawing.Image.FromFile(button_record_on);
            }
            else
            {
                bSpace.Enabled = false;
                cbRecord.BackgroundImage = System.Drawing.Image.FromFile(button_record_off);
            }
        }

        private void highlightKey(int prev, int current)
        {
            // Resets image of previous key and highlights current key

            MusicKey mk;

            if (prev != -1)
            {
                // Reset image of previous key played
                mk = keys[prev - 1];
                if (mk.GetType().ToString().Contains("BlackMusicKey"))
                    keys[prev - 1].keyImage.ImageLocation = blackkey_normal;
                else
                    keys[prev - 1].keyImage.ImageLocation = whitekey_normal;
            }

            // Highlight current key
            mk = keys[current - 1];
            if (mk.GetType().ToString().Contains("BlackMusicKey"))
                keys[current - 1].keyImage.ImageLocation = blackkey_down;
            else
                keys[current - 1].keyImage.ImageLocation = whitekey_down;

        }

        private void cbLoop_CheckedChanged(object sender, EventArgs e)
        {
            // Changes the image of the loop button depending on whether it is checked or not
            if (cbLoop.Checked == true)
                cbLoop.BackgroundImage = System.Drawing.Image.FromFile(button_loop_on);
            else
                cbLoop.BackgroundImage = System.Drawing.Image.FromFile(button_loop_off);
        }

        private void cbStave_CheckedChanged(object sender, EventArgs e)
        {
            // Shows or hides the stave
            if (cbStave.Checked)
                staff.Visible = true;
            else
                staff.Visible = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Handles keyboard shortcuts

            if (keyData == Keys.Space)
            {
                if (playback.Enabled == false)
                    bPlay.PerformClick();
                else
                    bStop.PerformClick();
                return true;
            }

            if (keyData == Keys.D)
            {
                bDelete.PerformClick();
                return true;
            }

            if (keyData == Keys.A)
            {
                bSpace.PerformClick();
                return true;
            }

            if (keyData == Keys.R)
            {
                if (cbRecord.Checked == false)
                    cbRecord.Checked = true;
                else
                    cbRecord.Checked = false;
                return true;
            }

            if (keyData == Keys.L)
            {
                if (cbLoop.Checked == false)
                    cbLoop.Checked = true;
                else
                    cbLoop.Checked = false;
                return true;
            }

            if (keyData == Keys.S)
            {
                if (cbStave.Checked == false)
                    cbStave.Checked = true;
                else
                    cbStave.Checked = false;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}