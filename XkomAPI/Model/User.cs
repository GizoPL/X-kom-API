using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XkomAPI.Model
{
    public class User
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public string Email { get; set;}
        [Required]
        public string Surname { get; set; }
        
        public int MeetingId { get; set; }

        [ForeignKey("MeetingId")]
        public virtual Meeting Meeting { get; set; }
    }
}