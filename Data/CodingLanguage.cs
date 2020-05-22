using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class CodingLanguage
    {
        [Key]
        public int CodingLanguageId { get; set; }
        public string CodingLanguageName { get; set; }


        public CodingLanguage()
        {
            this.Freelancers = new HashSet<Freelancer>();
        }
        public ICollection<Freelancer> Freelancers { get; set; }
    }
}