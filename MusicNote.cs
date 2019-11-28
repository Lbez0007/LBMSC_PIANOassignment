using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePiano
{
    class MusicNote : PictureBox
    {
        //public string path = @"C:\Users\Dell\Source\Repos\Lbez0007\LBMSC_PIANOassignment\Image_files\";
        public string path = @"C:\Users\mikesciclunacalleja\source\repos\CIS2201---Piano-Assignment\Music_Notes";
        public int noteNo;  //music key
        public string noteShape; //specifies name of note
        public string fileNoteShape;
        public string fileNoteShape2;
        public int noteDuration; //different note shape according to duration of key pressed

        public MusicNote(int iNoteNo, int iNoteDuration, string iNoteShape, bool iSharp) : base()
        {
            if (iSharp == true | iSharp == false)
            {
                noteNo = iNoteNo;
                noteShape = iNoteShape;
                noteDuration = iNoteDuration;
                fileNoteShape = noteShape + ".png";

                var test = (Path.Combine(path, fileNoteShape));
                //MessageBox.Show(test);

                //inherited properties from PictureBox Windows Forms class
                Bitmap bmp = new Bitmap(Path.Combine(path, fileNoteShape));
                Image = bmp;
                Size = new Size(60, 80);
                // Location = new Point(y, 30);
                BackColor = Color.Transparent;
            }

            if (iSharp == true)
            {
                fileNoteShape2 = "Sharp1.png";


                var test1 = (Path.Combine(path, fileNoteShape2));
                //MessageBox.Show(test);

                //inherited properties from PictureBox Windows Forms class
                Bitmap bmpSh = new Bitmap(Path.Combine(path, fileNoteShape2));
                Image = bmpSh;
                Size = new Size(60, 80);
                //Location = new Point(20, 0);
                BackColor = Color.Transparent;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }


}
