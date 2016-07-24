using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ///2. create an XElement object encapsulating the following information: 
            /// all the classes (not structs or interfaces) in the mscorlib assembly that are public. 
            /// For each class, add elements for each public instance property with its type and name, 
            ///     and all public instance methods with their name (not including inherited ones that are not overridden), 
            ///     return type and parameters(type and name).
            var publicClasses = from publicClassType in typeof(string).Assembly.GetExportedTypes()
                                where publicClassType.IsClass
                                let pClassProperties = publicClassType.GetProperties()
                                select new XElement("Type",
                                    new XAttribute("FullName", publicClassType.FullName),
                                    new XElement("Properties",
                                        from property in pClassProperties
                                        select new XElement("Property",
                                            new XAttribute("Name", property.Name),
                                            new XAttribute("Type", property.PropertyType.FullName ?? "T"))),
                                    new XElement("Methods",
                                        from method in publicClassType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                                        select new XElement("Method",
                                            new XAttribute("Name", method.Name),
                                            new XAttribute("ReturnType", method.ReturnType.FullName ?? "T"),
                                            new XElement("Parameters",
                                                from param in method.GetParameters()
                                                select new XElement("Parameter",
                                                    new XAttribute("Name", param.Name),
                                                    new XAttribute("Type", param.ParameterType))))));
            var mscorlibTypesXml = new XElement("PublicClassesFromMscorlibAssembly", publicClasses);
            mscorlibTypesXml.Save("file4check.xml");
            ///3.
            ///a.List all types that have no properties.Order them by name. Also display how many are there.
            var typesWithNoProperties = from publicClass in publicClasses
                                        where publicClass.Element("Properties").Descendants().Count() == 0
                                        orderby (string)publicClass.Attribute("FullName")
                                        select new
                                        {
                                            FullName = (string)publicClass.Attribute("FullName"),
                                        };
            foreach (var type in typesWithNoProperties)
            {
                Console.WriteLine(type);
            }
            Console.WriteLine($"there are {typesWithNoProperties.Count()} types with no properties");
            ///3.
            ///     b.Count the total number of methods, not including inherited ones. 
            var methodsCount = publicClasses.Sum(pC => pC.Descendants("Method").Count());
            Console.WriteLine($"there are {methodsCount} methods ");
            ///3.
            /// c.Do some more statistics: how many properties are there?  
            var propertiesCount = publicClasses.Sum(pC => pC.Descendants("Property").Count());
            Console.WriteLine($" there are {propertiesCount} properties");
            ///3.
            /// c.cont'
            ///What is the most common type as a parameter ?
            var parametersTypes = from param in publicClasses.Descendants("Parameter")
                                  group param by (string)param.Attribute("Type")
                          into paramsGroup
                                  orderby paramsGroup.Count() descending
                                  select new
                                  {
                                      Name = paramsGroup.Key,
                                      Count = paramsGroup.Count()
                                  };
            Console.WriteLine($"the most common method parameter type is {parametersTypes.First().Name}");
            ///3.
            /// d.Sort the types by the number of methods in descending order. 
            ///     For each get the number of properties and the number of methods. 
            ///     Create a new XML for the results.
            var typesMethodPropNo = from publicClass in publicClasses
                                    let methodsNo = publicClass.Descendants("Method").Count()
                                    orderby methodsNo descending
                                    select new
                                    {
                                        TypeName = (string)publicClass.Attribute("FullName"),
                                        MethodsNo = methodsNo,
                                        PropertiesNo = publicClass.Descendants("Property").Count()
                                    };
            var mscorlibTypesConters = new XElement("typesMethodPropNo", typesMethodPropNo);
            mscorlibTypesConters.Save("file4check2.xml");
            ///3.
            /// e.Group all the types by the number of methods, in descending order based on the number of methods. 
            ///     Within each group sort by type name in ascending order. 
            var methodsNoGroupTypes = from publicClass in publicClasses
                                      let methodsNo = publicClass.Descendants("Method").Count()
                                      orderby (string)publicClass.Attribute("FullName")
                                      group new
                                      {
                                          Methods = methodsNo,
                                          Properties = publicClass.Descendants("Property").Count(),
                                          Name = (string)publicClass.Attribute("FullName")
                                      } by methodsNo
                                           into methodsNoGroup
                                      orderby methodsNoGroup.Key descending
                                      select methodsNoGroup;
            var mscorlibTypesGroups = new XElement("methodsNoGroupTypes", methodsNoGroupTypes);
            mscorlibTypesGroups.Save("file4check3.xml");
        }
    }
}

