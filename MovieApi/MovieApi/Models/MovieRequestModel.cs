using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models;

public class MovieRequestModel
{
    [Required]
    public string MovieTitle { get; set; }

    [Required]
    public string MovieType { get; set; }

    [Required]
    public string MovieImageUrl { get; set; }
}