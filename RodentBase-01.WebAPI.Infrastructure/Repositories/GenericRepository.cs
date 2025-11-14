using Microsoft.EntityFrameworkCore;
using RodentBase_01.WebAPI.Application.Contracts.Infrastructure.Reporitories;
using RodentBase_01.WebAPI.Infrastructure.Persistance;

namespace RodentBase_01.WebAPI.Infrastructure.Repositories;

internal class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _context.Set<T>().FindAsync(id);

        if (entity == null)
            return false;

        _context.Set<T>().Remove(entity);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        var entity = await _context.Set<T>().FindAsync(id);

        if (entity == null)
            return null;

        return entity;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        _context.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;

        return await _context.SaveChangesAsync() > 0;
    }
}
