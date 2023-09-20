using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnectivity;

public class Program
{
    static string connectionString = "Data Source=DESKTOP-98R3UR4;Database = db_hr_dts; Integrated Security=True;Connect Timeout=30;";
    static SqlConnection conn;
    private static void Main()
    {
        // Mengambil dan mencetak semua record pada tabel region
        GetAllRegions();

        // Insert row ke tabel region dengan nama "Kepulauan Seribu"
        InsertRegion("Kepulauan Seribu");

        // Mengambil dan mencetak semua record pada tabel region berdasarkan Id
        GetRegionById(23);

        // Update row pada tabel region berdasarkan Id, mengirim parameter nama yg ingin diubah
        UpdateRegion(23, "Kepulauan");
        GetAllRegions();

        // Delete row pada tabel region berdasarkan Id
        DeleteRegion(23);
        GetAllRegions();
    }

    // GET ALL: Region
    public static void GetAllRegions()
    {
        // Membuat objek koneksi ke database
        using var connection = new SqlConnection(connectionString);

        // Membuat objek untuk perintah SQL
        using var command = new SqlCommand();

        // Mengatur koneksi untuk objek perintah SQL
        command.Connection = connection;

        // Menentukan query SELECT yang akan dijalankan
        command.CommandText = "SELECT * FROM regions";

        try
        {
            // Membuka koneksi ke database
            connection.Open();

            // Mengeksekusi perintah SQL dan mendapatkan objek reader
            using var reader = command.ExecuteReader();

            // Memeriksa apakah ada baris data yang ditemukan
            if (reader.HasRows)
                while (reader.Read())
                {
                    // Mencetak Id dan Name dari baris saat ini
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                }
            else
                // Jika tidak ada baris data yang ditemukan
                Console.WriteLine("No rows found.");

            // Menutup objek reader
            reader.Close();

            // Menutup koneksi ke database
            connection.Close();
        }
        catch (Exception ex)
        {
            // Jika terjadi error
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // GET BY ID: Region
    public static void GetRegionById(int id) {
        // Membuat objek koneksi ke database
        using var connection = new SqlConnection(connectionString);

        // Membuat objek untuk perintah SQL
        using var command = new SqlCommand();

        // Mengatur koneksi untuk objek perintah SQL
        command.Connection = connection;

        // Menentukan query yang akan dijalankan dengan mengambil record berdasarkan id
        command.CommandText = "SELECT * FROM regions WHERE id=@id;";

        try
        {
            // Membuat parameter untuk query SQL
            var pId = new SqlParameter();

            // Menentukan nama parameter
            pId.ParameterName = "@id";

            // Menentukan nilai parameter dengan nilai id
            pId.Value = id;

            // Menetapkan tipe data parameter
            pId.SqlDbType = SqlDbType.Int;

            // Menambahkan parameter ke objek perintah SQL
            command.Parameters.Add(pId);

            connection.Open();

            // Mengeksekusi perintah SQL dan mendapatkan hasil dalam bentuk SqlDataReader
            using var reader = command.ExecuteReader();

            // Memeriksa apakah ada baris data yang ditemukan dan mencetak hasil
            if (reader.HasRows)
                while (reader.Read())
                {
                    Console.WriteLine("Id: " + reader.GetInt32(0));
                    Console.WriteLine("Name: " + reader.GetString(1));
                }
            else
                Console.WriteLine("No rows found.");

            reader.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // INSERT: Region
    public static void InsertRegion(string name)
    {
        using var connection = new SqlConnection(connectionString);
        using var command = new SqlCommand();

        command.Connection = connection;

        // Menentukan query yang akan dijalankan untuk menambah record dengan field name
        command.CommandText = "INSERT INTO regions VALUES (@name);";

        try
        {
            // Membuat parameter SQL untuk mengganti nilai parameter @name
            var pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.Value = name;
            pName.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pName);

            connection.Open();

            // Memulai transaction
            using var transaction = connection.BeginTransaction();
            try
            {
                // Menetapkan transaction untuk command
                command.Transaction = transaction;

                var result = command.ExecuteNonQuery();

                // Melakukan commit transaction jika perintah berhasil
                transaction.Commit();
                connection.Close();

                // Memeriksa hasil eksekusi perintah dan memberikan pesan sesuai
                switch (result)
                {
                    case >= 1:
                        Console.WriteLine("Insert Success");
                        break;
                    default:
                        Console.WriteLine("Insert Failed");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Melakukan rollback transaction jika terjadi kesalahan
                transaction.Rollback();
                Console.WriteLine($"Error Transaction: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            // Menangani kesalahan saat membuka koneksi atau eksekusi command
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // UPDATE: Region
    public static void UpdateRegion(int id, string name) 
    {
        using var connection = new SqlConnection(connectionString);
        using var command = new SqlCommand();

        command.Connection = connection;

        // Menentukan query yang akan dijalankan untuk update record berdasarkan id
        command.CommandText = "UPDATE regions SET name = @name WHERE id = @id;";

        try
        {
            // Membuat parameter SQL untuk mengganti nilai parameter @id
            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pId);

            // Membuat parameter SQL untuk mengganti nilai parameter @name
            var pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.Value = name;
            pName.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pName);

            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                command.Transaction = transaction;

                var result = command.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

                // Memeriksa hasil eksekusi command dan memberikan pesan sesuai
                switch (result)
                {
                    case 1:
                        Console.WriteLine("Update Success");
                        break;
                    default:
                        Console.WriteLine("Update Failed");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Melakukan rollback transaction jika terjadi kesalahan
                transaction.Rollback();
                Console.WriteLine($"Error Transaction: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // DELETE: Region
    public static void DeleteRegion(int id) 
    {
        using var connection = new SqlConnection(connectionString);
        using var command = new SqlCommand();

        command.Connection = connection;

        // Menentukan query yang akan dijalankan untuk delete record berdasarkan id
        command.CommandText = "DELETE FROM regions WHERE id = @id;";

        try
        {
            // Membuat parameter SQL untuk mengganti nilai parameter @id
            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int;
            command.Parameters.Add(pId);

            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                command.Transaction = transaction;

                var result = command.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

                // Memeriksa hasil eksekusi command dan memberikan pesan sesuai
                switch (result)
                {
                    case >= 1:
                        Console.WriteLine("Delete Success");
                        break;
                    default:
                        Console.WriteLine("Delete Failed");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Melakukan rollback transaction jika terjadi kesalahan
                transaction.Rollback();
                Console.WriteLine($"Error Transaction: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}