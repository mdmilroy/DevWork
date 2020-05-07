using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class CodingLanguage
    {
        [Key]
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
    }
}