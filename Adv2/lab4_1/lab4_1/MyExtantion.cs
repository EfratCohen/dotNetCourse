using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_1
{
    /// <summary>
    /// 2.
    ///  (*) Create an extension method that extends object with a method called CopyTo 
    ///  that copies all public properties from this object to another object passed as argument.
    ///  Make sure only writable properties are written and readable properties are read. Use LINQ. 
    /// </summary>
    static public class MyExtantion
    {
        static public void CopyTo(this object source, object target)
        {
            if (target != null)
            {
                var sourceType = source.GetType(); 
                var targetType = target.GetType();
                var sourceProperties = sourceType.GetProperties().Where(sourceProperty=>(sourceProperty.CanRead));
                var targetProperties = targetType.GetProperties().Where(targetProperty=>(targetProperty.CanWrite));
                foreach (var sourcePropInfo in sourceProperties.
                    Where(sPi => (targetProperties.Any(tPi => (tPi.Name == sPi.Name && tPi.PropertyType == sPi.PropertyType)))))
                {
                    var targetPropInfo = targetType.GetProperty(sourcePropInfo.Name);
                    targetPropInfo.SetValue(target, sourcePropInfo.GetValue(source));
                }
            }
        }
    }
}
