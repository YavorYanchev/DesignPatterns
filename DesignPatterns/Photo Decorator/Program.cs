using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Photo_Decorator
{
    class BorrderPhoto : Photo
    {
        private Photo _photo;
        private Color _color;

        public BorrderPhoto(Photo photo, Color color)
        {
            _photo = photo;
            _color = color;
        }

        public override void Drawer(object source, PaintEventArgs e)
        {
            _photo.Drawer(source, e);
            e.Graphics.DrawRectangle(new Pen(_color, 10), 25, 15, 215, 225);
        }
    }


    class TaggedPhoto : Photo
    {
        private Photo _photo;
        private string _tag;
        private int number;
        private static int _count;
        List<string> tags = new List<string>();

        public TaggedPhoto(Photo photo, string tag)
        {
            _photo = photo;
            _tag = tag;
            tags.Add(tag);
            number = ++_count;
        }

        public override void Drawer(object source, PaintEventArgs e)
        {
            _photo.Drawer(source, e);
            e.Graphics.DrawString(_tag,
                new Font("Arial", 16),
                new SolidBrush(Color.Black),
                new PointF(80,100+number*20));
        }

        public string ListTaggedPhotos()
        {
            var listTags = "Tags are: ";
            foreach (var tag in tags)
                listTags += tag + " ";

            return listTags;
        }

    }


    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            var photo = new Photo();
            var foodTaggedPhoto = new TaggedPhoto(photo, "Food");
            var colorTaggedPhoto = new TaggedPhoto(foodTaggedPhoto, "Yellow");
            var composition = new BorrderPhoto(colorTaggedPhoto, Color.Blue);
            Application.Run(composition);
            Console.WriteLine(colorTaggedPhoto.ListTaggedPhotos());
        }
    }
}
