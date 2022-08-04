using AutoMapper;

namespace SchoolRegister.API.Profiles;

public class GradeProfile : Profile
{
    public GradeProfile()
    {
        CreateMap<Entities.Grade, Models.GradeDto>();
    }
}