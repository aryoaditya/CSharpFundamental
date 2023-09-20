

using System.Data.SqlClient;
using System.Data;

namespace DatabaseConnectivity
{
    public class Location
    {
        public int Id { get; set; }
        public string? StreetAddr { get; set; }
        public string? PostalCode { get; set; }
        public string City { get; set; }
        public string? StateProvince { get; set; }
        public string CountryId { get; set; }

        private readonly string connectionString = "Data Source=DESKTOP-98R3UR4;Database = db_hr_dts; Integrated Security=True;Connect Timeout=30;";

        // GET ALL: Location
        public List<Location> GetAll()
        {
            var location = new List<Location>();

            using var connection = new SqlConnection(connectionString); // Membuat objek koneksi ke database
            using var command = new SqlCommand(); // Membuat objek untuk perintah SQL

            command.Connection = connection; // Mengatur koneksi untuk objek perintah SQL
            command.CommandText = "SELECT * FROM location"; // Query SELECT yang akan dijalankan

            try
            {
                connection.Open(); // Membuka koneksi ke database

                using var reader = command.ExecuteReader(); // Mengeksekusi perintah SQL dan mendapatkan objek reader

                // Memeriksa apakah ada baris data yang ditemukan
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        location.Add(new Location
                        {
                            Id = reader.GetInt32(0),
                            StreetAddr = reader.GetString(1),
                            PostalCode = reader.GetString(2),
                            City = reader.GetString(3),
                            StateProvince = reader.GetString(4),
                            CountryId = reader.GetString(5)
                        });
                    }
                    reader.Close();
                    connection.Close();

                    return location;
                }
            }
            catch (Exception ex)
            {
                // Jika terjadi error
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Location>();
        }

        // GET BY ID: Location
        public Location? GetById(int id)
        {
            using var connection = new SqlConnection(connectionString); // Membuat objek koneksi ke database
            using var command = new SqlCommand(); // Membuat objek untuk perintah SQL

            command.Connection = connection; // Mengatur koneksi untuk objek perintah SQL
            command.CommandText = "SELECT * FROM location WHERE id=@id;"; // Query yang akan dijalankan

            try
            {
                // Membuat parameter untuk query SQL
                var pId = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pId);

                connection.Open();

                using var reader = command.ExecuteReader(); // Mengeksekusi perintah SQL dan mendapatkan objek reader

                // Memeriksa apakah ada baris data yang ditemukan dan mencetak hasil
                if (reader.HasRows)
                {
                    reader.Read();

                    Location reg = new Location
                    {
                        Id = reader.GetInt32(0),
                        StreetAddr = reader.GetString(1),
                        PostalCode = reader.GetString(2),
                        City = reader.GetString(3),
                        StateProvince = reader.GetString(4),
                        CountryId = reader.GetString(5)
                    };

                    reader.Close();
                    connection.Close();

                    return reg;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        // INSERT: Location
        public string Insert(int id, string streetAddr, string postalCode, string city, string stateProvince, string countryId)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "INSERT INTO location VALUES (@id, @street_addr, @post_code, @city, @state_prov, @country_id);"; // Query yang akan dijalankan

            try
            {
                // Membuat parameter SQL untuk mengganti nilai parameter
                var pId = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pId);

                var pStreetAddr = new SqlParameter
                {
                    ParameterName = "@street_addr",
                    Value = streetAddr,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pStreetAddr);

                var pPostCode = new SqlParameter
                {
                    ParameterName = "@post_code",
                    Value = postalCode,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pPostCode);

                var pCity = new SqlParameter
                {
                    ParameterName = "@city",
                    Value = city,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pCity);

                var pStateProv = new SqlParameter
                {
                    ParameterName = "@state_prov",
                    Value = stateProvince,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pStateProv);

                var pCountryId = new SqlParameter
                {
                    ParameterName = "@country_id",
                    Value = countryId,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pCountryId);

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

                    return result.ToString();
                }
                catch (Exception ex)
                {
                    // Melakukan rollback transaction jika terjadi kesalahan
                    transaction.Rollback();
                    return $"Error Transaction: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                // Menangani kesalahan saat membuka koneksi atau eksekusi command
                return $"Error: {ex.Message}";
            }
        }

        // UPDATE: Location
        public string Update(string streetAddr, string postalCode, string city, string stateProvince, string countryId)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();
            string temp;

            command.Connection = connection;

            // Menentukan query yang akan dijalankan untuk update record berdasarkan id
            command.CommandText = "UPDATE location SET steet_address = @street_addr, postal_code = @post_code, city = @city, state_province = @state_prov, country_id = @country_id WHERE id = @id;";

            try
            {
                // Membuat parameter SQL untuk mengganti nilai parameter @street_addr
                var pStreetAddr = new SqlParameter
                {
                    ParameterName = "@street_addr",
                    Value = streetAddr,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pStreetAddr);

                var pPostCode = new SqlParameter
                {
                    ParameterName = "@post_code",
                    Value = postalCode,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pPostCode);

                var pCity = new SqlParameter
                {
                    ParameterName = "@city",
                    Value = city,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pCity);

                var pStateProv = new SqlParameter
                {
                    ParameterName = "@state_prov",
                    Value = stateProvince,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pStateProv);

                var pCountryId = new SqlParameter
                {
                    ParameterName = "@country_id",
                    Value = countryId,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pCountryId);

                connection.Open();
                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();

                    // Memeriksa hasil eksekusi command dan memberikan pesan sesuai
                    temp = result switch
                    {
                        >= 1 => "Update Success",
                        _ => "Update Failed",
                    };
                    return temp;
                }
                catch (Exception ex)
                {
                    // Melakukan rollback transaction jika terjadi kesalahan
                    transaction.Rollback();
                    return $"Error Transaction: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        // DELETE: Location
        public string Delete(int id)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();
            string temp;

            command.Connection = connection;

            // Menentukan query yang akan dijalankan untuk delete record berdasarkan id
            command.CommandText = "DELETE FROM location WHERE id = @id;";

            try
            {
                // Membuat parameter SQL untuk mengganti nilai parameter @id
                var pId = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id,
                    SqlDbType = SqlDbType.Int
                };
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
                    temp = result switch
                    {
                        >= 1 => "Delete Success",
                        _ => "Delete Failed",
                    };
                    return temp;
                }
                catch (Exception ex)
                {
                    // Melakukan rollback transaction jika terjadi kesalahan
                    transaction.Rollback();
                    return $"Error Transaction: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}