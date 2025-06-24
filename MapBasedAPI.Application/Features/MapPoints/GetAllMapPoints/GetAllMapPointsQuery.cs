using MediatR;

using MapBasedAPI.Application.Features.MapPoints.Dtos;

namespace MapBasedAPI.Application.Features.MapPoints.Queries
{
    public class GetAllMapPointsQuery : IRequest<List<MapPointDto>>
    {
    }
}
