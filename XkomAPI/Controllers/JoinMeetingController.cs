using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XkomAPI.Dtos;
using XkomAPI.Model;
using XkomAPI.Reposiotory;

namespace XkomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinMeetingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IxkomRepo _repository;

        public JoinMeetingController(IMapper mapper, IxkomRepo repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpPost]
        public ActionResult JoinToMeeting(JoinMeetingUserDto joinMeetingUserDto)
        {
            var user = _mapper.Map<User>(joinMeetingUserDto);

            _repository.JoinUserToMeeting(user);
            
            _repository.SaveChanges();

            return Ok();          
        }
        
    }
}