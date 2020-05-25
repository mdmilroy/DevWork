using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Profiles
{
    public class FreelancerCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CodingLanguage { get; set; }
        public int StateId { get; set; }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

    }
}
