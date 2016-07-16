using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class AssemblyAnalayzer
    {
        /// <summary>
        /// The method should traverse all types (Assembly.GetTypes or Assembly.GetExportedTypes)
        /// looking for the CodeReviewAttribute. If found, it should output to the console all the review details. 
        /// Eventually it should return the correct value as described. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>whether or not all reviewed types are approved</returns>
        public bool AnalayzeAssembly(Assembly asm)
        {
            var inputsTypes = asm.GetTypes();
            inputsTypes=inputsTypes.Where(type => type.IsClass || type.IsValueType).ToArray<Type>();
            Console.WriteLine($"in the assembly we get we have {inputsTypes.Count()} relevant types \n");
            foreach (var type in inputsTypes)
            {
                var codeReviews = type.GetCustomAttributes(typeof(CodeReviewAttribute));
                foreach (var codeReview in codeReviews)
                {
                    CodeReviewAttribute thisReview =(CodeReviewAttribute)codeReview;
                    Console.WriteLine($"CodeReview about type {type}");
                    Console.WriteLine($"reviewer name: {thisReview.ReviewerName} the review date: {thisReview.ReviewDate} is the code approved?: {thisReview.IsTheCodeApproved}");
                    if (!thisReview.IsTheCodeApproved)
                    {
                        return false;
                    }
                }  
            }
            return true;
        }
    }
}
