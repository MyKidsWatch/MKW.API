using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ContentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Data.Context.Mapping.ContentAggregate
{
    public class ContentGenreMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentGenre>()
                .ToTable("TB_MKW_CONTENT_GENRE");

            modelBuilder.Entity<ContentGenre>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ContentGenre>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<ContentGenre>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<ContentGenre>()
                .Property(x => x.ContentId)
                .HasColumnName("CONTENT_ID");

            modelBuilder.Entity<ContentGenre>()
                .Property(x => x.GenreId)
                .HasColumnName("GENRE_ID");

            modelBuilder.Entity<ContentGenre>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<ContentGenre>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<ContentGenre>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<ContentGenre>()
                .HasOne(x => x.Genre)
                .WithMany(x => x.ContentGenre)
                .HasForeignKey(x => x.GenreId);

            modelBuilder.Entity<ContentGenre>()
                .HasOne(x => x.Content)
                .WithMany(x => x.ContentGenre)
                .HasForeignKey(x => x.ContentId);
        }
    }
}
