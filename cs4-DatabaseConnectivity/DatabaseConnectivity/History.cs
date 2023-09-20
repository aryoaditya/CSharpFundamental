using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnectivity
{
    public class History
    {
        public DateTime StartDate { get; set; }
        public int EmployeeId { get; set; }
        public DateTime EndDate { get; set; }
        public int DepartmentId { get; set; }
        public int JobId { get; set; }

        private readonly string connectionString = "Data Source=DESKTOP-98R3UR4;Database=db_hr_dts; Integrated Security=True;Connect Timeout=30;";

        // GET ALL: History
        public List<History> GetAll()
        {
            var histories = new List<History>();

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM history";

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        histories.Add(new History
                        {
                            StartDate = reader.GetDateTime(0),
                            EmployeeId = reader.GetInt32(1),
                            EndDate = reader.GetDateTime(2),
                            DepartmentId = reader.GetInt32(3),
                            JobId = reader.GetInt32(4)
                        });
                    }
                    reader.Close();
                    connection.Close();

                    return histories;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<History>();
        }

        // GET BY ID: History
        public History? GetById(int employeeId)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM history WHERE employee_id=@employeeId";

            try
            {
                var pEmployeeId = new SqlParameter
                {
                    ParameterName = "@employeeId",
                    Value = employeeId,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pEmployeeId);

                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    History history = new History
                    {
                        StartDate = reader.GetDateTime(0),
                        EmployeeId = reader.GetInt32(1),
                        EndDate = reader.GetDateTime(2),
                        DepartmentId = reader.GetInt32(3),
                        JobId = reader.GetInt32(4)
                    };

                    reader.Close();
                    connection.Close();

                    return history;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        // INSERT: History
        public string Insert(DateTime startDate, int employeeId, DateTime endDate, int departmentId, int jobId)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();
            string temp;

            command.Connection = connection;
            command.CommandText = "INSERT INTO history VALUES (@startDate, @employeeId, @endDate, @departmentId, @jobId)";

            try
            {
                var pStartDate = new SqlParameter
                {
                    ParameterName = "@startDate",
                    Value = startDate,
                    SqlDbType = SqlDbType.DateTime
                };
                var pEmployeeId = new SqlParameter
                {
                    ParameterName = "@employeeId",
                    Value = employeeId,
                    SqlDbType = SqlDbType.Int
                };
                var pEndDate = new SqlParameter
                {
                    ParameterName = "@endDate",
                    Value = endDate,
                    SqlDbType = SqlDbType.DateTime
                };
                var pDepartmentId = new SqlParameter
                {
                    ParameterName = "@departmentId",
                    Value = departmentId,
                    SqlDbType = SqlDbType.Int
                };
                var pJobId = new SqlParameter
                {
                    ParameterName = "@jobId",
                    Value = jobId,
                    SqlDbType = SqlDbType.Int
                };

                command.Parameters.Add(pStartDate);
                command.Parameters.Add(pEmployeeId);
                command.Parameters.Add(pEndDate);
                command.Parameters.Add(pDepartmentId);
                command.Parameters.Add(pJobId);

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

        // UPDATE: History
        public string Update(int employeeId, DateTime endDate, int departmentId, int jobId)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();
            string temp;

            command.Connection = connection;

            command.CommandText = "UPDATE history SET end_date = @endDate, department_id = @departmentId, job_id = @jobId WHERE employee_id = @employeeId";

            try
            {
                var pEmployeeId = new SqlParameter
                {
                    ParameterName = "@employeeId",
                    Value = employeeId,
                    SqlDbType = SqlDbType.Int
                };
                var pEndDate = new SqlParameter
                {
                    ParameterName = "@endDate",
                    Value = endDate,
                    SqlDbType = SqlDbType.DateTime
                };
                var pDepartmentId = new SqlParameter
                {
                    ParameterName = "@departmentId",
                    Value = departmentId,
                    SqlDbType = SqlDbType.Int
                };
                var pJobId = new SqlParameter
                {
                    ParameterName = "@jobId",
                    Value = jobId,
                    SqlDbType = SqlDbType.Int
                };

                command.Parameters.Add(pEmployeeId);
                command.Parameters.Add(pEndDate);
                command.Parameters.Add(pDepartmentId);
                command.Parameters.Add(pJobId);

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

        // DELETE: History
        public string Delete(int employeeId)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();
            string temp;

            command.Connection = connection;

            command.CommandText = "DELETE FROM history WHERE employee_id = @employeeId";

            try
            {
                var pEmployeeId = new SqlParameter
                {
                    ParameterName = "@employeeId",
                    Value = employeeId,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(pEmployeeId);

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
