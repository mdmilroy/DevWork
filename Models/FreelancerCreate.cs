using System;
using System.Collections.Generic;

namespace Models.Profiles
{
    public class FreelancerCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StateId { get; set; }

        private List<string> _codingLanguage;

        public List<string> CodingLanguage
        {
            get 
            { 
                return _codingLanguage; 
            }
            set 
            {
                if (value != null)
                {
                    if (value.Contains(","))
                    {
                        string stringToSplit = value.ToString();
                        string[] languages = stringToSplit.Split(',');
                        foreach (var language in languages)
                        {
                            value.Add(language);
                        }
                        _codingLanguage = value;
                    }
                    else
                    {
                        throw new ArgumentException("Coding languages must be separated by a comma and a space.");
                    };
                }
                else
                {
                    throw new ArgumentException("The coding language field cannot be blank!");
                }
            }
        }

    }
}
