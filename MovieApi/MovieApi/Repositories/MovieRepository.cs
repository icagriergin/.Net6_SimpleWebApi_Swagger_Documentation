using Microsoft.EntityFrameworkCore;
using MovieApi.Contexts;
using MovieApi.Models.Entities;

namespace MovieApi.Repositories;

public class MovieRepository : Repository<Movie>, IMovieRepository
{
    private readonly MovieDbContext _context;
    
    public MovieRepository(MovieDbContext context) : base(context)
    {
        _context = context;
    }
}