using BilliardShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.EfDataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Password)
                .HasMaxLength(64)
                .IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasMany(x => x.Orders)
                .WithOne(y => y.User)
                .HasForeignKey(y => y.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.UserUseCases)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
