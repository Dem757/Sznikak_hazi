using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Square : BaseShape
    {
        private int a;

        public Square(int x, int y, int a) : base(x, y)
        {
            this.a = a;
        }

        public override string getType()
        {
            return "Square";
        }
        
        public override double getArea()
        {
            return a * a;
        }
    }
}
