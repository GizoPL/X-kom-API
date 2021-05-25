using AutoMapper;
using XkomAPI.Dtos;
using XkomAPI.Model;

namespace XkomAPI.ProfileDto
{
    public class XkomProfile : Profile
    {
        public XkomProfile()
        {
            CreateMap<Meeting, CreateMeetingDto>().ReverseMap();
            CreateMap<User, JoinMeetingUserDto>().ReverseMap();
            CreateMap<Meeting, ReadMeetingDto>().ReverseMap();
            CreateMap<User, ReadUserDto>().ReverseMap();
        
        }
    }
}