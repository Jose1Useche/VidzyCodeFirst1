using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyCodeFirst.EntityConfigurations
{
    class VideoConfiguration : EntityTypeConfiguration<Video>
    {
        public VideoConfiguration()
        {
            Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(255);

            Property(v => v.GenreId)
            .IsRequired();

            HasRequired(v => v.Genre)
            .WithMany(g => g.Video)
            .HasForeignKey(v => v.GenreId);
        }
    }
}
