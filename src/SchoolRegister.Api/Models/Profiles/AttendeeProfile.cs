using SchoolRegister.Api.Models.Dto;

namespace SchoolRegister.Api.Services.Profiles;

public class AttendeeProfile : Profile
{
    public AttendeeProfile()
    {
        CreateMap<Attendee, AttendeeDto>();
    }
}