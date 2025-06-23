using MediatR;
using Microsoft.AspNetCore.Mvc;
using MapBasedAPI.Application.Features.MapPoints.Commands.AddMapPoint;
using MapBasedAPI.Application.Features.MapPoints.Queries.GetAllMapPoints;

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
    }
}
