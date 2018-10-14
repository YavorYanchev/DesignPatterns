using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo_Decorator
{
    public partial class Photo : Form
    {
        private Image image;

        public Photo()
        {
            //InitializeComponent();
            image = new Bitmap("jug.jpg");
            this.Text = "Lemonade";
            this.Paint += Drawer;
        }

        public virtual void Drawer(object source, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, 30, 20);
        }
    }
}
