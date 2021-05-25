using System.ComponentModel.DataAnnotations;

namespace XkomAPI.Dtos
{
    public class JoinMeetingUserDto
    {
        [Required]
        public string Email { get; set;}
        [Required]
        public string Surname { get; set; }
        [Required]
        public int MeetingId { get; set; }
    }
}