using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_002
{
    class Rectangle
    {
        //fields
        private double x, y;
        private double width, height;

        //properties
        public double X { get { return x; } }
        public double Y { get { return y; } }
        public double Width { get { return width; } }
        public double Height { get { return height; } }

        //constructor
        public Rectangle(double aX, double aY, double bX, double bY)
        {
            //Takes the input and sets it to the attributes of a classic rectangle
            x = Math.Min(aX, bX);
            y = Math.Max(aY, bY);
            width = Math.Abs(aX - bX);
            height = Math.Abs(aY - bY);
        }
        //Uses the other rectangle to find width and height of the intersect area
        public double GetIntersectArea(Rectangle r)
        {
            double areaWidth = GetDifference(x, x + width, r.X, r.X + r.Width);
            double areaHeight = GetDifference(y-height, y, r.Y-r.Height, r.Y);

            //area of a rectangle is = to width * height
            double area = areaHeight * areaWidth;

            return area;
        }
        //General method that will find the heigh or width of the intersect section of 2 rectangles
        private double GetDifference(double xLeft1, double xRight1, double xLeft2, double xRight2)
        {
            //Two coordinates we will subtract from eachother to find a width or height
            double x1 = 0;
            double x2 = 0;

            //Finds if any points are inbetween the points of another rectangle
            if (xLeft2 <= xRight1 && xLeft2 >= xLeft1)
                x1 = xLeft2;
            if (xRight2 <= xRight1 && xRight2 >= xLeft1)
                x2 = xRight2;
            if (xLeft1 <= xRight2 && xLeft1 >= xLeft2)
                x1 = xLeft1;
            if (xRight1 <= xRight2 && xRight1 >= xLeft2)
                x2 = xRight1;

            double difference = Math.Abs(x1 - x2);

            return difference;
        }
    }
}
