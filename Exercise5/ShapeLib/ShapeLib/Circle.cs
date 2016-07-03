using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Circle : Elipse
    {
        //property:
        public int Radious { get; set; }
        //c'tor:
        public Circle(int radious, ConsoleColor color) : base(radious, radious, color)
        {
            if (radious > 0)
            { Radious = radious; }
        }
        public Circle(int radious) : base(radious, radious)
        {
            Radious = radious;
        }
        public Circle() : base(1, 1)
        {
            Radious = 1;
        }
        /// <summary>
        /// override the method inherited from Shape
        /// </summary>
        public override void Display()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("In this circle radious= " + Radious);
        }
    }
}
