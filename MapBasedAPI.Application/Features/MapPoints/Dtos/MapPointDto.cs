namespace MapBasedAPI.Application.Features.MapPoints.Dtos
{
    public class MapPointDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CreatedBy { get; set; }
    }
}
