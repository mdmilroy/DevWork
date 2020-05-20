using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class CodingLanguage
    {
        [Key]
        public int CodingLanguageId { get; set; }
        public string CodingLanguageName { get; set; }
    }
}