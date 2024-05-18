using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        Inventory inventory = new Inventory();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nInventory Management System");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Display All Items");
            Console.WriteLine("3. Find Item by ID");
            Console.WriteLine("4. Delete Item by ID");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddNewItem(inventory);
                        break;
                    case 2:
                        inventory.DisplayAllItems();
                        break;
                    case 3:
                        FindAndDisplayItemById(inventory);
                        break;
                    case 4:
                        DeleteItemById(inventory);
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void AddNewItem(Inventory inventory)
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Price: ");
        double price = double.Parse(Console.ReadLine());

        Console.Write("Enter Quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        Item newItem = new Item(id, name, price, quantity);
        inventory.AddItem(newItem);
    }

    static void FindAndDisplayItemById(Inventory inventory)
    {
        Console.Write("Enter Item ID: ");
        int id = int.Parse(Console.ReadLine());

        inventory.DisplayItemById(id);
    }

    static void DeleteItemById(Inventory inventory)
    {
        Console.Write("Enter Item ID: ");
        int id = int.Parse(Console.ReadLine());

        inventory.DeleteItemById(id);
    }
}

public class Item
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Item(int id, string name, double price, int quantity)
    {
        ID = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Price: {Price}, Quantity: {Quantity}";
    }
}

public class Inventory
{
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        Console.WriteLine("Item added successfully.");
    }

    public void DisplayAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public Item FindItemById(int id)
    {
        return items.Find(item => item.ID == id);
    }

    public void DisplayItemById(int id)
    {
        var item = FindItemById(id);
        if (item != null)
        {
            Console.WriteLine(item);
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }

    public bool DeleteItemById(int id)
    {
        var item = FindItemById(id);
        if (item != null)
        {
            items.Remove(item);
            Console.WriteLine("Item deleted successfully.");
            return true;
        }
        else
        {
            Console.WriteLine("Item not found.");
            return false;
        }
    }
}
