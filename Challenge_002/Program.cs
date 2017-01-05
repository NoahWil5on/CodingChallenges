using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_002
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sets the coordiantes of two rectangles
            Rectangle r1 = new Rectangle(-3.5, 4, 1, 1);
            Rectangle r2 = new Rectangle(1, 3.5, -2.5, -1);

            //Finds and prints the intersecting area of the two
            Console.WriteLine(r1.GetIntersectArea(r2).ToString());
        }
    }
}
