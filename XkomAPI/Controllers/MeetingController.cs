using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XkomAPI.Model;
using XkomAPI.Reposiotory;

namespace XkomAPI.Dtos
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IxkomRepo _repository;
        public MeetingController(IMapper mapper, IxkomRepo repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet("getAllMeetings")]
        public ActionResult<IEnumerable<ReadMeetingDto>> GetAllMeetings()
        {
            var meetings = _repository.GetAllMeetings();
            
            return Ok(_mapper.Map<IEnumerable<ReadMeetingDto>>(meetings));
        }

        [HttpGet("getMeetingById/{id}", Name ="getMeetingById")]
        public ActionResult<ReadMeetingDto> GetMeetingById(int id)
        {
            var meeting = _repository.GetMeetingById(id);
            
            return Ok(_mapper.Map<ReadMeetingDto>(meeting));
        }

        [HttpPost("createMeeting")]
        public ActionResult<ReadMeetingDto> CreateMeeting(CreateMeetingDto createMeetingDto)
        {
            var meeting = _mapper.Map<Meeting>(createMeetingDto);

            _repository.CreateMeeting(meeting);

            _repository.SaveChanges();

            var readMeetingDto = _mapper.Map<ReadMeetingDto>(meeting);
    
            return CreatedAtRoute(nameof(GetMeetingById), new {id = readMeetingDto.Id}, createMeetingDto);
        }

        [HttpDelete("deleteMeetingById/{id}")]
        public ActionResult DeleteMeeting(int id)
        {
            var meeting = _repository.GetMeetingById(id);

            if(meeting is null)
            {
                return NotFound();
            }

            _repository.DeleteMeeting(meeting);

            _repository.SaveChanges();
            
            return NoContent();
        }
    }
}