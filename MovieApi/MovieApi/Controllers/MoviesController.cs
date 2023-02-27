using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using MovieApi.Models.Entities;
using MovieApi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace MovieApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;
    
    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    /// <summary>
    /// Get All Movies
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///    GET/
    /// 
    ///    Request body doesn't necessary.
    ///
    /// </remarks>
    [HttpGet]
    [Produces("application/json")]
    [SwaggerOperation(
        Tags = new[] { "Movies"}
    )]
    public ServiceResponse<List<Movie>> Get()
    {
        return _movieService.GetAll();
    }
    
    /// <summary>
    /// Get Movie By Id
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///<string ><![CDATA[<b>Request parameters cannot includes invalid characters!</b>]]></string>
    /// 
    ///     GET /Movie
    ///     {
    ///        "id": 1
    ///     }
    ///
    ///  Sample response:
    /// 
    ///     /Movie
    ///     {
    ///         "result": true,
    ///          "message": "",
    ///          "response":
    ///          {
    ///             "movieTitle": "Baba",
    ///             "movieType": "Suç/Dram",
    ///             "movieImageUrl": "src/images/Baba_img.jpg",
    ///             "moviePublishedDate": "2023-02-25T23:24:46.611826",
    ///             "id": 2
    ///          }
    ///     }
    /// </remarks>
    [HttpGet("{id}")]
    [Produces("application/json")]
    public ServiceResponse<Movie> GetById(int id)
    {
        return _movieService.GetMovieById(id);
    }
    
    /// <summary>
    /// Update an existing movie.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///<string><![CDATA[<b>Request parameters cannot includes invalid characters!</b>]]></string>
    /// 
    ///     PUT /Movie
    ///     {
    ///         "movieTitle": "Deneme filmi",
    ///         "movieType": "Dram/Romantik",
    ///         "movieImageUrl": "deneme.jpg"
    ///     }
    ///
    ///  Sample response:
    /// 
    ///     /Movie
    ///     {
    ///         "result": true,
    ///         "message": "Movie updated successfully!",
    ///         "response": null
    ///     }
    /// </remarks>
    [HttpPut("{id}")]
    [Produces("application/json")]
    public ServiceResponse<Movie> Put(MovieRequestModel requestModel,int id)
    {
        return _movieService.UpdateMovie(requestModel, id);
    }
    
    /// <summary>
    /// Add a new movie.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///<string ><![CDATA[<b>Request parameters cannot includes invalid characters!</b>]]></string>
    /// 
    ///     POST /Movie
    ///     {
    ///         "movieTitle": "Deneme filmi",
    ///         "movieType": "Dram/Romantik",
    ///         "movieImageUrl": "deneme.jpg"
    ///     }
    ///
    ///  Sample response:
    /// 
    ///     /Movie
    ///     {
    ///         "result": true,
    ///         "message": "Movie added succesfully!",
    ///         "response": null
    ///     }
    /// </remarks>
    [HttpPost]
    [Produces("application/json")]
    public ServiceResponse<Movie> Post(MovieRequestModel requestModel)
    {
        return _movieService.AddMovie(requestModel);
    }
    
    /// <summary>
    /// Delete a movie by Id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///<string name="ss"><![CDATA[<b>Request parameters cannot includes invalid characters!</b>]]></string>
    /// 
    ///     DELETE /Movie
    ///     {
    ///         "id":9
    ///     }
    ///
    ///  Sample response:
    /// 
    ///     /Movie
    ///     {
    ///         "result": true,
    ///         "message": "Movie deleted successfully!",
    ///         "response": null
    ///     }
    /// </remarks>
    [HttpDelete("{id}")]
    [Produces("application/json")]
    public ServiceResponse<Movie> Delete(int id)
    {
        return _movieService.DeleteMovie(id);
    }
}