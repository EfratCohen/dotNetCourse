using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Elipse : Shape, IPersist, IComparable<Elipse> //**Stass gave us the authority to implement IComparable<Elipse> instead of IComparable after we learn about generics
    {
        //properties:
        public int ShortRadious { get; set; }
        public int LongRadious { get; set; }
        public double FocalPointsDistance
        {
            get
            {
                return 2 * Math.Sqrt((LongRadious * LongRadious) - (ShortRadious * ShortRadious));
            }
        }
        public int distancesToTheFocalPointsSum
        {
            get
            { return 2 * LongRadious; }
        }
        //c'tors:
        public Elipse(int shortRadious, int longRadious, ConsoleColor color) : base(color)
        {
            if (longRadious > 0 && shortRadious > 0)
            {
                if (longRadious < shortRadious)
                { Console.WriteLine("We get wrong inputs,the elipse longRadious can't be at less then the shortRadious"); }
                else
                {
                    ShortRadious = shortRadious;
                    LongRadious = longRadious;
                }

            }
            else { Console.WriteLine("We get wrong inputs,can't build elipse with not natural properties"); }

        }
        public Elipse(int shortRadious, int longRadious) : base()
        {
            if (longRadious > 0 && shortRadious > 0)
            {
                if (longRadious < shortRadious)
                { Console.WriteLine("We get wrong inputs,the elipse longRadious can't be at less then the shortRadious"); }
                else
                {
                    ShortRadious = shortRadious;
                    LongRadious = longRadious;
                }
            }
            else { Console.WriteLine("We get wrong inputs,can't build elipse with not natural properties"); }
        }
        public Elipse() : base()
        {
            ShortRadious = 1;
            LongRadious = 2;
        }
        /// <summary>
        /// Implement the abstract property inherited from Shape
        /// </summary>
        public override double Area
        {
            get
            {
                return Math.PI * ShortRadious * LongRadious;
            }
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"In this ellipse long radious= { LongRadious }, short radious= { ShortRadious }");
        }
        public void Write(StringBuilder sb)
        { sb.AppendLine($"Short Radious: { ShortRadious } Long Radious: { LongRadious}"); }
        /// <summary>
        /// Check if this is bigger then the other
        /// first we check the area
        /// then the long radious
        /// and then the short radious
        /// </summary>
        /// <param name="other"></param>
        /// <returns>   positive int if this is bigger then the other
        ///             negative int if the other is bigger
        ///             0 is the are in the same sizes.
        ///         </returns>
        public int CompareTo(Elipse other)
        {
            if (other == null)
            {
                return 1;
            }
            else return (other.Area - Area != 0.0) ? (int)Math.Floor(Area - other.Area) :
               (other.LongRadious - LongRadious != 0) ? LongRadious - other.LongRadious :
               (other.ShortRadious - ShortRadious != 0) ? ShortRadious - other.ShortRadious : 0;
        }
    }
}
