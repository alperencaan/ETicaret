using Eticaret.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Data.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(50)").HasMaxLength(50);

            builder.Property(x => x.Surname)
               .IsRequired()
               .HasColumnType("nvarchar(50)").HasMaxLength(50);

            builder.Property(x => x.Email)
             .IsRequired()
             .HasColumnType("nvarchar(50)").HasMaxLength(50);


            builder.Property(x => x.Phone)
                .HasColumnType("nvarchar(50)").HasMaxLength(50);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnType("nvarchar(50)").HasMaxLength(50);


            builder.Property(x => x.UserName)

                .HasColumnType("nvarchar(50)").HasMaxLength(50);
            builder.HasData(
                new AppUser
                {
                    Id = 1,
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    IsActive = true,
                    IsAdmin = true,
                    Name = "Test",
                    Password ="123456",
                    Surname = "Test"
                }

                );



        }
    }
}
