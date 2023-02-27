using Microsoft.EntityFrameworkCore;
using MovieApi.Contexts;
using MovieApi.Extensions;
using MovieApi.Repositories;
using MovieApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddDbContext<MovieDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesDatabase")));

#region Services

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

#endregion


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCustomSwaggerConfig();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();