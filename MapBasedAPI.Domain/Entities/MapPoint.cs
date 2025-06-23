using NetTopologySuite.Geometries;

namespace MapBasedAPI.Domain.Entities
{
    public class MapPoint
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Point Location { get; set; } = null!;
        public string CreatedBy { get; set; } = string.Empty;
    }
}
