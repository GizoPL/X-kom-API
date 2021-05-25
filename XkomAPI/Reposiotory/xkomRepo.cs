using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            //  if(meeting is null)
            // {
            //     throw new ArgumentNullException(nameof(meeting));
            // }

            _context.Meetings.Add(meeting);
        }

        public void DeleteMeeting(Meeting meeting)
        {
            // if(meeting is null)
            // {
            //     throw new  ArgumentNullException(nameof(meeting));
            // }

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
            return _context.Meetings.Include(p => p.Members).ToList();
        }

        public Meeting GetMeetingById(int Id)
        {
            var meeting = _context.Meetings.Include(p=>p.Members).FirstOrDefault(p => p.Id == Id);

            return meeting;
        }

        public void JoinUserToMeeting(User user)
        {
            var meeting = GetMeetingById(user.MeetingId);

            // if(meeting is null)
            // {
            //     throw new ArgumentNullException(nameof(meeting));
            // }
           
            var memberList = meeting.Members.ToList();
           
            memberList.ForEach(x =>  
            {
                if(x.Email == user.Email)
                {
                    throw new Exception("Email is taken!");
                }
            });
                   
            if(memberList.Count >= 25)
            {
                throw new Exception("Meeting is full!");
            }

            _context.Users.Add(user);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0 );
        }
    }
}