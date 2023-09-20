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

        private readonly string connectionString = "Data Source=DESKTOP-98R3UR4;Database=db_hr_dts;Integrated Security=True;Connect Timeout=30;";

        public List<Job> GetAll()
        {
            var jobs = new List<Job>();

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();

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
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM jobs WHERE id=@id";

            try
            {
                var pId = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pId);

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
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "INSERT INTO jobs VALUES (@id, @title, @minSalary, @maxSalary)";

            try
            {
                var pId = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pId);

                var pTitle = new SqlParameter
                {
                    ParameterName = "@title",
                    Value = title,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pTitle);

                var pMinSalary = new SqlParameter
                {
                    ParameterName = "@minSalary",
                    Value = minSalary,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pMinSalary);

                var pMaxSalary = new SqlParameter
                {
                    ParameterName = "@maxSalary",
                    Value = maxSalary,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pMaxSalary);

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
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "UPDATE jobs SET title = @title, min_salary = @minSalary, max_salary = @maxSalary WHERE id = @id";

            try
            {
                var pId = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pId);

                var pTitle = new SqlParameter
                {
                    ParameterName = "@title",
                    Value = title,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pTitle);

                var pMinSalary = new SqlParameter
                {
                    ParameterName = "@minSalary",
                    Value = minSalary,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pMinSalary);

                var pMaxSalary = new SqlParameter
                {
                    ParameterName = "@maxSalary",
                    Value = maxSalary,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pMaxSalary);

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
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "DELETE FROM jobs WHERE id = @id";

            try
            {
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