using DatabaseConnectivity.Views;
using DatabaseConnectivity.Controllers;
using DatabaseConnectivity.Models;

namespace DatabaseConnectivity;

public class Program
{
    private static void Main()
    {
        var choice = true;
        while (choice)
        {
            Console.WriteLine("1. Region CRUD");
            Console.WriteLine("2. Country CRUD");
            Console.WriteLine("3. Location CRUD");
            Console.WriteLine("4. List regions with Where");
            Console.WriteLine("5. Join tables regions and countries and locations");
            Console.WriteLine("6. Join tables Employee and Department and Location and Country and Region");
            Console.WriteLine("7. Join tables Department and Employee and Show Summary");
            Console.WriteLine("10. Exit");
            Console.Write("Enter your choice: ");
            var input = Console.ReadLine();
            choice = Menu(input);
        }
    }

    public static bool Menu(string input)
    {
        switch (input)
        {
            case "1":
                MenuView.RegionMenu();
                break;

            case "2":
                MenuView.CountryMenu();
                break;
            case "3":
                MenuView.LocationMenu();
                break;
            case "4":
                var region2 = new Region();
                string input2 = Console.ReadLine();
                var result = region2.GetAll().Where(r => r.Name.Contains(input2)).ToList();
                break;
            case "5":
                var country3 = new Country();
                var region3 = new Region();
                var location3 = new Location();

                var getCountry = country3.GetAll();
                var getRegion = region3.GetAll();
                var getLocation = location3.GetAll();

                var resultJoin2 = getRegion.Join(getCountry,
                                                 r => r.Id,
                                                 c => c.RegionId,
                                                 (r, c) => new { r, c })
                                           .Join(getLocation,
                                                 rc => rc.c.Id,
                                                 l => l.CountryId,
                                                 (rc, l) => new RegionAndCountryVM
                                                 {
                                                     CountryId = rc.c.Id,
                                                     CountryName = rc.c.Name,
                                                     RegionId = rc.r.Id,
                                                     RegionName = rc.r.Name,
                                                     City = l.City
                                                 }).ToList();
                break;

            case "6":
                // Instansiasi
                var employee = new Employee();
                var countryE = new Country();
                var regionE = new Region();
                var locationE = new Location();
                var departmentE = new Department();

                // Mengambil data tiap tabel
                var getEmployee = employee.GetAll();
                var getCountryE = countryE.GetAll();
                var getRegionE = regionE.GetAll();
                var getLocationE = locationE.GetAll();
                var getDepartmentE = departmentE.GetAll();

                // LINQ JOIN
                var resultJoinE = getEmployee.Join(getDepartmentE, e => e.DepartmentId, d => d.Id, (e, d) => new { e, d })
                                    .Join(getLocationE, ed => ed.d.Id, l => l.Id, (ed, l) => new { ed.e, ed.d, l })
                                    .Join(getCountryE, edl => edl.l.CountryId, c => c.Id, (edl, c) => new { edl.e, edl.d, edl.l, c })
                                    .Join(getRegionE, edlc => edlc.c.RegionId, r => r.Id, (edlc, r) => new EmployeeJoinVM // View Model untuk Show dari Query
                                    {
                                        EmployeeId = edlc.e.Id,
                                        FullName = edlc.e.FirstName + " " + edlc.e.LastName,
                                        Email = edlc.e.Email,
                                        PhoneNumber = edlc.e.PhoneNumber,
                                        Salary = edlc.e.Salary,
                                        DepartmentName = edlc.d.Name,
                                        StreetAddress = edlc.l.StreetAddr,
                                        CountryName = edlc.c.Name,
                                        RegionName = r.Name
                                    }).ToList();
                break;
            
            case "7":
                var department = new Department();
                var employeeD = new Employee();

                var getDepartment = department.GetAll();
                var getEmployeeD = employeeD.GetAll();

                // LINQ JOIN
                var resultJoinD = getDepartment.Join(getEmployeeD, d => d.Id, e => e.DepartmentId, (d, e) => new { d, e })
                                    .GroupBy(de => de.d.Name)
                                    .Where(depG => depG.Count() > 3)
                                    .Select(depG => new DepartmentJoinVM // View Model untuk Show Query
                                    {
                                        DepartmentName = depG.Key,
                                        TotalEmployee = depG.Count(), // Hitung Total
                                        MinSalary = depG.Min(e => e.e.Salary), // Hitung Minimum
                                        MaxSalary = depG.Max(e => e.e.Salary), // Hitung Maksimum
                                        AverageSalary = depG.Average(e => e.e.Salary) // Hitung Rataan
                                    }).ToList();

                break;

            case "10":
                return false;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }

        return true;
    }
}