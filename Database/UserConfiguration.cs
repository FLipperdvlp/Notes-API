using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes_API.Entities;

namespace Notes_API.Database;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(t => t.Notes)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId);

        builder.HasData(
            new User
            {
                Id = 1,
                Name = "Test User",
                Email = "testuser@example.com",
                PasswordHash = "password123"
            }
        );
    }
}