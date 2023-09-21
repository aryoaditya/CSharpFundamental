using BasicConnectivity;

namespace DatabaseConnectivity;

public class Program
{
    private static void Main()
    {

        var choice = true;
        while (choice)
        {
            Console.WriteLine("1. List all regions");
            Console.WriteLine("2. List all countries");
            Console.WriteLine("3. List all locations");
            Console.WriteLine("4. List regions with Where");
            Console.WriteLine("5. Join tables regions and countries and locations");
            Console.WriteLine("6. Join tables Employee and Department and Location and Country and Region");
            Console.WriteLine("7. Join tables Department and Employee and Show Summary");
            Console.WriteLine("10. Exit");
            Console.Write("Enter your choice: ");
            var input = Console.ReadLine();
            choice = Menu(input);
        }

        // Processing Region
        //var region = new Region();
        //Show.AllRegion(region);
        //Show.InsertRegion(region, "Maluku Utara");
        //Show.UpdateRegion(region, 24, "Maluku Timur");
        //Show.RegionById(region, 24);
        //Show.DeleteRegion(region, 27);
        //Show.AllRegion(region);
        //Show.RegionById(region, 24);

        // Processing Country
        //var country = new Country();
        //Show.AllCountry(country);
        //Show.InsertCountry(country, "IO", "Indo", 2);
        //Show.UpdateCountry(country, "IO", "Indon", 2);
        //Show.CountryById(country, "IO");
        //Show.DeleteCountry(country, "IO");
        //Show.CountryById(country, 24);


        // Processing Location
        //var location = new Location();
        //Show.AllLocation(location);
        //Show.InsertLocation(location, 100, "Jalan O", "1320", "Lamongan", "Jawa Timur", "ID");
        //Show.UpdateLocation(location, "IO", "Indon", 2);
        //Show.LocationById(location, "IO");
        //Show.DeleteLocation(location, 100);
        //Show.LocationById(location, 24);

        // Processing Location
        //var job = new Job();
        //Show.AllJobs(job);
        //Show.InsertJob(job, 100, "Salesman", 1000, 5000);
        //Show.UpdateJob(job, 100, "Salesman", 1000, 2000);
        //Show.JobById(job, 100);
        //Show.DeleteJob(job, 100);
        //Show.JobById(job, 24);

        // Processing Department
        //var department = new Department();
        //Show.AllDepartments(department);
        //Show.InsertDepartment(department, "IT Programmer", 1, 101);
        //Show.UpdateDepartment(department, 101, "Development", 1, 102);
        //Show.DepartmentById(department, 10);
        //Show.DeleteDepartment(department, 101);
        //Show.DepartmentById(department, 101);

        // Processing History
        //var history = new History();
        //Show.AllHistories(history);
        //Show.InsertHistory(history, DateTime.Now, 123, DateTime.Now.AddYears(1), 456, 789);
        //Show.UpdateHistory(history, 123, DateTime.Now.AddYears(2), 789, 456);
        //Show.HistoryByEmployeeId(history, 123);
        //Show.DeleteHistory(history, 123);
        //Show.HistoryByEmployeeId(history, 123);



        // Processing Employee
        //var employee = new Employee();
        //Show.AllEmployees(employee);
        //Show.InsertEmployee(employee, "Ahmad", "Sutoni", "sutoni@gmail.com", "123-456-7890", DateTime.Now, 50000, 0.05m, 1, "IT_PROG", 1);
        //Show.EmployeeById(employee, 1);
        //Show.UpdateEmployee(employee, 1, "Ahmad", "Sutoni", "sutoni@gmail.com", "123-456-7890", DateTime.Now, 55000, 0.06m, 1, "IT_PROG", 1);
        //Show.DeleteEmployee(employee, 1);
        //Show.EmployeeById(employee, 1);

    }


    public static bool Menu(string input)
    {
        switch (input)
        {
            case "1":
                var region = new Region();
                var regions = region.GetAll();
                GeneralMenu.List(regions, "regions");
                break;
            case "2":
                var country = new Country();
                var countries = country.GetAll();
                GeneralMenu.List(countries, "countries");
                break;
            case "3":
                var location = new Location();
                var locations = location.GetAll();
                GeneralMenu.List(locations, "locations");
                break;
            case "4":
                var region2 = new Region();
                string input2 = Console.ReadLine();
                var result = region2.GetAll().Where(r => r.Name.Contains(input2)).ToList();
                GeneralMenu.List(result, "regions");
                break;
            case "5":
                var country3 = new Country();
                var region3 = new Region();
                var location3 = new Location();

                var getCountry = country3.GetAll();
                var getRegion = region3.GetAll();
                var getLocation = location3.GetAll();

                //var resultJoin = (from r in getRegion
                //                  join c in getCountry on r.Id equals c.RegionId
                //                  join l in getLocation on c.Id equals l.CountryId
                //                  select new RegionAndCountryVM
                //                  {
                //                      CountryId = c.Id,
                //                      CountryName = c.Name,
                //                      RegionId = r.Id,
                //                      RegionName = r.Name,
                //                      City = l.City
                //                  }).ToList();

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

                /*foreach (var item in resultJoin2)
                {
                    Console.WriteLine($"{item.Id} - {item.NameRegion} - {item.NameCountry} - {item.RegionId}");
                }*/

                GeneralMenu.List(resultJoin2, "regions and countries");
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

                GeneralMenu.List(resultJoinE, "Employees"); // Show list dari query
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

                GeneralMenu.List(resultJoinD, "Department Summary"); // Show list dari query

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