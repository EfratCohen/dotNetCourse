using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class CustomerFilterImplementer
    {
        /// <summary>
        /// implemntation of the CustomerFilter as required in lab8.1.5.b
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>true - if the Customer name starts with the letters A-K or false o.w.</returns>
        public bool CustomerFilterImlemention(Customer customer)
        {
            if (customer.Name.ElementAt(0).CompareTo('A') >= 0 && customer.Name.ElementAt(0).CompareTo('A') <= 'K' - 'A')
            {
                return true;
            }
            else return false;
        }
    }
}
