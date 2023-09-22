using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views;

public class LocationView : GeneralView
{
    public int GetByIdInput()
    {
        Console.WriteLine("Which ID");
        int id = Convert.ToInt32(Console.ReadLine());

        return id;
    }

    public Location InsertInput()
    {
        Console.WriteLine("Insert Location ID");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert street address");
        var streetAddress = Console.ReadLine();
        Console.WriteLine("Insert postal code");
        var postalCode = Console.ReadLine();
        Console.WriteLine("Insert city");
        var city = Console.ReadLine();
        Console.WriteLine("Insert state province");
        var stateProvince = Console.ReadLine();
        Console.WriteLine("Insert country id");
        var countryId = Console.ReadLine();

        return new Location
        {
            Id = id,
            StreetAddr = streetAddress,
            PostalCode = postalCode,
            City = city,
            StateProvince = stateProvince,
            CountryId = countryId
        };
    }

    public Location UpdateLocation()
    {
        Console.WriteLine("Which Location ID");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert street address");
        var streetAddress = Console.ReadLine();
        Console.WriteLine("Insert postal code");
        var postalCode = Console.ReadLine();
        Console.WriteLine("Insert city");
        var city = Console.ReadLine();
        Console.WriteLine("Insert state province");
        var stateProvince = Console.ReadLine();
        Console.WriteLine("Insert country id");
        var countryId = Console.ReadLine();

        return new Location
        {
            Id = id,
            StreetAddr = streetAddress,
            PostalCode = postalCode,
            City = city,
            StateProvince = stateProvince,
            CountryId = countryId
        };
    }

    public int DeleteInput()
    {
        Console.WriteLine("Which ID");
        int id = Convert.ToInt32(Console.ReadLine());

        return id;
    }
}