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
        int xLoc = 10;
        int yLoc = 10;
        int[] xPos = { 15, 45, 105, 135, 165, 225, 255, 315, 345, 375};
        int[] y = {0,137,137,128,128,119,110,110,101,101,92,92,83,74,74,65,65,56,47,47,38,38,29,29,20};
        int[] x = {10,50,90,130,170,210,250, 290, 330, 370, 410, 450,490,530,570,610,650,690,730,770,810};
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

            for (int k = 0; k < 14; k++)  //Octave - containes notes A-G, thus 7 notes
            {
                int noteNo = whitePitch[k];
                int xPos = k * 30; //since MusicKey is 20 units wide
                bool sharp = false;
                mk = new MusKey(noteNo, xPos, 50, sharp);
                mk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
                mk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
                this.panel1.Controls.Add(mk);
                
            }

            int xOffset = 20;
            for (int k = 0; k < 10; k++)  //Octave - containes notes A-G, thus 7 notes
            {
                int noteNo = blackPitch[k];
                int xPos = this.xPos[k]; //black key only exists for #notes, which are at irregular positions, hence deifned in array xPos
                bool sharp = true;
                bmk = new BlackMusKey(noteNo, xPos, 50, sharp);
                bmk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
                bmk.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
                this.panel1.Controls.Add(bmk);
                this.panel1.Controls[this.panel1.Controls.Count - 1].BringToFront();
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();

            foreach (MusKey mk in this.panel1.Controls)
            {
                if (sender == mk)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        count = 0; //incremented by timer1_Tick event handler
                        timer1.Start();
                        int intPitch = mk.noteNo;
                        String stringPitch = intPitch.ToString();
                        //sp.SoundLocation = (@"C:\Users\Dell\Source\Repos\Lbez0007\LBMSC_PIANOassignment\Sound_files\" + stringPitch + ".wav");                   
                        sp.SoundLocation = (@"C:\Users\mikesciclunacalleja\source\repos\CIS2201---Piano-Assignment\Sound_files\" + stringPitch + ".wav");
                        sp.Play(); 
                    }
                }
            }

        }
        int xCount = 0;
        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (MusKey mk in this.panel1.Controls)
            {
                if (sender == mk)
                {
                    if (e.Button == MouseButtons.Left)
                    {

                        timer1.Stop();
                        string bNoteShape = null;
                        int duration = 0;

                        if ((count >= 16))
                        {
                            bNoteShape = "SemiBreve";
                            duration = (16);
                        }
                        if ((count >= 11) && (count <= 15))
                        {
                            bNoteShape = "DotMinim";
                            duration = (11 + 15) / 2;
                        }
                        if ((count >= 6) && (count <= 10))
                        {
                            bNoteShape = "Minim";
                            duration = (6 + 10) / 2;
                        }
                        if ((count >= 3) && (count <= 5))
                        {
                            bNoteShape = "Crotchet";
                            duration = (3 + 5) / 2;
                        }
                        if (count == 2)
                        {
                            bNoteShape = "Quaver";
                            duration = 2;
                        }
                        if (count <= 1)
                        {
                            bNoteShape = "SemiQuaver";
                            duration = 1;
                        }

                        MusicNote mn = new MusicNote(mk.noteNo, duration, bNoteShape, mk.sharp);
                        this.panel2.Controls.Add(mn);
                        xLoc = x[xCount];
                        xCount++;
                        yLoc = y[mk.noteNo];
                        mn.Location = new Point(xLoc, yLoc);

                    }
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == false)
            {
                timer2.Start();
                button1.Text = "Stop Timer";
            }

            else
            {
                timer2.Stop();
                button1.Text = "Start Timer";
            }

        }
        int t = 0;

        private void timer2_Tick(object sender, EventArgs e)
        {
            t++;
            textBox1.Text = t.ToString();
        }
    }
}

//To Completion//
/*
 * sharp next to black keys notes
 * stop sound on mouse up 
 * static stave
 * dot minim semibreve
 * base clef and treble clef
 */