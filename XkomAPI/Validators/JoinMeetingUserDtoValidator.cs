using FluentValidation;
using XkomAPI.Dtos;

namespace XkomAPI.Validators
{
    public class JoinMeetingUserDtoValidator : AbstractValidator<JoinMeetingUserDto>
    {
        public JoinMeetingUserDtoValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(p => p.Surname)
                .NotEmpty();
            
            RuleFor(p => p.MeetingId)
                .NotEmpty();
                
        }
    }
}