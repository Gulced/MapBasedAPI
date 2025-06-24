using MediatR;

namespace MapBasedAPI.Application.Features.MapPoints.Commands

{
    public class UpdateMapPointCommand : IRequest<bool>
    {
        public int Id { get; set; } // Güncellenecek MapPoint ID'si
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
