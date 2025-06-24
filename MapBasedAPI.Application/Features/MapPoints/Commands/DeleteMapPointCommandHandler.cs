using MediatR;
using Microsoft.EntityFrameworkCore;
using MapBasedAPI.Persistence.Contexts;

namespace MapBasedAPI.Application.Features.MapPoints.Commands
{
    public class DeleteMapPointCommandHandler : IRequestHandler<DeleteMapPointCommand, bool>
    {
        private readonly AppDbContext _context;

        public DeleteMapPointCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteMapPointCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.MapPoints.FirstOrDefaultAsync(mp => mp.Id == request.Id, cancellationToken);

            if (entity == null)
                return false;

            _context.MapPoints.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
