using ShapeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp
{
    class Program
    {
        /// <summary>
        /// Create an instance of ShapeManager
        /// Add several different shapes to the ShapeManager you just created
        /// Call DisplayAll and make sure you get the expected result. 
        /// (5.2.) call the Save method and display the resulting StringBuilder using its ToString method.
        /// Test my implementations
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ShapeManager shapeManager = new ShapeManager();
            //not acceptable constructors -
            Circle c_1 = new Circle(-1); Circle c_2 = new Circle(0, ConsoleColor.DarkRed);
            Elipse e_1 = new Elipse(-6, 1); Elipse e_2 = new Elipse(-3, -5, ConsoleColor.DarkGreen);
            Elipse e_3 = new Elipse(7, 0);
            Rectangle r_1 = new Rectangle(-1, -3); Rectangle r_2 = new Rectangle(2, 0, ConsoleColor.DarkYellow);
            Rectangle r_3 = new Rectangle(-1, 3);
            //they only alarm when they are consructed because i did'nt used exeptions
            //I will do it in the next lab.
            //the valid constructors
            Circle c1 = new Circle(); Circle c2 = new Circle(2, ConsoleColor.Red);
            Elipse e1 = new Elipse(); Elipse e2 = new Elipse(3, 5, ConsoleColor.Green);
            Elipse e3 = new Elipse(6, 7);
            Rectangle r1 = new Rectangle(); Rectangle r2 = new Rectangle(2, 6, ConsoleColor.Yellow);
            Rectangle r3 = new Rectangle(1, 3);
            shapeManager.Add(c1); shapeManager.Add(c2);
            shapeManager.Add(e1); shapeManager.Add(e2); shapeManager.Add(e3);
            shapeManager.Add(r1); shapeManager.Add(r2); shapeManager.Add(r3);
            Console.WriteLine($"we create Shape manager and insert {shapeManager.Count} shpes");
            shapeManager.DisplayAll();
            // call the Save method and display the resulting StringBuilder using its ToString method.
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("we used a StringBuilder and save to him this text \n about all the shapes in our shape menger: ");
            shapeManager.save(sb);
            Console.WriteLine(sb.ToString());
            //checking CompareTo
            Circle c1blue = new Circle(1, ConsoleColor.Blue);
            if (c1blue.CompareTo(c1) == 0)
            {
                Console.WriteLine("the circle c1:");
                c1.Display();
                Console.WriteLine("and the circle c1blue:");
                c1blue.Display();
                Console.WriteLine("are equal according to CompareTo");
            }
            else
            { Console.WriteLine("CompareTo error"); }
            if (r2.CompareTo(r3) > 0)
            {
                Console.WriteLine("the Rectangle r2:");
                r1.Display();
                Console.WriteLine("is bigger then Rectangle r3:");
                r3.Display();
            }
            else
            { Console.WriteLine("CompareTo error"); }
        }
    }
}
