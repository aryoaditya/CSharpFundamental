using DatabaseConnectivity.Views;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Controllers;

public class LocationController
{
    private Location _location;
    private LocationView _locationView;

    public LocationController(Location location, LocationView locationInputView)
    {
        _location = location;
        _locationView = locationInputView;
    }

    public void GetAll()
    {
        var results = _location.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            _locationView.List(results, "locations");
        }
    }

    public void GetById()
    {
        int input = 0;
        var isTrue = true;

        while (isTrue)
        {
            try
            {
                input = _locationView.GetByIdInput();
                if (input == null)
                {
                    Console.WriteLine("Please insert ID");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _location.GetById(input);

        if (result == null)
        {
            Console.WriteLine("No location found");
        }
        else
        {
            _locationView.Single(result, "location");
        }
    }

    public void Insert()
    {
        Location input = new Location();
        var isTrue = true;

        while (isTrue)
        {
            try
            {
                input = _locationView.InsertInput();
                if (input.Id == null)
                {
                    Console.WriteLine("City cannot be empty");
                    continue;
                }
                else if (string.IsNullOrEmpty(input.City))
                {
                    Console.WriteLine("City cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _location.Insert(new Location
        {
            Id = input.Id,
            StreetAddr = input.StreetAddr,
            PostalCode = input.PostalCode,
            City = input.City,
            StateProvince = input.StateProvince,
            CountryId = input.CountryId
        });

        _locationView.Transaction(result);
    }

    public void Update()
    {
        var location = new Location();
        var isTrue = true;

        while (isTrue)
        {
            try
            {
                location = _locationView.UpdateLocation();
                if (location.Id == null)
                {
                    Console.WriteLine("City cannot be empty");
                    continue;
                }
                else if (string.IsNullOrEmpty(location.City))
                {
                    Console.WriteLine("City cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _location.Update(location);

        _locationView.Transaction(result);
    }

    public void Delete()
    {
        int input = 0;
        var isTrue = true;

        while (isTrue)
        {
            try
            {
                input = _locationView.DeleteInput();
                if (input == null)
                {
                    Console.WriteLine("Please insert ID");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _location.Delete(input);

        _locationView.Transaction(result);
    }
}