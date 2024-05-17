using CourierManagement.Models;
using CourierManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Services
{
    internal class AdminServices
    {
        public  void AdminService() 
        {
            ICourierAdminService admin = new CourierAdminServiceImpl();

            while(true)
            {
                Console.WriteLine("1.Add new staff");
                Console.Write("Select an Option: ");
                int inputOption = int.Parse(Console.ReadLine());
                switch (inputOption)
                {
                    case 1:
                        Console.Write("Enter the employee name: ");
                        string employeeName = Console.ReadLine();
                        Console.Write("Enter the  email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter the contact number: ");
                        string contactNumber = Console.ReadLine();
                        Console.Write("Enter the role: ");
                        string role = Console.ReadLine();
                        Console.Write("Enter the salary: ");
                        decimal salary = decimal.Parse(Console.ReadLine());


                        Employee emp = new Employee(null,employeeName, email, contactNumber, role, salary);
                        int empId = admin.AddCourierStaff(emp);
                        Console.WriteLine(empId);
                        break;
                }
                break;
            }
        }
    }
}
