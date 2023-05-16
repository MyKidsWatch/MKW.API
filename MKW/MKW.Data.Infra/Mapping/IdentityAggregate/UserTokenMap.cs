using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Data.Context.Mapping.IdentityAggregate
{
    /// <summary>
    /// Mapeia a entidade UserToken em relação à tabela da Base de Dados
    /// </summary>
    public class UserTokenMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserToken>()
                .HasKey(x => new {x.UserId, x.KeyCode});
            
            modelBuilder.Entity<UserToken>()
                .ToTable("TB_MKW_USER_TOKEN");

            modelBuilder.Entity<UserToken>()
                .Property(x => x.UserId)
                .HasColumnName("USER_ID")
                .IsRequired();

            modelBuilder.Entity<UserToken>()
                .Property(x => x.KeyCode)
                .HasColumnName("KEY_CODE")
                .IsRequired();          

            modelBuilder.Entity<UserToken>()
                .Property(x => x.Token)
                .HasColumnName("TOKEN")
                .IsRequired(); 
        }
    }
}
