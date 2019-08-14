using System.Data.Entity;
using VidzyCodeFirst.EntityConfigurations;

namespace VidzyCodeFirst
{
    public class VidzyContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VideoConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.Videos)
                .WithMany(v => v.Tags)
                .Map(m => 
                {
                    m.ToTable("VideoTags");
                    m.MapLeftKey("TagId");
                    m.MapRightKey("VideoId");
                });
        }
    }
}
