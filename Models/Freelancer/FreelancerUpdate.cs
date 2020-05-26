using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Freelancer
{
    public class FreelancerUpdate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public int JobsCompleted { get; set; }
        public double Rating { get; set; }
        public int CodingLanguageId { get; set; }

        //private List<string> _codingLanguage = new List<string>();
        //public List<string> CodingLanguage
        //{
        //    get
        //    {
        //        return _codingLanguage;
        //    }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            if (value.Contains(","))
        //            {
        //                string stringToSplit = value.ToString();
        //                string[] languages = stringToSplit.Split(',');
        //                foreach (var language in languages)
        //                {
        //                    _codingLanguage.Add(language);
        //                }
        //            }
        //            else
        //            {
        //                throw new ArgumentException("Coding languages must be separated by a comma and a space.");
        //            };
        //        }
        //        else
        //        {
        //            throw new ArgumentException("The coding language field cannot be blank!");
        //        }
        //    }
        //}
    }
}
