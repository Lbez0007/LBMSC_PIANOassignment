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
        public string path = @"C:\Users\mikesciclunacalleja\source\repos\Piano Assignment\SimplePiano\Image_files\";
        public int noteNo;  //music key
        public string noteShape; //specifies name of note
        public string fileNoteShape;
        public int noteDuration; //different note shape according to duration of key pressed

        public MusicNote (int iNoteNo, int iNoteDuration, string iNoteShape) : base()
        {
            noteNo = iNoteNo;
            noteShape = iNoteShape;
            noteDuration = iNoteDuration;
            fileNoteShape = noteShape + ".bmp";
            var test = (Path.Combine(path, fileNoteShape));
            MessageBox.Show(test);

            //inherited properties from PictureBox Windows Forms class
            Location = new Point(100, 50);
            Size = new Size(40, 40);
            Bitmap bmp = new Bitmap (Path.Combine(path, fileNoteShape));
            Image = bmp;
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }


}
