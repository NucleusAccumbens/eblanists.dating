using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DatingAppDbCotext : IDatingAppDbContext
{
    public DbSet<DatingAppUser> DatingAppUsers => throw new NotImplementedException();

    public DbSet<TelegramUser> TelegramUsers => throw new NotImplementedException();

    public DbSet<Photo> Photos => throw new NotImplementedException();

    public DbSet<PhotoAlbum> PhotoAlbums => throw new NotImplementedException();

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

