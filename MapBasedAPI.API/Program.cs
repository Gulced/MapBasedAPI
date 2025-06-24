using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MediatR;
using MapBasedAPI.Application.Features.MapPoints.Commands.AddMapPoint;
using MapBasedAPI.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Controller ve Swagger servislerini ekle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS ayarı (özellikle farklı originlerde test yapıyorsan)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// DbContext'i PostgreSQL ve NetTopologySuite ile kaydet
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        o => o.UseNetTopologySuite()
    ));

// MediatR servislerini tanıt
builder.Services.AddMediatR(typeof(AddMapPointCommandHandler).Assembly);

var app = builder.Build();

// CORS'u etkinleştir
app.UseCors();

// Swagger'ı her ortamda aktif et (development veya production farketmez)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MapBasedAPI v1");
    c.RoutePrefix = string.Empty; // Swagger UI root dizinde açılır
});

// HTTPS yönlendirmeyi kapat (İstersen açabilirsin, ama sorun varsa kapat)
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
