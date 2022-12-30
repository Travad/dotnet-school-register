using SchoolRegister.Api.Extensions.AutoMapping;
using SchoolRegister.Api.Models.Dto.School;

namespace SchoolRegister.Api.Models.Profiles;

public class SchoolProfile : Profile
{
    public SchoolProfile()
    {
        CreateMap<Location, LocationDto>();
        
        CreateMap<Course, SchoolCoursesDto>()
            .ForMember(cDto => cDto.TotalCourseAttendees,
                act => act.MapFrom(c => c.CourseAttendees.Count()));

        CreateMap<School, SchoolDto>()
            .ForMember(
                sDto => sDto.TotalNumberOfCoursesOffered,
                act => act.MapFrom(s => s.Courses.Count()));

        // .Ignore(courseDto => courseDto.CourseAttendees);
    }
}