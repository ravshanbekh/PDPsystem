using Domain.Entities;

namespace Data.IRepository;

public interface IUnitOfWork : IDisposable
{
    IRepository<Goal> GoalRepository { get; }
    IRepository<User> UserRepository { get; }
    IRepository<JournalEntry> JournalEntryRepository { get; }
    IRepository<TaskUser> TaskRepository { get; }

    Task SaveAsync();
}
