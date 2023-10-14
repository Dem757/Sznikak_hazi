using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class TextArea : Controls.Textbox, IBShapes
    {

        public TextArea(int x, int y, int w, int h) : base(x, y, w, h)
        {
        }

        public string getType()
        {
            return "TextArea";
        }

        public double getArea()
        {
            return GetHeight() * GetWidth();
        }

        public void List()
        {
            Console.WriteLine("Típus: {0}\tKoordináták: {1},{2}\tTerület: {3}", getType(), GetX(), GetY(), getArea());
        }
    }
}
