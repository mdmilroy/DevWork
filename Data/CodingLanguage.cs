using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CodingLanguage
    {
        [Key]
        [Display(Name = "Coding Language Id")]
        public int CodingLanguageId { get; set; }

        [Display(Name="Coding Language Name")]
        public string CodingLanguageName { get; set; }

        public CodingLanguage()
        {
            Freelancers = new HashSet<Freelancer>();
        }

        public virtual ICollection<Freelancer> Freelancers { get; set; }
    }
}
