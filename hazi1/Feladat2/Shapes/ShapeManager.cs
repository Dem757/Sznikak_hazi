using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    internal class ShapeManager
    {
        private readonly List<IBShapes> list = new List<IBShapes>();

        public void Add(IBShapes shape)
        {
            list.Add(shape);
        }

        public void Remove(IBShapes shape)
        {
            list.Remove(shape);
        }

        public void ListAll()
        {
            foreach (IBShapes shape in list)
            {
                shape.List();
            }
        }
    }
}
