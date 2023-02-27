using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.Models.Entities;

public class Movie : BaseEntity
{
    public string MovieTitle { get; set; }

    public string MovieType { get; set; }

    public string MovieImageUrl { get; set; }
}

