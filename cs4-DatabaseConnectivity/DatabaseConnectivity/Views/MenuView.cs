using DatabaseConnectivity.Controllers;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Views
{
    public class MenuView
    {
        public static void RegionMenu()
        {
            var region = new Region();
            var regionView = new RegionView();
            var regionController = new RegionController(region, regionView);

            var isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("\n1. List all regions");
                Console.WriteLine("2. Show region by Id");
                Console.WriteLine("3. Insert new region");
                Console.WriteLine("4. Update region");
                Console.WriteLine("5. Delete region");
                Console.WriteLine("0. Back");
                Console.Write("Enter your choice: ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        regionController.GetAll();
                        break;

                    case "2":
                        regionController.GetById();
                        break;

                    case "3":
                        regionController.Insert();
                        break;

                    case "4":
                        regionController.Update();
                        break;

                    case "5":
                        regionController.Delete();
                        break;

                    case "0":
                        isLoop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        public static void CountryMenu()
        {
            var country = new Country();
            var countryView = new CountryView();
            var countryController = new CountryController(country, countryView);

            var isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("\n1. List all countries");
                Console.WriteLine("2. Show country by Id");
                Console.WriteLine("3. Insert new country");
                Console.WriteLine("4. Update country");
                Console.WriteLine("5. Delete country");
                Console.WriteLine("0. Back");
                Console.Write("Enter your choice: ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        countryController.GetAll();
                        break;

                    case "2":
                        countryController.GetById();
                        break;

                    case "3":
                        countryController.Insert();
                        break;

                    case "4":
                        countryController.Update();
                        break;

                    case "5":
                        countryController.Delete();
                        break;

                    case "0":
                        isLoop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        public static void LocationMenu()
        {
            var location = new Location();
            var locationView = new LocationView();
            var locationController = new LocationController(location, locationView);

            var isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("\n1. List all Locations");
                Console.WriteLine("2. Show location by Id");
                Console.WriteLine("3. Insert new location");
                Console.WriteLine("4. Update location");
                Console.WriteLine("5. Delete location");
                Console.WriteLine("0. Back");
                Console.Write("Enter your choice: ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        locationController.GetAll();
                        break;

                    case "2":
                        locationController.GetById();
                        break;

                    case "3":
                        locationController.Insert();
                        break;

                    case "4":
                        locationController.Update();
                        break;

                    case "5":
                        locationController.Delete();
                        break;

                    case "0":
                        isLoop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
