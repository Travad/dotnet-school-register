using AutoMapper;
using SchoolRegister.Models.Dto;
using SchoolRegister.Models.Entities;

namespace SchoolRegister.API.Profiles;

public class GradeProfile : Profile
{
    public GradeProfile()
    {
        CreateMap<Grade, GradeDto>();
    }
}