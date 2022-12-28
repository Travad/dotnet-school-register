using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.API.Services.Repositories.Students;
using SchoolRegister.Models.Dto;

namespace SchoolRegister.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudents()
    {
        var students = await _studentRepository.GetAllStudentsAsync();
        var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);
        return Ok(studentsDto);
    }
    
    [HttpGet("{studentId}")]
    public async Task<ActionResult<StudentDto>> GetStudentById(int studentId)
    {
        var student = await _studentRepository.GetStudentByIdAsync(studentId);
        
        if (student == null)
            return NotFound();
        
        return Ok(_mapper.Map<StudentDto>(student));
    }
}