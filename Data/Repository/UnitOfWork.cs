using Data.Contexts;
using Data.IRepository;
using Domain.Entities;

namespace Data.Repository;

public class UnitOfWork:IUnitOfWork
{
    private readonly AppDbContext dbContext;
    public UnitOfWork()
    {
        this.dbContext = new AppDbContext();
        GoalRepository = new Repository<Goal>(dbContext);
        UserRepository = new Repository<User>(dbContext);
        TaskRepository = new Repository<TaskUser>(dbContext);
    }

    public IRepository<Goal> GoalRepository { get; }
    public IRepository<User> UserRepository { get; }
    public IRepository<TaskUser> TaskRepository { get; }
    public IRepository<JournalEntry> JournalEntryRepository { get; }


    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public async Task SaveAsync()
    {
        await this.dbContext.SaveChangesAsync();
    }
}
