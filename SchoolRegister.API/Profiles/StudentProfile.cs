using AutoMapper;

namespace SchoolRegister.API.Profiles;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Entities.Student, Models.StudentDto>();
    }
}