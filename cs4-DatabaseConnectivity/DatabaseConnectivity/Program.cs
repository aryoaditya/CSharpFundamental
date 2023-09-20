using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnectivity;

public class Program
{
    private static void Main()
    {
        // Processing Region
        //var region = new Region();
        //Show.AllRegion(region);
        //Show.InsertRegion(region, "Maluku Utara");
        //Show.UpdateRegion(region, 24, "Maluku Timur");
        //Show.RegionById(region, 24);
        //Show.DeleteRegion(region, 24);
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
        var location = new Location();
        Show.AllLocation(location);
        //Show.InsertLocation(location, "IO", "Indo", 2);
        //Show.UpdateLocation(location, "IO", "Indon", 2);
        //Show.LocationById(location, "IO");
        //Show.DeleteLocation(location, "IO");
        //Show.LocationById(location, 24);

        // Processing Location
        var job = new Job();
        Show.AllJobs(job);
        //Show.InsertJob(job, 100, "Salesman", 1000, 5000);
        //Show.UpdateJob(job, 100, "Salesman", 1000, 2000);
        //Show.JobById(job, 100);
        //Show.DeleteJob(job, 100);
        //Show.JobById(job, 24);

        // Processing Department
        var department = new Department();
        Show.AllDepartments(department);
        //Show.InsertDepartment(department, "IT Programmer", 1, 101);
        //Show.UpdateDepartment(department, 101, "Development", 1, 102);
        //Show.DepartmentById(department, 101);
        //Show.DeleteDepartment(department, 101);
        //Show.DepartmentById(department, 101);

        // Processing History
        var history = new History();
        Show.AllHistories(history);
        //Show.InsertHistory(history, DateTime.Now, 123, DateTime.Now.AddYears(1), 456, 789);
        //Show.UpdateHistory(history, 123, DateTime.Now.AddYears(2), 789, 456);
        //Show.HistoryByEmployeeId(history, 123);
        //Show.DeleteHistory(history, 123);
        //Show.HistoryByEmployeeId(history, 123);



        // Processing Employee
        var employee = new Employee();
        Show.AllEmployees(employee);
        //Show.InsertEmployee(employee, "Ahmad", "Sutoni", "sutoni@gmail.com", "123-456-7890", DateTime.Now, 50000, 0.05m, 1, "IT_PROG", 1);
        //Show.EmployeeById(employee, 1);
        //Show.UpdateEmployee(employee, 1, "Ahmad", "Sutoni", "sutoni@gmail.com", "123-456-7890", DateTime.Now, 55000, 0.06m, 1, "IT_PROG", 1);
        //Show.DeleteEmployee(employee, 1);
        //Show.EmployeeById(employee, 1);

    }
}