using MediatR;
using MapBasedAPI.Application.Features.MapPoints.Dtos;
using MapBasedAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MapBasedAPI.Application.Features.MapPoints.Queries.GetAllMapPoints
{
    public class GetAllMapPointsQueryHandler : IRequestHandler<GetAllMapPointsQuery, List<MapPointDto>>
    {
        private readonly AppDbContext _context;

        public GetAllMapPointsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MapPointDto>> Handle(GetAllMapPointsQuery request, CancellationToken cancellationToken)
        {
            return await _context.MapPoints
                .Select(mp => new MapPointDto
                {
                    Id = mp.Id,
                    Title = mp.Title,
                    Description = mp.Description,
                    Latitude = mp.Location.Y,
                    Longitude = mp.Location.X,
                    CreatedBy = mp.CreatedBy
                })
                .ToListAsync(cancellationToken);
        }
    }
}
