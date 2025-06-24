using MediatR;
using MapBasedAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
namespace MapBasedAPI.Application.Features.MapPoints.Commands

{
    public class UpdateMapPointCommandHandler : IRequestHandler<UpdateMapPointCommand, bool>
    {
        private readonly AppDbContext _context;

        public UpdateMapPointCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateMapPointCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.MapPoints.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                return false;

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.CreatedBy = request.CreatedBy;
            entity.Location = new Point(request.Longitude, request.Latitude) { SRID = 4326 };

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
