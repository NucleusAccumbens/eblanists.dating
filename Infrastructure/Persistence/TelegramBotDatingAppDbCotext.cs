using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Interceptors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence;

public class TelegramBotDatingAppDbCotext : DbContext, IDatingAppDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    
    public TelegramBotDatingAppDbCotext(DbContextOptions<TelegramBotDatingAppDbCotext> options,
        IMediator mediator, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public DbSet<DatingAppUser> DatingAppUsers => Set<DatingAppUser>();

    public DbSet<TelegramUser> TelegramUsers => Set<TelegramUser>();

    public DbSet<Photo> Photos => Set<Photo>();

    public DbSet<PhotoAlbum> PhotoAlbums => Set<PhotoAlbum>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<TelegramUser>()
            .HasData(new TelegramUser()
            {
                Id = Guid.NewGuid(),
                ChatId = 444343256,
                Username = "noncredistka",
                IsAdmin = true
            }) ; 

        builder.Entity<PhotoAlbum>()
            .HasMany(a => a.Photos)
            .WithOne(p => p.PhotoAlbum)
            .HasForeignKey(p => p.PhotoAlbumId);

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }

}

