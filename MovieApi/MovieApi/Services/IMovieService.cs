using MovieApi.Models;
using MovieApi.Models.Entities;

namespace MovieApi.Services;

public interface IMovieService
{
    ServiceResponse<List<Movie>> GetAll();

    ServiceResponse<Movie> GetMovieById(int id);

    ServiceResponse<Movie> AddMovie(MovieRequestModel requestModel);
    
    ServiceResponse<Movie> UpdateMovie(MovieRequestModel requestModel, int id);

    ServiceResponse<Movie> DeleteMovie(int id);
}