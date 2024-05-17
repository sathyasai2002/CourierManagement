using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagement.Repository;
using CourierManagement.Services;

namespace CourierManagement
{
    internal class CourierManagementApp
    {
        AdminServices adminservices = new AdminServices();
        UserServices userservices = new UserServices(); 

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("WELCOME TO COURIER SYSTEM APPLICATION ");
                Console.WriteLine("1.Admin");
                Console.WriteLine("2.User");
                Console.WriteLine("3.Exit");
                Console.Write("Select an Option: ");
                int value = Convert.ToInt32(Console.ReadLine());

                switch (value)
                {
                    case 1:
                        adminservices.AdminService();
                        break;
                    case 2:
                        userservices.UserService(); 
                        break;
                }
                break;
            }

        }
    }
}
