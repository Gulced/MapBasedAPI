using MediatR;
using Microsoft.AspNetCore.Mvc;
using MapBasedAPI.Application.Features.MapPoints.Commands; // Add, Update, Delete hepsi buradan gelir
using MapBasedAPI.Application.Features.MapPoints.Queries;  // GetAllQuery buradan

namespace MapBasedAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapPointsController : ControllerBase
    {
        private readonly IMediator _myMediator;

        public MapPointsController(IMediator myMediator)
        {
            _myMediator = myMediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddMapPointCommand command)
        {
            var id = await _myMediator.Send(command);
            return Ok(new { id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _myMediator.Send(new GetAllMapPointsQuery());
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMapPointCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id in route and body do not match");

            await _myMediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _myMediator.Send(new DeleteMapPointCommand { Id = id });

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
