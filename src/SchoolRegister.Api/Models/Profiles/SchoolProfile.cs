using SchoolRegister.Api.Extensions.AutoMapping;

namespace SchoolRegister.Api.Models.Profiles;

public class SchoolProfile : Profile
{
    public SchoolProfile()
    {
        CreateMap<School, SchoolDto>();
   
        CreateMap<Location, LocationDto>();

        CreateMap<Course, CourseDto>()
            .Ignore(courseDto => courseDto.CourseAttendees);
    }
}