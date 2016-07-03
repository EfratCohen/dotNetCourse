using ShapeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp
{
    class ShapeManager
    {
        /// <summary>
        /// An ArrayList field holding shapes. 
        /// </summary>
        List<Shape> _shapes; //**Stass gave us the authority to use List<Shape > instead of ArrayList after we learn about generics
        /// <summary>
        /// c'tor
        /// </summary>
        public ShapeManager()
        {
            _shapes = new List<Shape>(0);
        }
        /// <summary>
        /// read only property  
        /// returning the total number of managed shapes.
        /// </summary>
        public int Count
        {
            get
            {
                return _shapes.Count;
            }
        }
        /// <summary>
        /// A public read only indexer 
        /// </summary>
        /// <param name="index"></param>
        /// <returns>a shape in a specified index</returns>
        public Shape this[int index]
        {
            get
            {
                return _shapes[index];
            }
        }
        /// <summary>
        /// accepts a Shape and adds it to the collection. c
        /// </summary>
        /// <param name="newShape"></param>
        public void Add(Shape newShape)
        {
            _shapes.Add(newShape);
        }
        /// <summary>
        /// calls Display and Area for all shapes in the collection.
        /// </summary>
        public void DisplayAll()
        {
            foreach (Shape shape in _shapes)
            {
                shape.Display();
                Console.WriteLine("it's area= " + shape.Area);
            }
        }
        /// <summary>
        /// accepts a StringBuilder and calls Write on all shapes that implement IPersist. 
        /// </summary>
        /// <param name="sb"></param>
        public void save(StringBuilder sb)
        {
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (_shapes[i] is Elipse)
                {
                    Elipse elipse = (Elipse)_shapes[i];
                    elipse.Write(sb);
                }
                else if (_shapes[i] is Rectangle)
                {
                    Rectangle rect = (Rectangle)_shapes[i];
                    rect.Write(sb);
                }
            }
        }

    }
}
