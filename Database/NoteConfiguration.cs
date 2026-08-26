using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes_API.Entities;

namespace Notes_API.Database;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(t => t.User)
            .WithMany(t => t.Notes)
            .HasForeignKey(t => t.UserId);

        builder.HasData(
            new Note
            {
                Id = 1,
                Title = "First Note",
                Content = "This is the content of the first note.",
                UserId = 1
            },
            new Note
            {
                Id = 2,
                Title = "Second Note",
                Content = "This is the content of the second note.",
                UserId = 1
            }
        );
    }
}