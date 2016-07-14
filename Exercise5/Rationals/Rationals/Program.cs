using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    class Program
    {
        /// <summary>
        ///  Create some Rational objects, 
        ///  initialize with some values, 
        ///  test the code you created to make sure all methods work as expected.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                int instacesNumber = 7;
                Console.WriteLine("Rationl test with instacesNumber =" + instacesNumber);

                Rational[] rationalArray = new Rational[instacesNumber];
                for (int i = 0; i < instacesNumber; i++)
                {
                    if (i > instacesNumber / 2)
                    {
                        rationalArray[i] = new Rational(i, i * instacesNumber);
                    }//first c'tor check
                    else
                    {
                        rationalArray[i] = new Rational(i);
                    }                     //second c'tor check
                    Console.WriteLine(rationalArray[i].ToString());                 //ToString check
                }

                //from lab 3.2:           
                /*            for (int i = 0; i < instacesNumber; i++)
                           {
                               Console.WriteLine("the rationalArray at index " + i + " has Ratio property of " + rationalArray[i].Ratio);    //Ratio property check
                           }
                          //Add method check //Mul method check//Reduce method check
                           for (int i = 0; i < instacesNumber; i++)
                           {
                               if (i % 2 == 0)
                               {
                                   rationalArray[i] = rationalArray[i].Add(ref rationalArray[i], ref rationalArray[i]);
                                   Console.Write("Add- ");
                               }
                               else
                               {
                                   rationalArray[i] = rationalArray[i].Mul(ref rationalArray[i], ref rationalArray[i]);
                                   Console.Write("Mul- ");
                               }
                               Console.WriteLine(rationalArray[i].ToString());
                           }
                           Rational r0 = new Rational(0);
                           Rational r1 = new Rational(1);
                           //Equals method check
                           if (r0.Equals(rationalArray[0])) { Console.WriteLine("r0==rationalArray[0]"); }
                           else { Console.WriteLine("equls test0 faild"); }
                           if (!(r1.Equals(rationalArray[1]))) { Console.WriteLine("r1!=rationalArray[1]"); }
                           else { Console.WriteLine("equls test1 faild"); }
               */
                //the Appendix lab:
                //Check operators for +,-,*,/ for the Rational type
                for(int i=0; i<instacesNumber/2; i++)
                {
                    Console.WriteLine($"{rationalArray[i]}+{rationalArray[i+1]}={rationalArray[i] + rationalArray[i + 1]}");
                    Console.WriteLine($"{rationalArray[i]}-{rationalArray[i+1]}={rationalArray[i] - rationalArray[i + 1]}");
                    Console.WriteLine($"{rationalArray[i]}*{rationalArray[i+1]}={rationalArray[i] * rationalArray[i + 1]}");
                    Console.WriteLine($"{rationalArray[i]}/{rationalArray[i+1]}={rationalArray[i] / rationalArray[i + 1]}");
                }
                //Check casting operator to double and from an integer
                for (int i = 0; i < instacesNumber; i++)
                {
                    Console.WriteLine($"the {rationalArray[i]} casting to double is {(double)rationalArray[i]}");
                }
                Rational[] rationalArray2 = new Rational[1];
                Console.WriteLine($"{rationalArray2[0]}");
                var r=rationalArray[0] * rationalArray2[0];
            }
            catch (DivideByZeroException ex0)
            {
                Console.WriteLine(ex0.Message);
            }
        }

    }
    struct Rational
    {   //Field and their properties
        int Numerator { get; set; }
        int Denominator { get; set; } 
        public double Ratio
        {
            get
            {
                double ratio = (double)this.Numerator / (double)this.Denominator;
                return ratio;
            }
        } //another property that returns the value as a double
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// throw DivideByZeroException if denominator==0
        public Rational(int numerator, int denominator)
        {
            Numerator = numerator;
            if (denominator == 0)
            {
                throw new DivideByZeroException("we  get an 0 denominator value");
                //from lab 3.2: (before exeptions)
                /**
                Console.WriteLine("error! can't divide by 0!\n we didn't get an appropriate denominator value so we set it defoultly to be 1");
                Denominator = 1
                **/
            }
            else { Denominator = denominator; }

        }
        /// <summary>
        /// another constructor
        /// </summary>
        /// <param name="numerator"></param>
        public Rational(int numerator) : this(numerator, 1) { }
        /// <summary>
        ///  adds two Rational objects
        /// </summary>
        /// <param name="r1">first instace for the adding</param>
        /// <param name="r2">second instace for the adding</param>
        /// <returns>new Rational instance which his value is the inputs sum</returns>
        public Rational Add(ref Rational r1, ref Rational r2)
        {
            Rational rSum = new Rational(r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator);
            rSum.Reduce(ref rSum);
            return rSum;
        }
        /// <summary>
        ///  multiplies Rational objects
        /// </summary>
        /// <param name="r1">first instace for the multiplieng</param>
        /// <param name="r2">second instace for the multiplieng</param>
        /// <returns> new Rational instance which his value is the inputs multiply </returns>
        public Rational Mul(ref Rational r1, ref Rational r2)
        {
            Rational rMul = new Rational(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
            rMul.Reduce(ref rMul);
            return rMul;
        }
        /// <summary>
        ///  simplify the Rational object
        /// </summary>
        /// <param name="r">ref of the Rational object to simplify</param>
        public void Reduce(ref Rational r)
        {
            bool negativeSign;
            if ((r.Numerator > 0 && r.Denominator > 0) || (r.Numerator < 0 && r.Denominator < 0))
            {
                negativeSign = false;
            }
            else
            {
                negativeSign = true;
            }

            int numerator = Math.Abs(r.Numerator), denominator = Math.Abs(r.Denominator), gcd;
            if (numerator > denominator)
            {
                gcd = GCD(numerator, denominator);
            }
            else
            {
                gcd = GCD(denominator, numerator);
            }
            if (negativeSign)
            {
                r.Numerator = numerator * (-1) / gcd;
            }
            else
            {
                r.Numerator = numerator / gcd;
            }

            r.Denominator = denominator / gcd;
        }
        /// <summary>
        ///  Override ToString with appropriate implementation
        /// </summary>
        /// <returns>string with the instance type +brief description of it's field's value </returns>
        public override string ToString()
        {
            return $"{this.Numerator.ToString() }/{ this.Denominator}";
        }
        /// <summary>
        /// Override Equals with appropriate implementation
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            if (this.ToString() == obj.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Euclidean algorithm,
        /// an efficient method for computing the greatest common divisor (GCD) of two numbers.
        /// </summary>
        /// <param name="biggerInt"></param>
        /// <param name="smallerInt"></param>
        /// <returns></returns>
        private int GCD(int biggerInt, int smallerInt)
        {
            return (smallerInt == 0) ? biggerInt : GCD(smallerInt, biggerInt % smallerInt);
        }
        /// <summary>
        ///  override object.GetHashCode
        /// </summary>
        /// <returns>int with the hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //the Appendix lab:
        //Add operators for +,-,*,/ for the Rational type
        public static Rational operator +(Rational r1, Rational r2)
        {
            return r1.Add(ref r1,ref r2);
        }
        public static Rational operator -(Rational r1, Rational r2)
        {
            r2.Numerator = -r2.Numerator;
            return r1.Add(ref r1,ref r2);
        }
        public static Rational operator *(Rational r1, Rational r2)
        {
            return r1.Mul(ref r1, ref r2);
        }
        public static Rational operator /(Rational r1, Rational r2)
        {
            var oneDivr2 = new Rational(r2.Denominator, r2.Numerator);
            return r1.Mul(ref r1, ref oneDivr2);
        }
        //Add casting operator to double and from an integer
        public static explicit operator Rational(int x)  // explicit byte to digit conversion operator
        {
            return new Rational(x);
        }
        public static explicit operator double(Rational r)  // explicit byte to digit conversion operator
        {
            return r.Ratio;
        }

    }
}