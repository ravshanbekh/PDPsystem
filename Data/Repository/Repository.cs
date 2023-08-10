using Data.Contexts;
using Data.IRepository;
using Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly AppDbContext dbContext;
    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task CreateAsync(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        await this.dbContext.Set<T>().AddAsync(entity);
    }

    public void Update(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        this.dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        this.dbContext.Set<T>().Remove(entity);
    }

    public async Task<T> SelectByIdAsync(long id)
        => await this.dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

    public IQueryable<T> SelectAll()
        => this.dbContext.Set<T>().AsNoTracking().AsQueryable();
}
