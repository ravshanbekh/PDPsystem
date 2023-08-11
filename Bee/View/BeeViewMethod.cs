using Service.DTOs.GoalDTOs;
using Service.DTOs.JournalEntryDTOs;
using Service.DTOs.TaskDTOs;
using Service.DTOs.UserDTOs;
using Service.Services;

namespace Bee.View;

public class BeeViewMethod
{
    TaskService taskService = new TaskService();
    GoalService goalService = new GoalService();
    JournalEntryService journalEntryService = new JournalEntryService();

    public UserCreationDto Registration()
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        Console.Write("PicturesPath: ");
        string profilPictures = Console.ReadLine();

        Console.Write("Bio: ");
        string bio = Console.ReadLine();

        return new UserCreationDto()
        {
            Username = username,
            Email = email,
            Password = password,
            ProfilePicture = profilPictures,
            Bio = bio
        };
    }

    public UserResultDto Login()
    {
        UserService userService = new UserService();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        var user = userService.GetAllAsync().Result.Data.FirstOrDefault(x => x.Email == email);

        if (user is null)
        {
            Console.Write("Email yoki parolingiz xato");
        }


        return user;
    }

    public TaskCreationDto TaskCreateConsole(long goalId)
    {
        Console.Write("TaskName: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Priority: ");
        string priority = Console.ReadLine();

        DateTime dueTime = DateTime.Now;

        Console.Write("Status: ");
        string status = Console.ReadLine();

        return new TaskCreationDto()
        {
            GoalId = goalId,
            TaskName = name,
            TaskDescription = description,
            Status = status,
            DueDate = dueTime,
            Priority = priority
        };
    }
    public TaskUpdateDto TaskUpdateConsole(long goalId)
    {
        Console.Write("TaskName: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Priority: ");
        string priority = Console.ReadLine();

        DateTime dueTime = DateTime.Now;

        Console.Write("Status: ");
        string status = Console.ReadLine();

        var task = taskService.GetAllAsync().Result.Data.FirstOrDefault(x => x.TaskName == name);
        if (task == null)
        {
            return null;
        }

        return new TaskUpdateDto()
        {
            Id = task.Id,
            GoalId = goalId,
            TaskName = name,
            TaskDescription = description,
            Status = status,
            DueDate = dueTime,
            Priority = priority
        };
    }
    public GoalCreationDto GoalCreateConsole(long userId)
    {
        Console.Write("Goal title: ");
        string title = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Status: ");
        string status = Console.ReadLine();

        DateTime starDate = DateTime.Now;
        DateTime dueDate = DateTime.Now;


        return new GoalCreationDto()
        {
            UserId = userId,
            GoalTitle = title,
            GoalDescription = description,
            DueDate = dueDate,
            StartDate = starDate,
            Status = status
        };
    }
    public GoalUpdateDto GoalUpdateConsole(long userId)
    {
        Console.Write("Goal title: ");
        string title = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Status: ");
        string status = Console.ReadLine();

        DateTime starDate = DateTime.Now;
        DateTime dueDate = DateTime.Now;

        var goal = goalService.GetAllAsync().Result.Data.FirstOrDefault(x => x.GoalTitle == title);
        if (goal == null)
        {
            return null;
        }

        return new GoalUpdateDto()
        {
            Id = goal.Id,
            UserId = userId,
            GoalTitle = title,
            GoalDescription = description,
            DueDate = dueDate,
            StartDate = starDate,
            Status = status
        };
    }


    public JournalEntryCreationDto JournalEntryCreateConsole(long userId)
    {
        Console.Write("Entry text: ");
        string entryText = Console.ReadLine();

        DateTime entryDate = DateTime.Now;

        return new JournalEntryCreationDto()
        {
            UserId = userId,
            EntryDate = entryDate,
            EntryText = entryText
        };
    }
    public JournalEntryUpdateDto JournalEntryUpdateConsole(long userId)
    {
        Console.Write("Entry text: ");
        string entryText = Console.ReadLine();

        DateTime entryDate = DateTime.Now;

        var journalEntry = journalEntryService.GetAllAsync().Result.Data.FirstOrDefault(x => x.EntryText == entryText);
        if (journalEntry == null)
        {
            return null;
        }

        return new JournalEntryUpdateDto()
        {
            Id = journalEntry.Id,
            UserId = userId,
            EntryDate = entryDate,
            EntryText = entryText
        };
    }
}
