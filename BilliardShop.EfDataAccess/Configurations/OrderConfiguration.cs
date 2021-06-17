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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.OrderDate)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasDefaultValue(OrderStatus.Recieved);

            builder.Property(x => x.Address)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(x => x.OrderLines)
                .WithOne(y => y.Order)
                .HasForeignKey(y => y.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
