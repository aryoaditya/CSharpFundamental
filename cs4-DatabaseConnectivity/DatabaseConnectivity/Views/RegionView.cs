using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views;

public class RegionView : GeneralView
{
    public int GetByIdInput()
    {
        Console.WriteLine("Which ID");
        int id = Convert.ToInt32(Console.ReadLine());

        return id;
    }

    public string InsertInput()
    {
        Console.WriteLine("Insert region name");
        var name = Console.ReadLine();

        return name;
    }

    public Region UpdateRegion()
    {
        Console.WriteLine("Which region id");
        var id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert region name");
        var name = Console.ReadLine();

        return new Region
        {
            Id = id,
            Name = name
        };
    }

    public int DeleteInput()
    {
        Console.WriteLine("Which ID");
        int id = int.Parse(Console.ReadLine());

        return id;
    }
}