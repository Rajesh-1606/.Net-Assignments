using System;
using System.Collections.Generic;

class Assignment
{
    static List<(string title, string description)> tasks = new List<(string, string)>();

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Task List Application");
            Console.WriteLine("1. Create a task");
            Console.WriteLine("2. Read tasks");
            Console.WriteLine("3. Update a task");
            Console.WriteLine("4. Delete a task");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please Choose the correct option");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateTask();
                    break;
                case 2:
                    ReadTasks();
                    break;
                case 3:
                    UpdateTask();
                    break;
                case 4:
                    DeleteTask();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateTask()
    {
        Console.Write("Enter the title of the task: ");
        string title = Console.ReadLine();

        Console.Write("Enter the description of the task: ");
        string description = Console.ReadLine();

        tasks.Add((title, description));
        Console.WriteLine("Task added successfully.");
    }

    static void ReadTasks()
    {
        Console.WriteLine("Tasks:");
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            foreach (var task in tasks)
            {
                Console.WriteLine("- Title: " + task.title);
                Console.WriteLine("  Description: " + task.description);
            }
        }
    }

    static void UpdateTask()
    {
        Console.Write("Enter the title of the task to update: ");
        string title = Console.ReadLine();

        int index = -1;
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].title == title)
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            Console.Write("Enter the new description of the task: ");
            string newDescription = Console.ReadLine();

            tasks[index] = (title, newDescription);
            Console.WriteLine("Task updated successfully.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }


    static void DeleteTask()
    {
        Console.Write("Enter the title of the task to delete: ");
        string title = Console.ReadLine();

        int index = tasks.FindIndex(t => t.title == title);
        if (index != -1)
        {
            tasks.RemoveAt(index);
            Console.WriteLine("Task deleted successfully.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }
}
