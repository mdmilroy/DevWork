using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class CodingLanguage
    {
        [Key]
        public int CodingLanguageId { get; set; }
        public string CodingLanguageName { get; set; }

        public string FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
    }
}