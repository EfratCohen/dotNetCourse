using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_1
{
    /// <summary>
    /// 2.
    ///  (*) Create an extension method that extends object with a method called CopyTo 
    ///  that copies all public properties from this object to another object passed as argument.
    ///  Make sure only writable properties are written and readable properties are read. Use LINQ. 
    /// </summary>
    static public class ExtantionMaker
    {
        static public void CopyTo(this object fromMe, object toOther)//rename!!!
        {
            if (toOther != null)
            {
                var targetType = fromMe.GetType(); //add checks.
                var origType = toOther.GetType();
                var origPropertiesList = targetType.GetProperties();
                var targetPropertiesList = origType.GetProperties();
                foreach (var origPropInfo in origPropertiesList.Where(o=>(targetPropertiesList.Any(t=>(t.Name==o.Name&&t.PropertyType==o.PropertyType)))))
                {
                    var targetPropInfo = origType.GetProperty(origPropInfo.Name);
                   
                    targetPropInfo.SetValue(toOther, origPropInfo.GetValue(fromMe);                    
                }
                
              

            }
        }
    }
}
