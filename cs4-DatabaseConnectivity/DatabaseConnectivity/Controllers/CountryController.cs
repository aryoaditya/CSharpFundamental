using DatabaseConnectivity.Views;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Controllers;

public class CountryController
{
    private Country _country;
    private CountryView _countryView;

    public CountryController(Country Country, CountryView CountryInputView)
    {
        _country = Country;
        _countryView = CountryInputView;
    }

    public void GetAll()
    {
        var results = _country.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            _countryView.List(results, "Countrys");
        }
    }

    public void GetById()
    {
        string input = "";
        var isTrue = true;

        while (isTrue)
        {
            try
            {
                input = _countryView.GetByIdInput();
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

        var result = _country.GetById(input);

        if (result == null)
        {
            Console.WriteLine("No Country found");
        }
        else
        {
            _countryView.Single(result, "Country");
        }
    }

    public void Insert()
    {
        Country input = new Country();
        var isTrue = true;

        while (isTrue)
        {
            try
            {
                input = _countryView.InsertInput();
                if(string.IsNullOrEmpty(input.Name))
                {
                    Console.WriteLine("Country ID cannot be empty");
                    continue;
                }
                else if (string.IsNullOrEmpty(input.Name))
                {
                    Console.WriteLine("Country name cannot be empty");
                    continue;
                }
                else if (input.RegionId == null){
                    Console.WriteLine("Region id cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _country.Insert(new Country
        {
            Id = input.Id,
            Name = input.Name,
            RegionId = input.RegionId
        });

        _countryView.Transaction(result);
    }

    public void Update()
    {
        var Country = new Country();
        var isTrue = true;

        while (isTrue)
        {
            try
            {
                Country = _countryView.UpdateCountry();
                if (string.IsNullOrEmpty(Country.Name))
                {
                    Console.WriteLine("Country name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _country.Update(Country);

        _countryView.Transaction(result);
    }

    public void Delete()
    {
        string input = "";
        var isTrue = true;

        while (isTrue)
        {
            try
            {
                input = _countryView.DeleteInput();
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

        var result = _country.Delete(input);

        _countryView.Transaction(result);
    }
}