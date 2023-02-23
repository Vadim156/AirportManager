using FinalProj.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Logic.Models
{
    public class Logger
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Flight Flight { get; set; } = null!;
        public Terminal? Terminal { get; set; }
        [Required]

        public DateTime In { get; set; }
        public DateTime? Out { get; set; }
    }
}
