using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Circle : BaseShape
    {
        private int r;

        public Circle(int x, int y, int r) : base(x, y)
        {
            this.r = r;
        }

        public override string getType()
        {
            return "Circle";
        }

        public override double getArea()
        {
            return r * r * 3.14;
        }
    }
}
