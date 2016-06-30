using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public class AnotherCustomerComparer : IComparer<Customer>
    {
        /// <summary>
        /// compare  the customers IDs
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>positive int if x>y; negative if y>x; and 0 if x==y</returns>
        public int Compare(Customer x, Customer y)
        {
            return x.ID - y.ID;
        }
    }
}
