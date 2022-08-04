using AutoMapper;

namespace SchoolRegister.API.Profiles;

public class CourseAttendeeProfile : Profile
{
    public CourseAttendeeProfile()
    {
        CreateMap<Entities.CourseAttendee, Models.CourseAttendeeDto>();
    }
}