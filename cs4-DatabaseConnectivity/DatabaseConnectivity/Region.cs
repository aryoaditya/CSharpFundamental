﻿using BasicConnectivity;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnectivity
{
    public class Region
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        
        // GET ALL: Region
        public List<Region> GetAll()
        {
            var regions = new List<Region>();

            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            command.Connection = connection; // Mengatur koneksi untuk objek perintah SQL
            command.CommandText = "SELECT * FROM regions"; // Query SELECT yang akan dijalankan

            try
            {                
                connection.Open(); // Membuka koneksi ke database

                using var reader = command.ExecuteReader(); // Mengeksekusi perintah SQL dan mendapatkan objek reader

                // Memeriksa apakah ada baris data yang ditemukan
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        regions.Add(new Region
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                    reader.Close();
                    connection.Close();

                    return regions;
                }
            }
            catch (Exception ex)
            {
                // Jika terjadi error
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Region>();
        }

        // GET BY ID: Region
        public Region? GetById(int id)
        {            
            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            command.Connection = connection; // Mengatur koneksi untuk objek perintah SQL
            command.CommandText = "SELECT * FROM regions WHERE id=@id;"; // Query yang akan dijalankan
            

            try
            {
                // Membuat parameter untuk query SQL
                command.Parameters.Add(Provider.SetParameter("@id", id));

                connection.Open();

                using var reader = command.ExecuteReader(); // Mengeksekusi perintah SQL dan mendapatkan objek reader
                
                // Memeriksa apakah ada baris data yang ditemukan dan mencetak hasil
                if (reader.HasRows)
                {
                    reader.Read();

                    Region reg = new Region
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
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

        // INSERT: Region
        public string Insert(string name)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();

            command.Connection = connection;
            command.CommandText = "INSERT INTO regions VALUES (@name);"; // Query yang akan dijalankan

            try
            {
                // Membuat parameter SQL untuk mengganti nilai parameter @name
                command.Parameters.Add(Provider.SetParameter("@name", name));

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

        // UPDATE: Region
        public string Update(int id, string name)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();
            string temp;

            command.Connection = connection;

            // Menentukan query yang akan dijalankan untuk update record berdasarkan id
            command.CommandText = "UPDATE regions SET name = @name WHERE id = @id;";

            try
            {
                // Membuat parameter SQL untuk mengganti nilai parameter @id
                command.Parameters.Add(Provider.SetParameter("@id", id));
                command.Parameters.Add(Provider.SetParameter("@name", name));

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

        // DELETE: Region
        public string Delete(int id)
        {
            using var connection = Provider.GetConnection();
            using var command = Provider.GetCommand();
            string temp;

            command.Connection = connection;

            // Menentukan query yang akan dijalankan untuk delete record berdasarkan id
            command.CommandText = "DELETE FROM regions WHERE id = @id;";

            try
            {
                // Membuat parameter SQL untuk mengganti nilai parameter @id
                command.Parameters.Add(Provider.SetParameter("@id", id));

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