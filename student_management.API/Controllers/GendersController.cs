using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_management.Application.Services;
using student_management.Domain.Entities;
using student_management.Persistance.Services;

namespace student_management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IGenderService _genderService;

        public GendersController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _genderService.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            return Ok(await _genderService.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("create-student")]
        public async Task<IActionResult> Create(Gender model)
        {
            await _genderService.AddAsync(model);
            return Ok();
        }

        [HttpDelete]
        [Route("delete-student")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _genderService.Delete(id);
            return Ok();
        }

        [HttpPut]
        [Route("update-student")]
        public async Task<IActionResult> Update(Gender model)
        {
            await _genderService.Update(model);
            return Ok();
        }

    }
}
