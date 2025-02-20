using FS.EAuctions.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace FS.EAuctions.Data.Base;

public abstract class AuditableModelDbContextBase : DbContext
{
    public AuditableModelDbContextBase(DbContextOptions options) : base(options)
    {
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>()
            .Where(e => e.State == EntityState.Added);
        
        foreach (var entry in entries)
        {
            if (entry.Entity.CreatedAt == default) // Set only if not already set
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}