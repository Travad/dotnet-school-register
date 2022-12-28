using AutoMapper;
using SchoolRegister.Models.Dto;
using SchoolRegister.Models.Entities;

namespace SchoolRegister.API.Profiles;

public class CourseAttendeeProfile : Profile
{
    public CourseAttendeeProfile()
    {
        CreateMap<CourseAttendee, CourseAttendeeDto>();
    }
}