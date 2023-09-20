using BasicConnectivity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnectivity
{
    public class Job
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }

        public List<Job> GetAll()
        {
            var jobs = new List<Job>();

            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            command.Connection = connection;
            command.CommandText = "SELECT * FROM jobs";

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        jobs.Add(new Job
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            MinSalary = reader.GetInt32(2),
                            MaxSalary = reader.GetInt32(3)
                        });
                    }
                    reader.Close();
                    connection.Close();

                    return jobs;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Job>();
        }

        public Job? GetById(int id)
        {
            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            command.Connection = connection;
            command.CommandText = "SELECT * FROM jobs WHERE id=@id";

            try
            {
                // Membuat parameter untuk query SQL
                command.Parameters.Add(Provider.SetParameter("@id", id));

                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    Job job = new Job
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        MinSalary = reader.GetInt32(2),
                        MaxSalary = reader.GetInt32(3)
                    };

                    reader.Close();
                    connection.Close();

                    return job;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }
        public string Insert(int id, string title, int minSalary, int maxSalary)
        {
            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            command.Connection = connection;
            command.CommandText = "INSERT INTO jobs VALUES (@id, @title, @minSalary, @maxSalary)";

            try
            {
                // Membuat parameter untuk query SQL
                command.Parameters.Add(Provider.SetParameter("@id", id));
                command.Parameters.Add(Provider.SetParameter("@title", title));
                command.Parameters.Add(Provider.SetParameter("@minSalary", minSalary));
                command.Parameters.Add(Provider.SetParameter("@maxSalary", maxSalary));

                connection.Open();

                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();

                    return result >= 1 ? "Insert Success" : "Insert Failed";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return $"Error Transaction: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public string Update(int id, string title, int minSalary, int maxSalary)
        {
            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            command.Connection = connection;
            command.CommandText = "UPDATE jobs SET title = @title, min_salary = @minSalary, max_salary = @maxSalary WHERE id = @id";

            try
            {
                // Membuat parameter untuk query SQL
                command.Parameters.Add(Provider.SetParameter("@id", id));
                command.Parameters.Add(Provider.SetParameter("@title", title));
                command.Parameters.Add(Provider.SetParameter("@minSalary", minSalary));
                command.Parameters.Add(Provider.SetParameter("@maxSalary", maxSalary));

                connection.Open();

                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();

                    return result >= 1 ? "Update Success" : "Update Failed";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return $"Error Transaction: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public string Delete(int id)
        {
            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            command.Connection = connection;
            command.CommandText = "DELETE FROM jobs WHERE id = @id";

            try
            {
                // Membuat parameter untuk query SQL
                command.Parameters.Add(Provider.SetParameter("@id", id));

                connection.Open();

                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();

                    return result >= 1 ? "Delete Success" : "Delete Failed";
                }
                catch (Exception ex)
                {
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
