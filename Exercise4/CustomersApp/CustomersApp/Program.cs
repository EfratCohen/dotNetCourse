using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Program
    {
        delegate bool CustomerFilter(Customer customer);//8.1.2
        /// <summary>
        /// This method should use the supplied delegate to filter the customer list so that only certain customers are returned. 
        /// </summary>
        /// <param name="customersList"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        static List<Customer> GetCustomers(List<Customer> customersList, CustomerFilter filter)
        {
            var filteredList = new List<Customer>(0);
            foreach (var custumer in customersList)
            {
                if (filter(custumer))
                {
                    filteredList.Add(custumer);
                }
            }
            return filteredList;
        }
        /// <summary>
        /// from Lab 7.1:
        /// Create a Customer array, display it. 
        /// use Array.Sort to sort the array and display the sorted results. 
        ///Lab 8.1:
        ///a. Create a list or array of Customer objects. -i have used the one from Lab 7.1 and add 1 more customer fot the Id chcking
        ///b. Create a delegate of type CustomerFilter that should return a Customer if its name starts with the letters A-K. 
        ///c. Call GetCustomers with the delegate you created in (b) and display the result. 
        ///d. Create another such delegate that returns all customers whose names begin with the letters L-Z. Use an anonymous delegate. 
        ///e. Call GetCustomers again with the new delegate and display the results. 
        ///f. Create another such delegate that returns all customers whose ID is less than 100. Use a lambda expression. 
        ///g. Call GetCustomers again with the new delegate and display the results.  
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MyExperiment();

            Customer[] customerArr = new Customer[6];
            string[] customerNameArr = { "Alex", "Lisa", "Efrat", "efrat", "Jack" };
            string[] customerAddrArr = { "Tel Aviv central bus station", "Beit Hakerem 48 Jerusalem", "Sea Hotel Eilat", "Bar Ilan university", "?" };
            //from Lab 7.1:
            Console.WriteLine("We have created a customer array with length: " + customerArr.Length);
            for (int i = 0; i < 5; i++)
            {
                customerArr[i] = new Customer(customerNameArr[i], i, customerAddrArr[i]);
                Console.WriteLine(customerArr[i].ToString());
            }
            //check the Equals method.
            if (customerArr[2].Equals(customerArr[4])||!customerArr[0].Equals(customerArr[0]))
            {
                Console.WriteLine("The Equals Check faild");
            }
            //check the GetHashCodes method
            if (customerArr[2].GetHashCode() == customerArr[0].GetHashCode())
            {
                Console.WriteLine("The GetHashCode Check faild");
            }
            /**
              Array.Sort(customerArr);
              Console.WriteLine("We sorted this array to receive: ");
              for (int i = 0; i < 5; i++)
              {
                  Console.WriteLine(customerArr[i].Dispay());
              }
              AnotherCustomerComparer ACComparer = new AnotherCustomerComparer();
              Array.Sort(customerArr,ACComparer);//Test the comparer by passing it to Array.Sort call
              Console.WriteLine("We sorted this array again, with the new comparer to receive: ");
              for (int i = 0; i < 5; i++)
              {
                  Console.WriteLine(customerArr[i].Dispay());
              }**/
            var customerWithBigId = new Customer("someone", 156);
            customerArr[5] = customerWithBigId;
            Console.WriteLine(customerArr[5].ToString());
            //from Lab 8.1:
            //8.1.c:
            var implementer = new CustomerFilterImplementer();
            List<Customer> customersListA_K = GetCustomers(customerArr.ToList(), implementer.CustomerFilterImlemention);
            Console.WriteLine("the customer list after the first filering (is name started with A-K) conains:");
            foreach (var customer in customersListA_K)
            {
                Console.WriteLine(customer.Name);

            }
            //8.1.d-e:
            List<Customer> customersListL_Z = GetCustomers(customerArr.ToList(), delegate (Customer customer)
            {
                if (customer.Name.ElementAt(0).CompareTo('L') >= 0 && customer.Name.ElementAt(0).CompareTo('L') <= 'Z' - 'L')
                {
                    return true;
                }
                else return false;
            }
            );
            Console.WriteLine("the customer list after the seconed filering (is name started with L-Z) conains:");
            foreach (var customer in customersListL_Z)
            {
                Console.WriteLine(customer.Name);
            }
            //8.1.f-g:
            List<Customer> customersListid = GetCustomers(customerArr.ToList(), (Customer customer) =>
            {
                if (customer.ID < 100)
                {
                    return true;
                }
                else return false;
            }
            );
            Console.WriteLine("the customer list after the third filering (is id <100) conains:");
            foreach (var customer in customersListid)
            {
                Console.WriteLine(customer.Name);



            }
        }
    }
}
