using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        //Properties:
        public string Name { get; private set; }
        public int ID { get; private set; }
        public string Address { get; private set; }
        /// <summary>
        /// basic c'tor
        /// </summary>
        /// <param name="id"></param>
        public Customer(int id) : this("No name", id, "No Adrr")
        { }
        /// <summary>
        /// another c'tor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public Customer(string name, int id) : this(name, id, "No Adrr")
        { }
        /// <summary>
        /// full paremeters constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <param name="address"></param>
        public Customer(string name, int id, string address)
        {
            Name = name;
            ID = id;
            Address = address;
        }
        /// <summary>
        /// compare this to other Customer,
        ///using the Name property only in a case insensitive way
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        ///         positve int if this is bigger ( and when the paremeter is null)
        ///         negative if the other is bigger
        ///         0- if they are equal</returns>
        public int CompareTo(Customer other)
        {
            if(other==null)
            { return 1; }
            else
            return string.Compare(Name, other.Name, true);
        }
        /// <summary>
        /// override object.Equals
        ///  check if this is equal to the other by comparing Name (as we do in CompareTo method)
        ///  and by comparing ID of the customers
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns> 
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Customer other = (Customer)obj;
            if (Name == other.Name && ID == other.ID)
            { return true; }
            else
            { return false; }
        }
        bool IEquatable<Customer>.Equals(Customer other)
        {
            return this.Equals(other);
        }
        /// override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode()+ID;
        }
        /// <summary>
        /// <returns>string with the type and properties description of this Customer</returns>
        public override string ToString()
        {
            return ($"CustomersApp.Customer  name: { Name } ID:  { ID } adress:  { Address}");
        }

    }
}
