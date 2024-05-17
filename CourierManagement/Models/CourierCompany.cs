using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Models
{
    internal class CourierCompany
    {
        string CompanyName { get; set; }
        List<Courier> CourierDetails { get; set; }
        List<Employee> EmployeeDetails { get; set; }
        List<Location> LocationDetails { get; set; }

        public CourierCompany(string companyName, List<Courier> courierDetails, List<Employee> employeeDetails, List<Location> locationDetails)
        {
            CompanyName = companyName;
            CourierDetails = courierDetails;
            EmployeeDetails = employeeDetails;
            LocationDetails = locationDetails;
        }
        public override string ToString()
        {
            return $"{CompanyName}, {CourierDetails.Count} couriers, {EmployeeDetails.Count} employees, {LocationDetails.Count} locations";
        }
    }
}
