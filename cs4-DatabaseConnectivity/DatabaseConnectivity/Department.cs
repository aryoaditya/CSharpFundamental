using BasicConnectivity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnectivity
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int ManagerId { get; set; }

        // GET ALL: Department
        public List<Department> GetAll()
        {
            var departments = new List<Department>();

            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            command.Connection = connection;
            command.CommandText = "SELECT * FROM departments";

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        departments.Add(new Department
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            LocationId = reader.GetInt32(2),
                            ManagerId = reader.GetInt32(3)
                        });
                    }
                    reader.Close();
                    connection.Close();

                    return departments;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Department>();
        }

        // GET BY ID: Department
        public Department? GetById(int id)
        {
            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            command.Connection = connection;
            command.CommandText = "SELECT * FROM departments WHERE id=@id;";

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

                    Department dept = new Department
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        LocationId = reader.GetInt32(2),
                        ManagerId = reader.GetInt32(3)
                    };

                    reader.Close();
                    connection.Close();

                    return dept;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        // INSERT: Department
        public string Insert(string name, int locationId, int managerId)
        {
            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            string temp;

            command.Connection = connection;
            command.CommandText = "INSERT INTO departments VALUES (@name, @locationId, @managerId);";

            try
            {
                var pName = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pName);

                var pLocationId = new SqlParameter
                {
                    ParameterName = "@locationId",
                    Value = locationId,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pLocationId);

                var pManagerId = new SqlParameter
                {
                    ParameterName = "@managerId",
                    Value = managerId,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pManagerId);

                connection.Open();

                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();

                    temp = result switch
                    {
                        >= 1 => "Insert Success",
                        _ => "Insert Failed",
                    };
                    return temp;
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

        // UPDATE: Department
        public string Update(int id, string name, int locationId, int managerId)
        {
            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            string temp;

            command.Connection = connection;
            command.CommandText = "UPDATE departments SET name = @name, location_id = @locationId, manager_id = @managerId WHERE id = @id;";

            try
            {
                var pId = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pId);

                var pName = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name,
                    SqlDbType = SqlDbType.VarChar
                };
                command.Parameters.Add(pName);

                var pLocationId = new SqlParameter
                {
                    ParameterName = "@locationId",
                    Value = locationId,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pLocationId);

                var pManagerId = new SqlParameter
                {
                    ParameterName = "@managerId",
                    Value = managerId,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pManagerId);

                connection.Open();
                using var transaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = transaction;

                    var result = command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();

                    temp = result switch
                    {
                        >= 1 => "Update Success",
                        _ => "Update Failed",
                    };
                    return temp;
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

        // DELETE: Department
        public string Delete(int id)
        {
            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            string temp;

            command.Connection = connection;
            command.CommandText = "DELETE FROM departments WHERE id = @id;";

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

                    temp = result switch
                    {
                        >= 1 => "Delete Success",
                        _ => "Delete Failed",
                    };
                    return temp;
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
