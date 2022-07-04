using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IDatingAppDbContext
    {
        DbSet<DatingAppUser> DatingAppUsers { get; } 

        DbSet<TelegramUser> TelegramUsers { get; }

        DbSet<Photo> Photos { get; }

        DbSet<PhotoAlbum> PhotoAlbums { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
