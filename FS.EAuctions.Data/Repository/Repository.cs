using FS.EAuctions.Data.DBContexts;
using Fs.EAuctions.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FS.EAuctions.Data.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AuctionDbContext _auctionDbContext;

    public Repository(AuctionDbContext auctionDbContext)
    {
        _auctionDbContext = auctionDbContext ?? throw new ArgumentNullException(nameof(_auctionDbContext));
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _auctionDbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return (await _auctionDbContext.Set<T>().FindAsync(id))!;
    }

    public async Task<ActionResult> AddAsync(T entity)
    {
        await _auctionDbContext.Set<T>().AddAsync(entity);
        await _auctionDbContext.SaveChangesAsync();
        return new OkResult();
    }

    public async Task UpdateAsync(T entity)
    {
        _auctionDbContext.Entry(entity).State = EntityState.Modified;
        await _auctionDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _auctionDbContext.Set<T>().Remove(entity);
        await _auctionDbContext.SaveChangesAsync();
    }
}