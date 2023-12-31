﻿namespace DatabaseConnectivity.Views;

public class GeneralView
{
    public void List<T>(List<T> items, string title)
    {
        Console.WriteLine($"\nList of {title}");
        Console.WriteLine("---------------");
        //Console.WriteLine("Id | Full Name | Email | Phone Number | Salary | Department | Address | Country | Region");
        foreach (var item in items)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine();
    }

    public void Single<T>(T item, string title)
    {
        Console.WriteLine($"List of {title}");
        Console.WriteLine("---------------");
        Console.WriteLine(item.ToString());
    }

    public void Transaction(string result)
    {
        int.TryParse(result, out int res);
        if (res > 0)
        {
            Console.WriteLine("Transaction completed successfully");
        }
        else
        {
            Console.WriteLine("Transaction failed");
            Console.WriteLine(result);
        }
    }
}