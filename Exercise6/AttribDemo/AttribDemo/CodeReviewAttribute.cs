using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [System.AttributeUsage(AttributeTargets.Struct|AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    class CodeReviewAttribute : Attribute
    {
        //class should contain 3 properties:
        //the reviewer name, the review date and whether the code is approved.
        // Make sure they are also accessible as standalone properties. 
        public string ReviewerName { get; set; }
        public string ReviewDate { get; set; }
        public bool IsTheCodeApproved { get; set; }
        //Add a constructor that accepts all 3 properties
        public CodeReviewAttribute(string name, string day, bool approved)
        {
            ReviewerName = name;
            ReviewDate = day;
            IsTheCodeApproved = approved;
        }
    }
}
