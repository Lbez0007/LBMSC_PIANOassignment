using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SimplePiano
{
    public class MusKey : System.Windows.Forms.Button
    {
        private int musicNote; //determines pitch mapped to number
        public int noteNo;
        public bool sharp;

        public MusKey(int iNote, int x, int y, bool iSharp) : base()
        {
            noteNo = iNote;
            sharp = iSharp;
            this.BackColor = Color.White;
            this.Location = new Point(x, y);
            this.Size = new Size(30, 120);
            this.Visible = true;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }

    public class BlackMusKey : MusKey
    {
        public BlackMusKey(int iNote, int x, int y, bool iSharp) : base(iNote, x, y, iSharp)
        {
            this.BackColor = Color.Black;
            this.Size = new Size(30, 70);
        }

    }
}
