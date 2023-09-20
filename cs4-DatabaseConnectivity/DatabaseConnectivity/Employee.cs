using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnectivity
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        public decimal CommissionPct { get; set; }
        public int ManagerId { get; set; }
        public string JobId { get; set; }
        public int DepartmentId { get; set; }

        private readonly string connectionString = "Data Source=DESKTOP-98R3UR4;Database=db_hr_dts; Integrated Security=True;Connect Timeout=30;";

        // GET ALL: Employee
        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();

            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM employees";

            try
            {
                connection.Open();

                using var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3),
                            PhoneNumber = reader.GetString(4),
                            HireDate = reader.GetDateTime(5),
                            Salary = reader.GetInt32(6),
                            CommissionPct = reader.GetDecimal(7),
                            ManagerId = reader.GetInt32(8),
                            JobId = reader.GetString(9),
                            DepartmentId = reader.GetInt32(10)
                        });
                    }
                    reader.Close();
                    connection.Close();

                    return employees;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return new List<Employee>();
        }

        // GET BY ID: Employee
        public Employee? GetById(int id)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM employees WHERE id=@id";

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

                    return new Employee
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                        HireDate = reader.GetDateTime(5),
                        Salary = reader.GetInt32(6),
                        CommissionPct = reader.GetDecimal(7),
                        ManagerId = reader.GetInt32(8),
                        JobId = reader.GetString(9),
                        DepartmentId = reader.GetInt32(10)
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        // INSERT: Employee
        public string Insert(Employee employee)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();
            string temp;

            command.Connection = connection;
            command.CommandText = "INSERT INTO employees (first_name, last_name, email, phone_number, hire_date, salary, commission_pct, manager_id, job_id, department_id) VALUES (@first_name, @last_name, @email, @phone_number, @hire_date, @salary, @commission_pct, @manager_id, @job_id, @department_id)";

            try
            {
                var pFirstName = new SqlParameter
                {
                    ParameterName = "@first_name",
                    Value = employee.FirstName,
                    SqlDbType = SqlDbType.VarChar
                };
                var pLastName = new SqlParameter
                {
                    ParameterName = "@last_name",
                    Value = employee.LastName,
                    SqlDbType = SqlDbType.VarChar
                };
                var pEmail = new SqlParameter
                {
                    ParameterName = "@email",
                    Value = employee.Email,
                    SqlDbType = SqlDbType.VarChar
                };
                var pPhoneNumber = new SqlParameter
                {
                    ParameterName = "@phone_number",
                    Value = employee.PhoneNumber,
                    SqlDbType = SqlDbType.VarChar
                };
                var pHireDate = new SqlParameter
                {
                    ParameterName = "@hire_date",
                    Value = employee.HireDate,
                    SqlDbType = SqlDbType.DateTime
                };
                var pSalary = new SqlParameter
                {
                    ParameterName = "@salary",
                    Value = employee.Salary,
                    SqlDbType = SqlDbType.Int
                };
                var pCommissionPct = new SqlParameter
                {
                    ParameterName = "@commission_pct",
                    Value = employee.CommissionPct,
                    SqlDbType = SqlDbType.Decimal
                };
                var pManagerId = new SqlParameter
                {
                    ParameterName = "@manager_id",
                    Value = employee.ManagerId,
                    SqlDbType = SqlDbType.Int
                };
                var pJobId = new SqlParameter
                {
                    ParameterName = "@job_id",
                    Value = employee.JobId,
                    SqlDbType = SqlDbType.VarChar
                };
                var pDepartmentId = new SqlParameter
                {
                    ParameterName = "@department_id",
                    Value = employee.DepartmentId,
                    SqlDbType = SqlDbType.Int
                };

                command.Parameters.AddRange(new SqlParameter[] { pFirstName, pLastName, pEmail, pPhoneNumber, pHireDate, pSalary, pCommissionPct, pManagerId, pJobId, pDepartmentId });

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

        // UPDATE: Employee
        public string Update(Employee employee)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();
            string temp;

            command.Connection = connection;
            command.CommandText = "UPDATE employees SET first_name = @first_name, last_name = @last_name, email = @email, phone_number = @phone_number, hire_date = @hire_date, salary = @salary, commission_pct = @commission_pct, manager_id = @manager_id, job_id = @job_id, department_id = @department_id WHERE id = @id";

            try
            {
                var pId = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = employee.Id,
                    SqlDbType = SqlDbType.Int
                };
                var pFirstName = new SqlParameter
                {
                    ParameterName = "@first_name",
                    Value = employee.FirstName,
                    SqlDbType = SqlDbType.VarChar
                };
                var pLastName = new SqlParameter
                {
                    ParameterName = "@last_name",
                    Value = employee.LastName,
                    SqlDbType = SqlDbType.VarChar
                };
                var pEmail = new SqlParameter
                {
                    ParameterName = "@email",
                    Value = employee.Email,
                    SqlDbType = SqlDbType.VarChar
                };
                var pPhoneNumber = new SqlParameter
                {
                    ParameterName = "@phone_number",
                    Value = employee.PhoneNumber,
                    SqlDbType = SqlDbType.VarChar
                };
                var pHireDate = new SqlParameter
                {
                    ParameterName = "@hire_date",
                    Value = employee.HireDate,
                    SqlDbType = SqlDbType.DateTime
                };
                var pSalary = new SqlParameter
                {
                    ParameterName = "@salary",
                    Value = employee.Salary,
                    SqlDbType = SqlDbType.Int
                };
                var pCommissionPct = new SqlParameter
                {
                    ParameterName = "@commission_pct",
                    Value = employee.CommissionPct,
                    SqlDbType = SqlDbType.Decimal
                };
                var pManagerId = new SqlParameter
                {
                    ParameterName = "@manager_id",
                    Value = employee.ManagerId,
                    SqlDbType = SqlDbType.Int
                };
                var pJobId = new SqlParameter
                {
                    ParameterName = "@job_id",
                    Value = employee.JobId,
                    SqlDbType = SqlDbType.VarChar
                };
                var pDepartmentId = new SqlParameter
                {
                    ParameterName = "@department_id",
                    Value = employee.DepartmentId,
                    SqlDbType = SqlDbType.Int
                };

                command.Parameters.AddRange(new SqlParameter[] { pId, pFirstName, pLastName, pEmail, pPhoneNumber, pHireDate, pSalary, pCommissionPct, pManagerId, pJobId, pDepartmentId });

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

        // DELETE: Employee
        public string Delete(int id)
        {
            using var connection = new SqlConnection(connectionString);
            using var command = new SqlCommand();
            string temp;

            command.Connection = connection;
            command.CommandText = "DELETE FROM employees WHERE id = @id";

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
