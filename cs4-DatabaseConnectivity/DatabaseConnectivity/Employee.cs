using BasicConnectivity;
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
        public int? ManagerId { get; set; }
        public string JobId { get; set; }
        public int DepartmentId { get; set; }

        // GET ALL: Employee
        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();

            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

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
                            ManagerId = reader.IsDBNull(8) ? null : reader.GetInt32(8),
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
            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            command.Connection = connection;
            command.CommandText = "SELECT * FROM employees WHERE id=@id";

            try
            {
                // Membuat parameter untuk query SQL
                command.Parameters.Add(Provider.SetParameter("@id", id));

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
                        ManagerId = reader.IsDBNull(8) ? null : reader.GetInt32(8),
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
            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            string temp;

            command.Connection = connection;
            command.CommandText = "INSERT INTO employees VALUES (@id, @first_name, @last_name, @email, @phone_number, @hire_date, @salary, @commission_pct, @manager_id, @job_id, @department_id)";

            try
            {
                // Membuat parameter untuk query SQL
                command.Parameters.Add(Provider.SetParameter("@id", employee.Id));
                command.Parameters.Add(Provider.SetParameter("@first_name", employee.FirstName));
                command.Parameters.Add(Provider.SetParameter("@last_name", employee.LastName));
                command.Parameters.Add(Provider.SetParameter("@email", employee.Email));
                command.Parameters.Add(Provider.SetParameter("@phone_number", employee.PhoneNumber));
                command.Parameters.Add(Provider.SetParameter("@hire_date", employee.HireDate));
                command.Parameters.Add(Provider.SetParameter("@salary", employee.Salary));
                command.Parameters.Add(Provider.SetParameter("@commission_pct", employee.CommissionPct));
                command.Parameters.Add(Provider.SetParameter("@manager_id", employee.ManagerId));
                command.Parameters.Add(Provider.SetParameter("@job_id", employee.JobId));
                command.Parameters.Add(Provider.SetParameter("@department_id", employee.DepartmentId));

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
        public string Update(Employee employee, int id)
        {
            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            string temp;

            command.Connection = connection;
            command.CommandText = "UPDATE employees SET first_name = @first_name, last_name = @last_name, email = @email, phone_number = @phone_number, hire_date = @hire_date, salary = @salary, commission_pct = @commission_pct, manager_id = @manager_id, job_id = @job_id, department_id = @department_id WHERE id = @id";

            try
            {
                // Membuat parameter untuk query SQL
                command.Parameters.Add(Provider.SetParameter("@id", id));
                command.Parameters.Add(Provider.SetParameter("@first_name", employee.FirstName));
                command.Parameters.Add(Provider.SetParameter("@last_name", employee.LastName));
                command.Parameters.Add(Provider.SetParameter("@email", employee.Email));
                command.Parameters.Add(Provider.SetParameter("@phone_number", employee.PhoneNumber));
                command.Parameters.Add(Provider.SetParameter("@hire_date", employee.HireDate));
                command.Parameters.Add(Provider.SetParameter("@salary", employee.Salary));
                command.Parameters.Add(Provider.SetParameter("@commission_pct", employee.CommissionPct));
                command.Parameters.Add(Provider.SetParameter("@manager_id", employee.ManagerId));
                command.Parameters.Add(Provider.SetParameter("@job_id", employee.JobId));
                command.Parameters.Add(Provider.SetParameter("@department_id", employee.DepartmentId));

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
            using var connection = Provider.GetConnection(); // Membuat objek koneksi ke database
            using var command = Provider.GetCommand(); // Membuat objek untuk perintah SQL

            string temp;

            command.Connection = connection;
            command.CommandText = "DELETE FROM employees WHERE id = @id";

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
