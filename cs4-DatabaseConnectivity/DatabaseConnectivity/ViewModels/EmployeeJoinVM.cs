namespace DatabaseConnectivity
{
    public class EmployeeJoinVM
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }
        public string DepartmentName { get; set; }
        public string StreetAddress { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }

        public override string ToString()
        {
            return $"{EmployeeId} | {FullName} | {Email} | {PhoneNumber} | {Salary} | {DepartmentName} | {StreetAddress} | {CountryName} | {RegionName}";
        }
    }
}
