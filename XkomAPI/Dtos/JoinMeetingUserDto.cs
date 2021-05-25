using System.ComponentModel.DataAnnotations;

namespace XkomAPI.Dtos
{
    public class JoinMeetingUserDto
    {
        public string Email { get; set;}
        public string Surname { get; set; }
        public int MeetingId { get; set; }
    }
}