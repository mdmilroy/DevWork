using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
}