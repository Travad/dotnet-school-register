using AutoMapper;

namespace SchoolRegister.API.Profiles;

public class AttendeeProfile : Profile
{
    public AttendeeProfile()
    {
        CreateMap<Entities.Attendee, Models.AttendeeDto>();
    }
}