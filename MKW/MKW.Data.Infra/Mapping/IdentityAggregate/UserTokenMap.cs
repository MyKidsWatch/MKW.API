using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.IdentityAggregate;

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
                .HasKey(x => new { x.UserId, x.KeyCode });

            modelBuilder.Entity<UserToken>()
                .ToTable("TB_USR_USER_KEYCODE");

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
