﻿using Microsoft.AspNetCore.Http;
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
        [Route("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            return Ok(await _studentService.GetByIdAsync(id));
        }

        [AcceptVerbs("POST")]
        [Route("create-student")]
        public async Task<IActionResult> Create(Student model)
        {
            await _studentService.AddAsync(model);
            return Ok();
        }

        [HttpPut]
        [Route("update-student/{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Student model)
        {
            await _studentService.Update(id, model);
            return Ok();
        }

        [HttpDelete]
        [Route("delete-student/{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _studentService.Delete(id);
            return Ok();
        }
    }
}
