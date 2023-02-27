using MovieApi.Extensions;
using MovieApi.Models;
using MovieApi.Models.Entities;
using MovieApi.Repositories;

namespace MovieApi.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    
    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    
    #region Get All Movies

    public ServiceResponse<List<Movie>> GetAll()
    { 
        var response = _movieRepository.GetAll().ToList();

        return new ServiceResponse<List<Movie>>()
        {
            Result = true,
            Message = response.Any() ? string.Empty : "No records found!",
            Response = response
        };
    }

    #endregion

    #region Get movie by movie id

    public ServiceResponse<Movie> GetMovieById(int id)
    { 
        var response = _movieRepository.GetById(id);

        return new ServiceResponse<Movie>()
        {
            Result = true,
            Message = response != null ? string.Empty : "No records found!",
            Response = response
        };
    }

    #endregion
    
    #region Add movie

    public ServiceResponse<Movie> AddMovie(MovieRequestModel requestModel)
    {
        var validation = ValidationMovieRequestModel(requestModel);
        if (!validation.Item1)
        {
            return new ServiceResponse<Movie>()
            {
                Result = false,
                Message = validation.Item2,
                Response = new Movie()
            };
        }

        var newMovie = new Movie()
        {
            MovieTitle = requestModel.MovieTitle,
            MovieType = requestModel.MovieType,
            MovieImageUrl = requestModel.MovieImageUrl,
            CreatedDate = DateTimeOffset.Now,
            Creator = 0
        };
        
        var response = _movieRepository.Add(newMovie);

        return new ServiceResponse<Movie>()
        {
            Result = true,
            Message = response == true ? "Movie added successfully!" : "Movie could not be added!",
            Response = null
        };
    }

    #endregion
    
    #region Update Movie

    public ServiceResponse<Movie> UpdateMovie(MovieRequestModel requestModel, int id)
    {
        var validation = ValidationMovieRequestModel(requestModel);
        if (!validation.Item1)
        {
            return new ServiceResponse<Movie>()
            {
                Result = false,
                Message = validation.Item2,
                Response = new Movie()
            };
        }

        var existingMovie = _movieRepository.GetById(id);
        if (existingMovie == null)
        {
            return new ServiceResponse<Movie>()
            {
                Result = true,
                Message = "There is not found any movie by given Id.",
                Response = null
            };
        }

        existingMovie.MovieTitle = requestModel.MovieTitle;
        existingMovie.MovieType = requestModel.MovieType;
        existingMovie.MovieImageUrl = requestModel.MovieImageUrl;
        existingMovie.Modifier = 0;
        existingMovie.ModifiedDate = DateTimeOffset.Now;
        
        var response = _movieRepository.Update(existingMovie);

        return new ServiceResponse<Movie>()
        {
            Result = true,
            Message = response == true ? "Movie updated successfully!" : "Movie could not be updated!",
            Response = null
        };
    }

    #endregion
    
    #region Delete Movie

    public ServiceResponse<Movie> DeleteMovie(int id)
    {
        var existingMovie = _movieRepository.GetById(id);
        if (existingMovie == null)
        {
            return new ServiceResponse<Movie>()
            {
                Result = true,
                Message = "There is not found any movie by given Id.",
                Response = null
            };
        }
        
        var response = _movieRepository.DeleteById(id);

        return new ServiceResponse<Movie>()
        {
            Result = true,
            Message = response == true ? "Movie deleted successfully!" : "Movie could not be deleted!",
            Response = null
        };
    }

    #endregion

    #region Common Methods

    private Tuple<bool, string> ValidationMovieRequestModel(MovieRequestModel? requestModel)
    {
        if (requestModel == null)
        {
            return Tuple.Create(false, "Request Model cannot be empty or null!");
        }

        if (string.IsNullOrWhiteSpace(requestModel.MovieTitle))
        {
            return Tuple.Create(false, "Movie title cannot be empty or null!");
        }

        if (requestModel.MovieTitle.HasInvalidCharacters())
        {
            return Tuple.Create(false, "Movie title cannot includes invalid characters!");
        }
        
        if (string.IsNullOrWhiteSpace(requestModel.MovieType))
        {
            return Tuple.Create(false, "Movie type cannot be empty or null!");
        }
        
        if (requestModel.MovieType.HasInvalidCharacters())
        {
            return Tuple.Create(false, "Movie type cannot includes invalid characters!");
        }
        
        if (string.IsNullOrWhiteSpace(requestModel.MovieImageUrl))
        {
            return Tuple.Create(false, "Movie image url cannot be empty or null!");
        }
        
        if (requestModel.MovieImageUrl.HasInvalidCharacters())
        {
            return Tuple.Create(false, "Movie Image url cannot includes invalid characters!");
        }
        
        return Tuple.Create(true, string.Empty);
    }

    #endregion
}
    