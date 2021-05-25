using System.Collections.Generic;
using XkomAPI.Dtos;
using XkomAPI.Model;

namespace XkomAPI.Reposiotory
{
    public interface IxkomRepo
    {
        void CreateMeeting(Meeting meeting);
        Meeting GetMeetingById(int Id); 
        IEnumerable<Meeting> GetAllMeetings();
        void DeleteMeeting(Meeting meeting);
        void JoinUserToMeeting(User user);
        bool SaveChanges();
    }
}