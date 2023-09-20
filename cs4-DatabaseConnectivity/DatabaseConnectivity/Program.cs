using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace DatabaseConnectivity;

public class Program
{
    private static void Main()
    {
        var region = new Region();
        //RegionUI.AllRegion(region);
        //RegionUI.InsertRegion(region);
        //RegionUI.UpdateRegion(region, 24, "Maluku Timur");
        //RegionUI.RegionById(region, 24);
        RegionUI.DeleteRegion(region, 24);
        RegionUI.RegionById(region, 24);
    }
}