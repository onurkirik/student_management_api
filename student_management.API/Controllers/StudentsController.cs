using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using student_management.Application.Services;
using student_management.Domain.Entities;
using student_management.Persistance.Context;

namespace student_management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _studentService.GetAll());
        }

        [HttpGet]
        [Route("get-student")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _studentService.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("create-student")]
        public async Task<IActionResult> Create(Student model)
        {
            await _studentService.AddAsync(model);
            return Ok();
        }

        [HttpDelete]
        [Route("delete-student")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _studentService.Delete(id);
            return Ok();
        }

        [HttpPut]
        [Route("update-student")]
        public async Task<IActionResult> Update(Student model)
        {
            await _studentService.Update(model);
            return Ok();
        }
    }
}
