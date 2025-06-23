using MediatR;
using NetTopologySuite.Geometries;

namespace MapBasedAPI.Application.Features.MapPoints.Commands.AddMapPoint
{
    public class AddMapPointCommand : IRequest<int>
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
