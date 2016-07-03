using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public abstract class Shape
    {
        //properties:
        public ConsoleColor Color { get; set; }
        public abstract double Area { get; }
        /// <summary>
        /// A constructor accepting a color and setting the color. 
        /// </summary>
        /// <param name="color"></param>
        public Shape(ConsoleColor color)
        { Color = color; }
        /// <summary>
        /// A default constructor that uses a white color. 
        /// </summary>
        public Shape() : this(ConsoleColor.White) { }
        /// <summary>
        /// A virtual method that changes the current console color to the Color property value
        /// </summary>
        public virtual void Display()
        {
            Console.ForegroundColor = Color;
        }
    }
}
