using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.Models.Entities;

public abstract class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order = 0)]
    public int Id { get; set; }
    
    public DateTimeOffset CreatedDate { get; set; }
    
    public int Creator { get; set; }
    
    public DateTimeOffset ModifiedDate { get; set; }
    
    public int Modifier { get; set; }
}