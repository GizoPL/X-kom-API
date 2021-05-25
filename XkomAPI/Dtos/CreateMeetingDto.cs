using System;
using System.ComponentModel.DataAnnotations;

namespace XkomAPI.Dtos
{
    public class CreateMeetingDto
    {
        [Required]
        public string NameOfMeeting { get; set;}
        [Required]
        public string OwnerOfMeetng { get; set; }
        [Required]
        public DateTime MeetingDateTime { get; set; }
    }
}