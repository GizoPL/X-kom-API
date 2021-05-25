using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XkomAPI.Model
{
    public class Meeting 
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public string NameOfMeeting { get; set;}
        [Required]
        public string OwnerOfMeetng { get; set; }
        [Required]
        public DateTime MeetingDateTime { get; set; }

        public virtual ICollection<User> Members { get; set; }

    }
}