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
        public int CodingLanguageId { get; set; }
        public string CodingLanguageName { get; set; }

        public CodingLanguage()
        {
            Freelancers = new HashSet<Freelancer>();
        }

        public virtual ICollection<Freelancer> Freelancers { get; set; }
    }
}
