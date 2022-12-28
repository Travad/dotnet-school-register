using AutoMapper;
using SchoolRegister.Models.Dto;
using SchoolRegister.Models.Entities;

namespace SchoolRegister.API.Profiles;

public class AttendeeProfile : Profile
{
    public AttendeeProfile()
    {
        CreateMap<Attendee, AttendeeDto>();
    }
}