using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 1. Create a new Console application named XLinq. 
/// 2. (*) In the Main method, create an XElement object encapsulating the following information: 
/// all the classes (not structs or interfaces) in the mscorlib assembly that are public. 
/// For each class, add elements for each public instance property with its type and name, 
///     and all public instance methods with their name (not including inherited ones that are not overridden), 
///     return type and parameters(type and name). The resulting XML should look something like this:   
///    ...
/// 3. (*) Create the following queries on the resulting XML: 
/// a.List all types that have no properties.Order them by name. Also display how many are there. 
/// b.Count the total number of methods, not including inherited ones. 
/// c.Do some more statistics: how many properties are there? What is the most common type as a parameter?  
/// d.Sort the types by the number of methods in descending order. 
///     For each get the number of properties and the number of methods. 
///     Create a new XML for the results.
/// e.Group all the types by the number of methods, in descending order based on the number of methods. 
///     Within each group sort by type name in ascending order. 
/// </summary>
namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
