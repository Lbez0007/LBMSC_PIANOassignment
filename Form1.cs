using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePiano
{
    public partial class Form1 : Form
    {
        int count = 0;
        int xLoc = 50;
        int yLoc = 30;
        int[] xPos = { 10, 30, 70, 90, 110, 150, 170, 210, 230, 250 };
        SoundPlayer sp;
        int[] whitePitch = { 1, 3, 5, 6, 8, 10, 12, 13, 15, 17, 18, 20, 22, 24 };
        int[] blackPitch = { 2, 4, 7, 9, 11, 14, 16, 19, 21, 23 };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MusKey mk;
            BlackMusKey bmk;

            for (int k = 0; k < 7; k++)  //Octave - containes notes A-G, thus 7 notes
            {
                int pitch = whitePitch[k];
                int xPos = k * 20; //since MusicKey is 20 units wide
                mk = new MusKey(pitch, xPos, 50);
                mk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
                mk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
                this.panel1.Controls.Add(mk);
            }

            int xOffset = 20;
            for (int k = 0; k < 5; k++)  //Octave - containes notes A-G, thus 7 notes
            {
                int pitch = blackPitch[k];
                int xPos = this.xPos[k]; //black key only exists for #notes, which are at irregular positions, hence deifned in array xPos
                bmk = new BlackMusKey(pitch, xPos, 50);
                bmk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
                bmk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
                this.panel1.Controls.Add(bmk);
                this.panel1.Controls[this.panel1.Controls.Count - 1].BringToFront();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count = count++;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            int count;

            foreach (MusKey mk in this.panel1.Controls)
            {
                if (sender == mk)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        timer1.Enabled = true;
                        count = 0; //incremented by timer1_Tick event handler
                        timer1.Start();
                        sp.SoundLocation = (mk.notePitch.ToString() + ".wav");
                        sp.Play();
                    }
                }
            }

        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (MusKey mk in this.panel1.Controls)
            {
                if (sender == mk)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        timer1.Enabled = false;
                        sp.Stop();
                        string bNoteShape = null;
                        int duration = 0;
                        if (count >= 11)
                        {
                            bNoteShape = "SemiBreve";
                            duration = 11;
                        }
                        if ((count >= 8) && (count <= 10))
                        {
                            bNoteShape = "DotMinim";
                            duration = (8 + 10) / 2;
                        }

                        //...........

                        //MusicNote mn = new MusicNote(mk.notePitch, duration, bNoteShape);
                        //mn.Location = new Point(xLoc, yLoc);
                        //this.panel2.Controls.Add(this.mn);
                        //xLoc = xLoc + 15;


                    }
                }
            }
        }
    }
}
