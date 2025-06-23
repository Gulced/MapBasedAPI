using MediatR;
using MapBasedAPI.Domain.Entities;
using MapBasedAPI.Persistence.Contexts;
using NetTopologySuite.Geometries;

namespace MapBasedAPI.Application.Features.MapPoints.Commands.AddMapPoint
{
    public class AddMapPointCommandHandler : IRequestHandler<AddMapPointCommand, int>
    {
        private readonly AppDbContext _context;

        public AddMapPointCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddMapPointCommand request, CancellationToken cancellationToken)
        {
            var point = new MapPoint
            {
                Title = request.Title,
                Description = request.Description,
                CreatedBy = request.CreatedBy,
                Location = new Point(request.Longitude, request.Latitude) { SRID = 4326 }
            };

            _context.MapPoints.Add(point);
            await _context.SaveChangesAsync(cancellationToken);

            return point.Id;
        }
    }
}
