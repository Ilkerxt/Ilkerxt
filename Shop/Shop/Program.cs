using System;
using ClothingStore.BLL;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Clothing Store!");

            var manager = new ClothingManager();

            while (true)
            {
                Console.WriteLine("1. Add new item");
                Console.WriteLine("2. Remove item");
                Console.WriteLine("3. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter name:");
                        var name = Console.ReadLine();

                        Console.WriteLine("Enter category:");
                        var category = Console.ReadLine();

                        Console.WriteLine("Enter price:");
                        var price = decimal.Parse(Console.ReadLine());

                        manager.AddNewItem(name, category, price);
                        Console.WriteLine("Item added successfully!");
                        break;
                    case "2":
                        Console.WriteLine("Enter ID of item to remove:");
                        var id = int.Parse(Console.ReadLine());

                        manager.RemoveItem(id);
                        Console.WriteLine("Item removed successfully!");
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}
