using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    abstract class BaseShape : IBShapes
    {
        protected int x;
        protected int y;

        public BaseShape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public abstract string getType();

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        public abstract double getArea();

        public virtual void List()
        {
            Console.WriteLine("Típus: {0}\tKoordináták: {1},{2}\tTerület: {3}", getType(), getX(), getY(), getArea());
        }
    }
}
