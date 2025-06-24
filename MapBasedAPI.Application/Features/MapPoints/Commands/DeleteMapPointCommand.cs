using MediatR;
using MapBasedAPI.Application.Features.MapPoints.Commands;


namespace MapBasedAPI.Application.Features.MapPoints.Commands // ← BU NOKTAYI DÜZELT!
{
    public class DeleteMapPointCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
