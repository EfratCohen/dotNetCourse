using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    // Implement the interfaces IPersist ,IComparable<Rectangle>
    public class Rectangle : Shape, IPersist, IComparable<Rectangle> //**Stass gave us the authority to implement IComparable<Rectangle> instead of IComparable after we learn about generics
    {
        //properties:
        public int Width { get; set; }
        public int Height { get; set; }
        /// <summary>
        /// Implement the abstract property inherited from Shape
        /// </summary>
        public override double Area
        {
            get { return Width * Height; }
        }
        /// <summary>
        /// full paremeters constructor
        /// </summary>
        public Rectangle(int width, int height, ConsoleColor color) : base(color)
        {
            if (width > 0 && height > 0)
            {
                Width = width;
                Height = height;
            }
            else
            {
                Console.WriteLine("We get wrong inputs,can build Retangle with not natural properties");
            }

        }
        /// <summary>
        /// constructor that accepts a width and height of the rectangle
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Rectangle(int width, int height) : base()
        {
            if (width > 0 && height > 0)
            {
                Width = width;
                Height = height;
            }
            else
            {
                Console.WriteLine("We get wrong inputs,can build Retangle with not natural properties");
            }
        }
        /// <summary>
        /// default constructor that used the defalt base c'tor and set the size to be 1
        /// </summary>
        public Rectangle() : base()
        {
            Width = 1;
            Height = 1;
        }
        /// <summary>
        /// Override the Display method and implement by displaying the rectangle width and height. 
        /// </summary>
        public override void Display()
        {
            base.Display();
            Console.WriteLine("In this rectangle Height= " + Height + ", Width= " + Width);
        }
        public void Write(StringBuilder sb)
        { sb.AppendLine("Height: " + Height + " Width: " + Width); }
        /// <summary>
        /// Check if this is bigger then the other
        /// first we compare the area 
        /// then the width
        /// and then the heigt
        /// </summary>
        /// <param name="other"></param>
        /// <returns>   positive int if this is bigger then the other
        ///             negative int if the other is bigger
        ///             0 is the are in the same sizes.
        ///         </returns>
        public int CompareTo(Rectangle other)
        {
            return (other.Area - Area != 0) ? (int)Math.Floor(Area - other.Area) :
                (other.Width - Width != 0) ? Width - other.Width :
                (other.Height - Height != 0) ? Height - other.Height : 0;
        }
    }
}
