﻿using System.Data.SqlClient;
using System.Data;

namespace DatabaseConnectivity
{
    public class Country
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public int RegionId { get; set; }

        private readonly string connectionString = "Data Source=DESKTOP-98R3UR4;Database = db_hr_dts; Integrated Security=True;Connect Timeout=30;";

        // GET ALL: Country
        public List<Country> GetAll()
        {
            var countries = new List<Country>();

            using var connection = new SqlConnection(connectionString); // Membuat objek koneksi ke database
            using var command = new SqlCommand(); // Membuat objek untuk perintah SQL

            command.Connection = connection; // Mengatur koneksi untuk objek perintah SQL
            command.CommandText = "SELECT * FROM countries"; // Query SELECT yang akan dijalankan

            try
            {
                connection.Open(); // Membuka koneksi ke database

                using var reader = command.ExecuteReader(); // Mengeksekusi perintah SQL dan mendapatkan objek reader

                // Memeriksa apakah ada baris data yang ditemukan
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        countries.Add(new Country
                        {
                            Id = reader.GetString(0),
                            Name = reader.GetString(1),
                            RegionId = reader.GetInt32(2)
                        });
                    }
                    reader.Close();
                    connection.Close();

                    return countries;
                }
            }
            catch (Exception ex)
            {
                // Jika terjadi error
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Country>();
        }

        // GET BY ID: Country
        public Country? GetById(string id)
        {
            using var connection = new SqlConnection(connectionString); // Membuat objek koneksi ke database
            using var command = new SqlCommand(); // Membuat objek untuk perintah SQL

            command.Connection = connection; // Mengatur koneksi untuk objek perintah SQL
            command.CommandText = "SELECT * FROM countries WHERE id=@id;"; // Query yang akan dijalankan

            try
            {
                // Membuat parameter untuk query SQL
                var pId = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pId);

                connection.Open();

                using var reader = command.ExecuteReader(); // Mengeksekusi perintah SQL dan mendapatkan objek reader

                // Memeriksa apakah ada baris data yang ditemukan dan mencetak hasil
                if (reader.HasRows)
                {
                    reader.Read();

                    Country reg = new Country
                    {
                        Id = reader.GetString(0),
                        Name = reader.GetString(1),
                        RegionId = reader.GetInt32(2)
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

        // INSERT: Country
        public string Insert(string id, string name, int regId)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "INSERT INTO countries VALUES (@id, @name, @reg_id);"; // Query yang akan dijalankan

            try
            {
                // Membuat parameter SQL untuk mengganti nilai parameter @id
                var pId = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pId);

                // Membuat parameter SQL untuk mengganti nilai parameter @name
                var pName = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pName);

                // Membuat parameter SQL untuk mengganti nilai parameter @reg_id
                var pRegId = new SqlParameter
                {
                    ParameterName = "@reg_id",
                    Value = regId,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pRegId);

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

        // UPDATE: Country
        public string Update(string id, string name, int regId)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();
            string temp;

            command.Connection = connection;

            // Menentukan query yang akan dijalankan untuk update record berdasarkan id
            command.CommandText = "UPDATE countries SET name = @name, region_id = @reg_id WHERE id = @id;";

            try
            {
                // Membuat parameter SQL untuk mengganti nilai parameter @id
                var pId = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pId);

                // Membuat parameter SQL untuk mengganti nilai parameter @name
                var pName = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pName);

                // Membuat parameter SQL untuk mengganti nilai parameter @reg_id
                var pRegId = new SqlParameter
                {
                    ParameterName = "@reg_id",
                    Value = regId,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pRegId);

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

        // DELETE: Country
        public string Delete(string id)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();
            string temp;

            command.Connection = connection;

            // Menentukan query yang akan dijalankan untuk delete record berdasarkan id
            command.CommandText = "DELETE FROM countries WHERE id = @id;";

            try
            {
                // Membuat parameter SQL untuk mengganti nilai parameter @id
                var pId = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id,
                    SqlDbType = SqlDbType.VarChar
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