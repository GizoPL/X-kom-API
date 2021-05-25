using System;
using System.Collections.Generic;

namespace XkomAPI.Dtos
{
    public class ReadMeetingDto
    {
        public int Id {get; set;}
       
        public string NameOfMeeting { get; set;}
       
        public string OwnerOfMeetng { get; set; }
        
        public DateTime MeetingDateTime { get; set; }

        public virtual ICollection<ReadUserDto> Members { get; set; }
    }
}