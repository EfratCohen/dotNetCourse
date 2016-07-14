using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class CodeReviewAttribute
    {
        //class should contain 3 properties:
        //the reviewer name, the review date and whether the code is approved.
        // Make sure they are also accessible as standalone properties. 
       public string ReviewerName { get ; set; }
       public date ReviewDate { get; set; }
       public bool IsTheCodeApproved { get; set; }
        //Add a constructor that accepts all 3 properties
        public CodeReviewAttribute(string name,date day,bool approved)
        {
            ReviewerName = name;
            ReviewDate = day;
            IsTheCodeApproved = approved;
        }
        ///Add the AttributeUsage attribute to the class 
        ///to allow the attribute on classes and structs only 
        ///(multiple usages are allowed).


    }
    struct date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public date(int day,int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }
}
