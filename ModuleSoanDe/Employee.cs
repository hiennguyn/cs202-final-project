using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleSoanDe
{
    class Employee
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public double Score { get; set; }
        public string rightAnswer { get; set; }
        public string testID { get; set; }

        public override string ToString()
        {
            return Date + " | " + testID + " | " + Name + " | " + rightAnswer + " | " + Score.ToString();
        }
    }
}
