using Service.DTOs.UserDTOs;
using Service.Services;

namespace Bee.View;

public class View
{
    public void Menu()
    {
        BeeViewMethod beeViewMethod = new BeeViewMethod();
        UserService userService = new UserService();
        TaskService taskService = new TaskService();
        GoalService goalService = new GoalService();
        JournalEntryService journalEntryService = new JournalEntryService();

        Console.WriteLine("Welcome Personla Development Planner");
        Console.WriteLine("Please choose one");
        UserCreationDto userCreationDto = new UserCreationDto();
        UserResultDto userResultDto = new UserResultDto();

        while (true)
        {
            string choose;
            Console.WriteLine("1)Sign in \n2)Sign up\n");
            Console.WriteLine(">>");
            choose = Console.ReadLine().ToString();

            if (choose == "1")
            {
                userResultDto = beeViewMethod.Login();
            }
            else if (choose == "2")
            {
                userCreationDto = beeViewMethod.Registration();
                userResultDto = userService.AddAsync(userCreationDto).Result.Data;
            }
            else
            {
                Console.WriteLine("Error");
            }

            if (userResultDto is not null)
            {
                Console.WriteLine("You have successfully entered");
                break;
            }
        }

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine(@"1)Create Task
                                2)Update Task
                                3)See all Tasks
                                4)Delete Task
                                5)Create Goal
                                6)Update Goal
                                7)See all Goals
                                8)Delete Goal
                                9)Create JournalEntry
                                10)Update JournalEntry
                                11)See all JournalEntry
                                12)Delete JournalEntry");
            Console.Write(">>");
            string choose = Console.ReadLine();
            if (choose == "1")
            {
                var task=beeViewMethod.TaskCreateConsole(userResultDto.Id);
                var temp=taskService.AddAsync(task);
                
                if (temp is not null)
                    Console.WriteLine("Succes");
            }
            else if (choose == "2")
            {
                var task=beeViewMethod.TaskUpdateConsole(userResultDto.Id);
                var temp=taskService.ModifyAsync(task);
                if (temp is not null)
                    Console.WriteLine("Succes");
            }
            else if (choose == "3")
            {
                var tasks=taskService.GetAllAsync().Result.Data;
                foreach (var task in tasks)
                {
                    if(task.Id == userResultDto.Id)
                    {
                        Console.WriteLine($"|id-{task.Id}|name-{task.TaskName}|description-{task.TaskDescription}|priority-{task.Priority}|status-{task.Status}");
                    }
                }
            }
            else if (choose == "4")
            {

            }
            else if (choose == "5")
            {

            }
            else if (choose == "6")
            {

            }
            else if (choose == "7")
            {

            }
            else if (choose == "8")
            {

            }
            else if (choose == "9")
            {

            }
            else if (choose == "10")
            {

            }
            else if (choose == "11")
            {

            }
            else if (choose == "12")
            {

            }
        }
    }
}
