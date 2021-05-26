using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using XkomAPI.Exceptions;
using XkomAPI.Model;

namespace XkomAPI.Reposiotory
{
    public class xkomRepo : IxkomRepo
    {
        private readonly ApiContex _context;
    
        public xkomRepo(ApiContex context)
        {
            _context = context;
        }

        public void CreateMeeting(Meeting meeting)
        {
            if(meeting is null)
            {
                throw new NotFoundException(nameof(meeting));
            }

            _context.Meetings.Add(meeting);
        }

        public void DeleteMeeting(Meeting meeting)
        {
        
            var members = _context.Users.Where(p => p.MeetingId == meeting.Id).ToList();

            if(members.Count > 0)
            {
                foreach (var user in members)
                {
                    _context.Users.Remove(user);
                }
            }

            _context.Meetings.Remove(meeting);
        }

        public IEnumerable<Meeting> GetAllMeetings()
        {
           var meetings = _context.Meetings.Include(p => p.Members).ToList();

           if(meetings.Count < 1)
            {
                throw new NotFoundException(nameof(meetings));
            }

            return meetings;
        }

        public Meeting GetMeetingById(int Id)
        {
            var meeting = _context.Meetings.Include(p=>p.Members).FirstOrDefault(p => p.Id == Id);

             if(meeting is null)
            {
                throw new NotFoundException(nameof(meeting));
            }

            return meeting;
        }

        public void JoinUserToMeeting(User user)
        {
            var meeting = GetMeetingById(user.MeetingId);

            var memberList = meeting.Members.ToList();
           
            memberList.ForEach(x =>  
            {
                if(x.Email == user.Email)
                {
                    throw new EmailIsTakenException(user.Email);
                }
            });
                   
            if(memberList.Count >= 25)
            {
                throw new MeetingIsFullException();
            }

            _context.Users.Add(user);
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0 );
        }
    }
}