using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_1
{
    class Checker
    {
        public string Name { get; set; }
        public int Id { get;  }
        string SecretInfo {  get; set; }
        public string ReadSecret()
        {
            return SecretInfo;
        }
        public Checker(string name, int id, string secret)
        {
            Name = name;
            Id = id;
            SecretInfo = secret;
        }
        public Checker():this("noName",0,"noSecret")
        {

        }
        public override string ToString()
        {
            return $"{this.GetType()}   Name:{Name}   Id:{Id}   Secret:{this.ReadSecret()}";
        }


        public DateTime StartTimeReturnIfCan(Process p)
        {
            try
            {
                return p.StartTime;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"we get {ex.GetType()} exeption while the process StartTime get ");
                return new DateTime();
            }
        }
    }
}
