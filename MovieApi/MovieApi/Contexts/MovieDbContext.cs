using Microsoft.EntityFrameworkCore;
using MovieApi.Models.Entities;

namespace MovieApi.Contexts;

public class MovieDbContext : DbContext
{
    #region Movie List Generator

    private readonly List<Movie> _movieList = new List<Movie>()
    {
        new Movie
        {
            Id = 1,
            MovieTitle = "Esaretin Bedeli",
            MovieImageUrl = "src/images/Esaretin_bedeli_img.jpg",
            MovieType = "Dram/Aksiyon",
            Creator = 0,
            CreatedDate = DateTimeOffset.Now
        },
        new Movie
        {
            Id = 2,
            MovieTitle = "Baba",
            MovieImageUrl = "src/images/Baba_img.jpg",
            MovieType = "Suç/Dram",
            Creator = 0,
            CreatedDate = DateTimeOffset.Now
        },
        new Movie
        {
            Id = 3,
            MovieTitle = "Dövüş Klübü",
            MovieImageUrl = "src/images/Dövüs_klübü_img.jpg",
            MovieType = "Dram",
            Creator = 0,
            CreatedDate = DateTimeOffset.Now
        },
        new Movie
        {
            Id = 4,
            MovieTitle = "Yeşil Yol",
            MovieImageUrl = "src/images/Yesil_yol_img.jpg",
            MovieType = "Dram",
            Creator = 0,
            CreatedDate = DateTimeOffset.Now
        },
        new Movie
        {
            Id = 5,
            MovieTitle = "Batman Kara Şövalye",
            MovieImageUrl = "src/images/Batman_kara_sovalye_img.jpg",
            MovieType = "Aksiyon/Macera",
            Creator = 0,
            CreatedDate = DateTimeOffset.Now
        }
    };

    #endregion

    public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options){}

    public DbSet<Movie> Movies { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MoviesDb;User Id=sa;Password=password;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(e =>
        {
            e.HasKey(m => m.Id)
                .HasName("PK_Movies");

            e.Property(m => m.Id)
                .UseIdentityColumn();
            
            e.Property(s => s.MovieTitle)
                .IsRequired(true)
                .HasMaxLength(100);
            
            e.Property(s => s.MovieImageUrl)
                .IsRequired(true)
                .HasMaxLength(100);
            
            e.Property(s => s.MovieType)
                .IsRequired(true).HasMaxLength(50);
            
            e.Property(s => s.Creator)
                .IsRequired(true);
            
            e.Property(s => s.CreatedDate)
                .IsRequired(true);
        });
        
        modelBuilder.Entity<Movie>().HasData(_movieList);
    }
}