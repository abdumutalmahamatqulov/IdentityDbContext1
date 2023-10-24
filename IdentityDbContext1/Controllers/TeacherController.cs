using IdentityDbContext1.Data;
using IdentityDbContext1.Entities;
using IdentityDbContext1.Generics;
using IdentityDbContext1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityDbContext1.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TeacherController : MoldController<Teacher, TeacherService>
{
    public TeacherController(TeacherService teacherRepository) : base(teacherRepository) { }
}
//public class TeacherController : ControllerBase 
//{
//    private readonly TeacherService _service;

//    public TeacherController(TeacherService service) => _service = service;
//    [HttpGet]
//    public async Task<IActionResult> GetAllTeacher() => Ok(await _service.GetAll());
//    [HttpGet("Id")]
//    public async Task<IActionResult> GetByIdTeacher(int id) => Ok(await _service.GetById(id));
//    [HttpPost]
//    public async Task<IActionResult> CreateTeacher([FromForm] Teacher teacher) => Ok(await _service.Add(teacher));
//    [HttpPut]
//    public async Task<IActionResult> UpdateTeacher(int id, Teacher teacher) => Ok(await _service.Update(id,teacher));
//    [HttpDelete]
//    public async Task<IActionResult>DeleteTeacher(int id)
//    {
//        await _service.Delete(id);
//        return Ok();
//    }
//}
