using CourierManagement.Models;
using CourierManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Services
{
    internal class UserServices
    {
        public void UserService() 
        {

            ICourierUserService courierUserService = new CourierUserServiceImpl();

            while (true)
            {
                Console.WriteLine("1.Place order");
                Console.WriteLine("2.Get order status");
                Console.WriteLine("3.Cancel order");
                Console.WriteLine("4.Get assigned order for a particular employee");
                Console.Write("Select an Option: ");
                int methodOption = Convert.ToInt32(Console.ReadLine());
                switch (methodOption)
                {
                    case 1:
                        Console.Write("Enter the sender name: ");
                        string senderName = Console.ReadLine();
                        Console.Write("Enter the  sender address: ");
                        string senderAddress = Console.ReadLine();
                        Console.Write("Enter the receiver name: ");
                        string receiverName = Console.ReadLine();
                        Console.Write("Enter the receiver address: ");
                        string receiverAddress = Console.ReadLine();
                        Console.Write("Enter the weight: ");
                        decimal weight = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter the status: ");
                        string status = Console.ReadLine();
                        Console.Write("Enter the delivery date: ");
                        DateTime deliveryDate = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Enter the user id: ");
                        int userId = int.Parse(Console.ReadLine());
                        Console.Write("Enter the employee id: ");
                        int employeeId = int.Parse(Console.ReadLine());
                        Console.Write("Enter the service id: ");
                        int serviceId = int.Parse(Console.ReadLine());

                        Courier newOrder = new Courier(null,senderName,userId, senderAddress,receiverName,receiverAddress,employeeId,serviceId,weight,status,deliveryDate);

                        int trackingNumber = courierUserService.PlaceOrder(newOrder);

                        if (trackingNumber > 0)
                        {
                            Console.WriteLine($"Placed the order Successfully, Your tracking number is{trackingNumber}");
                        }
                        else
                        {
                            Console.WriteLine("Failed to place the order");
                        }
                            break;

                    case 2:
                           Console.WriteLine("Enter the tracking number:");
                           int TrackingNumber = int.Parse(Console.ReadLine());
                           string orderStatus = courierUserService.GetOrderStatus(TrackingNumber);
                           Console.WriteLine($"Your order status:{orderStatus}");
                            break;
                    case 3:
                            Console.WriteLine("Enter the tracking number:");
                            int _TrackingNumber = int.Parse(Console.ReadLine());
                            bool _status = courierUserService.CancelOrder(_TrackingNumber);
                            Console.WriteLine($"Your order status:{_status}");
                            break;
                    case 4:
                            Console.WriteLine("Enter the staff id:");
                            int staffId = int.Parse(Console.ReadLine());
                            List<Courier> couriers = courierUserService.GetAssignedOrders(staffId);

                            if (couriers.Count > 0)
                            {
                                foreach (Courier c in couriers)
                                {
                                    Console.WriteLine(c.CourierID + " " + c.EmployeeID );
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no order assigned to this staff");
                            }
                            break;
                }
                break;
            }
        }
    }
}
