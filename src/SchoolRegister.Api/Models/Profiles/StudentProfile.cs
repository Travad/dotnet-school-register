using AutoMapper;
using SchoolRegister.Api.Models.Dto;
using SchoolRegister.Models.Entities;

namespace SchoolRegister.API.Profiles;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentDto>();
    }
}