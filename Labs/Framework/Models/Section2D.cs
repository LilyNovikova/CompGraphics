using System.Drawing;

namespace Framework.Models
{
    public class Section2D
    {
        public Point A { get; private set; }
        public Point B { get; private set; }

        public Section2D(Point a, Point b)
        {
            A = a;
            B = b;
        }
    }
}
