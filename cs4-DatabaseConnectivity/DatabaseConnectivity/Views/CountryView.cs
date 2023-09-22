using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views;

public class CountryView : GeneralView
{
    public string GetByIdInput()
    {
        Console.WriteLine("Which ID");
        string id = Console.ReadLine();

        return id;
    }

    public Country InsertInput()
    {
        Console.WriteLine("Insert country ID (2 Characters in String)");
        var id = Console.ReadLine();
        Console.WriteLine("Insert country name");
        var name = Console.ReadLine();
        Console.WriteLine("Insert region ID");
        int regionId = Convert.ToInt32(Console.ReadLine());

        return new Country
        {
            Id = id,
            Name = name,
            RegionId = regionId,
        };
    }

    public Country UpdateCountry()
    {
        Console.WriteLine("Which country ID");
        var id = Console.ReadLine();
        Console.WriteLine("Insert country name");
        var name = Console.ReadLine();
        Console.WriteLine("Insert region ID");
        var regionId = Convert.ToInt32(Console.ReadLine());

        return new Country
        {
            Id = id,
            Name = name,
            RegionId = regionId,
        };
    }

    public string DeleteInput()
    {
        Console.WriteLine("Which ID");
        string id = Console.ReadLine();

        return id;
    }
}