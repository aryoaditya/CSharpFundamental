using System.Data.SqlClient;

namespace BasicConnectivity;

public class Provider
{
    private static readonly string connectionString =
        "Data Source=DESKTOP-98R3UR4;Database = db_hr_dts; Integrated Security=True;Connect Timeout=30;";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    public static SqlCommand GetCommand()
    {
        return new SqlCommand();
    }

    public static SqlParameter SetParameter(string name, object value)
    {
        return new SqlParameter(name, value);
    }
}