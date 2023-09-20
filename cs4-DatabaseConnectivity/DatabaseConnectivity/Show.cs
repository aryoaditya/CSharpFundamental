namespace DatabaseConnectivity
{
    public class Show
    {
        // Cetak hasil All Region
        public static void AllRegion(Region region)
        {
            var getAllRegion = region.GetAll();

            if (getAllRegion.Count > 0)
            {
                foreach (var reg in getAllRegion)
                {
                    Console.WriteLine($"Id: {reg.Id}, Name: {reg.Name}");
                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }

        // Cetak hasil Region by Id
        public static void RegionById(Region region, int id)
        {
            var getRegionById = region.GetById(id);
            if (getRegionById != null)
            {
                Console.WriteLine("Hasil yang ditemukan : ");
                Console.WriteLine($"Id: {getRegionById.Id}, Name: {getRegionById.Name}");
            }
            else
                Console.WriteLine("Hasil tidak ditemukan");
            
        }

        // Cetak hasil Insert Region
        public static void InsertRegion(Region region, string name)
        {
            var insertResult = region.Insert(name);
            int.TryParse(insertResult, out int result);
            if (result > 0)
            {
                Console.WriteLine("Insert Success");
            }
            else
            {
                Console.WriteLine("Insert Failed");
                Console.WriteLine(insertResult);
            }
        }

        // Cetak hasil Update Region
        public static void UpdateRegion(Region region, int id, string nama)
        {
            var updateResult = region.Update(id, nama);

            Console.WriteLine(updateResult);
        }

        // Cetak hasil Delete Region
        public static void DeleteRegion(Region region, int id)
        {
            var deleteResult = region.Delete(id);

            Console.WriteLine(deleteResult);
        }


        // Cetak hasil All Country
        public static void AllCountry(Country country)
        {
            var getAllCountry = country.GetAll();

            if (getAllCountry.Count > 0)
            {
                foreach (var reg in getAllCountry)
                {
                    Console.WriteLine($"Id: {reg.Id}, Name: {reg.Name}");
                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }

        // Cetak hasil Country by Id
        public static void CountryById(Country country, string id)
        {
            var getCountryById = country.GetById(id);
            if (getCountryById != null)
            {
                Console.WriteLine("Hasil yang ditemukan : ");
                Console.WriteLine($"Id: {getCountryById.Id}, Name: {getCountryById.Name}");
            }
            else
                Console.WriteLine("Hasil tidak ditemukan");

        }

        // Cetak hasil Insert Country
        public static void InsertCountry(Country country, string id, string nama, int reg_id)
        {
            var insertResult = country.Insert(id, nama, reg_id);
            int.TryParse(insertResult, out int result);
            if (result > 0)
            {
                Console.WriteLine("Insert Success");
            }
            else
            {
                Console.WriteLine("Insert Failed");
                Console.WriteLine(insertResult);
            }
        }

        // Cetak hasil Update Country
        public static void UpdateCountry(Country country, string id, string nama, int reg_id)
        {
            var updateResult = country.Update(id, nama, reg_id);

            Console.WriteLine(updateResult);
        }

        // Cetak hasil Delete Country
        public static void DeleteCountry(Country country, string id)
        {
            var deleteResult = country.Delete(id);

            Console.WriteLine(deleteResult);
        }


        // Cetak hasil All Location
        public static void AllLocation(Location location)
        {
            var getAllLocation = location.GetAll();

            if (getAllLocation.Count > 0)
            {
                foreach (var reg in getAllLocation)
                {
                    Console.WriteLine($"Id: {reg.Id}, Name: {reg.StreetAddr}");
                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }

        // Cetak hasil Location by Id
        public static void LocationById(Location location, int id)
        {
            var getLocationById = location.GetById(id);
            if (getLocationById != null)
            {
                Console.WriteLine("Hasil yang ditemukan : ");
                Console.WriteLine($"Id: {getLocationById.Id}");
                Console.WriteLine($"Street Address: {getLocationById.StreetAddr}");
            }
            else
                Console.WriteLine("Hasil tidak ditemukan");

        }

        // Cetak hasil Insert Location
        public static void InsertLocation(Location Location, int id, string streetAddr, string postalCode, string city, string stateProvince, string countryId)
        {
            var insertResult = Location.Insert(id, streetAddr, postalCode, city, stateProvince, countryId);
            int.TryParse(insertResult, out int result);
            if (result > 0)
            {
                Console.WriteLine("Insert Success");
            }
            else
            {
                Console.WriteLine("Insert Failed");
                Console.WriteLine(insertResult);
            }
        }

        // Cetak hasil Update Location
        public static void UpdateLocation(Location location, int id, string streetAddr, string postalCode, string city, string stateProvince, string countryId)
        {
            var updateResult = location.Update(id, streetAddr, postalCode, city, stateProvince, countryId);

            Console.WriteLine(updateResult);
        }

        // Cetak hasil Delete Location
        public static void DeleteLocation(Location location, int id)
        {
            var deleteResult = location.Delete(id);

            Console.WriteLine(deleteResult);
        }


        // Cetak hasil semua Job
        public static void AllJobs(Job job)
        {
            var getAllJobs = job.GetAll();

            if (getAllJobs.Count > 0)
            {
                foreach (var j in getAllJobs)
                {
                    Console.WriteLine($"Id: {j.Id}, Title: {j.Title}, Min Salary: {j.MinSalary}, Max Salary: {j.MaxSalary}");
                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }

        // Cetak hasil Job by Id
        public static void JobById(Job job, int id)
        {
            var getJobById = job.GetById(id);
            if (getJobById != null)
            {
                Console.WriteLine("Hasil yang ditemukan : ");
                Console.WriteLine($"Id: {getJobById.Id}, Title: {getJobById.Title}, Min Salary: {getJobById.MinSalary}, Max Salary: {getJobById.MaxSalary}");
            }
            else
            {
                Console.WriteLine("Hasil tidak ditemukan");
            }
        }

        // Cetak hasil Insert Job
        public static void InsertJob(Job job, int id, string title, int minSalary, int maxSalary)
        {
            var insertResult = job.Insert(id, title, minSalary, maxSalary);
            int.TryParse(insertResult, out int result);
            if (result > 0)
            {
                Console.WriteLine("Insert Success");
            }
            else
            {
                Console.WriteLine("Insert Failed");
                Console.WriteLine(insertResult);
            }
        }

        // Cetak hasil Update Job
        public static void UpdateJob(Job job, int id, string title, int minSalary, int maxSalary)
        {
            var updateResult = job.Update(id, title, minSalary, maxSalary);

            Console.WriteLine(updateResult);
        }

        // Cetak hasil Delete Job
        public static void DeleteJob(Job job, int id)
        {
            var deleteResult = job.Delete(id);

            Console.WriteLine(deleteResult);
        }


        // Cetak hasil semua History
        public static void AllHistories(History history)
        {
            var getAllHistories = history.GetAll();

            if (getAllHistories.Count > 0)
            {
                foreach (var h in getAllHistories)
                {
                    Console.WriteLine($"Start Date: {h.StartDate}, Employee ID: {h.EmployeeId}, End Date: {h.EndDate}, Department ID: {h.DepartmentId}, Job ID: {h.JobId}");
                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }

        // Cetak hasil History by Employee ID
        public static void HistoryByEmployeeId(History history, int employeeId)
        {
            var getHistoryByEmployeeId = history.GetById(employeeId);
            if (getHistoryByEmployeeId != null)
            {
                Console.WriteLine("Hasil yang ditemukan : ");
                Console.WriteLine($"Start Date: {getHistoryByEmployeeId.StartDate}, Employee ID: {getHistoryByEmployeeId.EmployeeId}, End Date: {getHistoryByEmployeeId.EndDate}, Department ID: {getHistoryByEmployeeId.DepartmentId}, Job ID: {getHistoryByEmployeeId.JobId}");
            }
            else
            {
                Console.WriteLine("Hasil tidak ditemukan");
            }
        }

        // Cetak hasil Insert History
        public static void InsertHistory(History history, DateTime startDate, int employeeId, DateTime endDate, int departmentId, int jobId)
        {
            var insertResult = history.Insert(startDate, employeeId, endDate, departmentId, jobId);
            Console.WriteLine(insertResult);
        }

        // Cetak hasil Update History
        public static void UpdateHistory(History history, DateTime startDate, int employeeId, DateTime endDate, int departmentId, int jobId)
        {
            var updateResult = history.Update(startDate, employeeId, endDate, departmentId, jobId);
            Console.WriteLine(updateResult);
        }

        // Cetak hasil Delete History
        public static void DeleteHistory(History history, int employeeId)
        {
            var deleteResult = history.Delete(employeeId);
            Console.WriteLine(deleteResult);
        }


        // Cetak hasil semua Department
        public static void AllDepartments(Department department)
        {
            var getAllDepartments = department.GetAll();

            if (getAllDepartments.Count > 0)
            {
                foreach (var dept in getAllDepartments)
                {
                    Console.WriteLine($"Id: {dept.Id}, Name: {dept.Name}, Location Id: {dept.LocationId}, Manager Id: {dept.ManagerId}");
                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }

        // Cetak hasil Department by Id
        public static void DepartmentById(Department department, int id)
        {
            var getDepartmentById = department.GetById(id);
            if (getDepartmentById != null)
            {
                Console.WriteLine("Hasil yang ditemukan : ");
                Console.WriteLine($"Id: {getDepartmentById.Id}, Name: {getDepartmentById.Name}, Location Id: {getDepartmentById.LocationId}, Manager Id: {getDepartmentById.ManagerId}");
            }
            else
            {
                Console.WriteLine("Hasil tidak ditemukan");
            }
        }

        // Cetak hasil Insert Department
        public static void InsertDepartment(Department department, string name, int locationId, int managerId)
        {
            var insertResult = department.Insert(name, locationId, managerId);
            if (insertResult.Contains("Success"))
            {
                Console.WriteLine("Insert Success");
            }
            else
            {
                Console.WriteLine("Insert Failed");
                Console.WriteLine(insertResult);
            }
        }

        // Cetak hasil Update Department
        public static void UpdateDepartment(Department department, int id, string name, int locationId, int managerId)
        {
            var updateResult = department.Update(id, name, locationId, managerId);

            Console.WriteLine(updateResult);
        }

        // Cetak hasil Delete Department
        public static void DeleteDepartment(Department department, int id)
        {
            var deleteResult = department.Delete(id);

            Console.WriteLine(deleteResult);
        }



        // Cetak hasil semua Employee
        public static void AllEmployees(Employee employee)
        {
            var getAllEmployees = employee.GetAll();

            if (getAllEmployees.Count > 0)
            {
                foreach (var emp in getAllEmployees)
                {
                    Console.WriteLine($"Id: {emp.Id}, First Name: {emp.FirstName}, Last Name: {emp.LastName}, Email: {emp.Email}, Phone Number: {emp.PhoneNumber}, Hire Date: {emp.HireDate}, Salary: {emp.Salary}, Commission Pct: {emp.CommissionPct}, Manager Id: {emp.ManagerId}, Job Id: {emp.JobId}, Department Id: {emp.DepartmentId}");
                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }

        // Cetak hasil Employee by Id
        public static void EmployeeById(Employee employee, int id)
        {
            var getEmployeeById = employee.GetById(id);
            if (getEmployeeById != null)
            {
                Console.WriteLine("Hasil yang ditemukan : ");
                Console.WriteLine($"Id: {getEmployeeById.Id}, First Name: {getEmployeeById.FirstName}, Last Name: {getEmployeeById.LastName}, Email: {getEmployeeById.Email}, Phone Number: {getEmployeeById.PhoneNumber}, Hire Date: {getEmployeeById.HireDate}, Salary: {getEmployeeById.Salary}, Commission Pct: {getEmployeeById.CommissionPct}, Manager Id: {getEmployeeById.ManagerId}, Job Id: {getEmployeeById.JobId}, Department Id: {getEmployeeById.DepartmentId}");
            }
            else
            {
                Console.WriteLine("Hasil tidak ditemukan");
            }
        }

        // Cetak hasil Insert Employee
        public static void InsertEmployee(Employee employee, string firstName, string lastName, string email, string phoneNumber, DateTime hireDate, int salary, decimal commissionPct, int managerId, string jobId, int departmentId)
        {
            var insertResult = employee.Insert(new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                HireDate = hireDate,
                Salary = salary,
                CommissionPct = commissionPct,
                ManagerId = managerId,
                JobId = jobId,
                DepartmentId = departmentId
            });

            int.TryParse(insertResult, out int result);
            if (result > 0)
            {
                Console.WriteLine("Insert Success");
            }
            else
            {
                Console.WriteLine("Insert Failed");
                Console.WriteLine(insertResult);
            }
        }

        // Cetak hasil Update Employee
        public static void UpdateEmployee(Employee employee, int id, string firstName, string lastName, string email, string phoneNumber, DateTime hireDate, int salary, decimal commissionPct, int managerId, string jobId, int departmentId)
        {
            var updateResult = employee.Update(new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                HireDate = hireDate,
                Salary = salary,
                CommissionPct = commissionPct,
                ManagerId = managerId,
                JobId = jobId,
                DepartmentId = departmentId
            }, id);

            Console.WriteLine(updateResult);
        }

        // Cetak hasil Delete Employee
        public static void DeleteEmployee(Employee employee, int id)
        {
            var deleteResult = employee.Delete(id);

            Console.WriteLine(deleteResult);
        }

    }


}