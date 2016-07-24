using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        /// <summary>
        ///  2. (*) In the Main method, create an XElement object encapsulating the following information: 
        /// all the classes (not structs or interfaces) in the mscorlib assembly that are public. 
        /// For each class, add elements for each public instance property with its type and name, 
        ///     and all public instance methods with their name (not including inherited ones that are not overridden), 
        ///     return type and parameters(type and name).
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
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //2.
            var mscorlibTypesXml = new XElement("PublicClassesFromMscorlibAssembly", from publicClassType in typeof(string).Assembly.GetTypes()
                                                                         where publicClassType.IsPublic && publicClassType.IsClass
                                                                         select new XElement("PublicClass",
                                          new XAttribute("FullName", publicClassType.FullName),
                                          new XElement("Properties",
                                          from publicProperty in publicClassType.GetProperties().Where(propInfo => (propInfo.CanRead))
                                          select new XElement("Property",
                                              new XAttribute("Name", publicProperty.Name),
                                              new XAttribute("Type", publicProperty.PropertyType))),
                                              new XElement("Methods",
                                         from InstanceMethod in publicClassType.GetMethods(System.Reflection.BindingFlags.DeclaredOnly)
                                         select new XElement("Method",
                                                  new XAttribute("Name", InstanceMethod.Name),
                                                  new XAttribute("ReturnType", InstanceMethod.ReturnType),
                                                  new XElement("Parameters",
                                                  from param in InstanceMethod.GetParameters()
                                                  select new XElement("Parameter",
                                                            new XAttribute("Name", param.Name),
                                                            new XAttribute("Type", param.ParameterType)))))));
            //3.//a.List all types that have no properties.Order them by name. Also display how many are there.
            var typesWithNoProperties = from publicClass in mscorlibTypesXml.Descendants("PublicClass")
                                        where publicClass.Element("Properties").IsEmpty
                                        orderby (string)publicClass.Attribute("FullName")
                                        select new {
                                            FullName = (string)publicClass.Attribute("FullName"),
                                        };
            foreach (var type in typesWithNoProperties)
            {
                Console.WriteLine(type);
            }
            Console.WriteLine($"there are {typesWithNoProperties.Count()} types with no properties");
            //b.Count the total number of methods, not including inherited ones. 
            var methods = from typesMethod in mscorlibTypesXml.Descendants("Methods")
                                        select new 
                                        {
                                           Method = typesMethod.Element("Method")
                                        };
            var methodsCount = methods.Count();
            Console.WriteLine($"there are {methodsCount} methods ");
            // c.Do some more statistics: how many properties are there? 
            var properties = from typesProperties in mscorlibTypesXml.Descendants("Properties")
                          select new
                          {
                              property = typesProperties.Element("Property")
                          };
            var propertiesCount = properties.Count();
            Console.WriteLine($" there are {propertiesCount} properties");
            //What is the most common type as a parameter ?
            


        }
    }
}
