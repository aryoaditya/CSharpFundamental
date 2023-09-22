using DatabaseConnectivity.Views;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Controllers;

public class RegionController
{
    private Region _region;
    private RegionView _regionView;

    public RegionController(Region region, RegionView regionInputView)
    {
        _region = region;
        _regionView = regionInputView;
    }

    public void GetAll()
    {
        var results = _region.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            _regionView.List(results, "regions");
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
                input = _regionView.GetByIdInput();
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

        var result = _region.GetById(input);

        if(result == null)
        {
            Console.WriteLine("No region found");
        }
        else
        {
            _regionView.Single(result, "Region");
        }
    }

    public void Insert()
    {
        string input = "";
        var isTrue = true;

        while (isTrue)
        {
            try
            {
                input = _regionView.InsertInput();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Region name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _region.Insert(new Region
        {
            Id = 0,
            Name = input
        });

        _regionView.Transaction(result);
    }

    public void Update()
    {
        var region = new Region();
        var isTrue = true;

        while (isTrue)
        {
            try
            {
                region = _regionView.UpdateRegion();
                if (string.IsNullOrEmpty(region.Name))
                {
                    Console.WriteLine("Region name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _region.Update(region);

        _regionView.Transaction(result);
    }

    public void Delete()
    {
        int input = 0;
        var isTrue = true;

        while (isTrue)
        {
            try
            {
                input = _regionView.DeleteInput();
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

        var result = _region.Delete(input);

        _regionView.Transaction(result);
    }
}