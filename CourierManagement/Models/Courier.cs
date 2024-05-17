using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Models
{
    internal class Courier
    {
        public int? CourierID { get; set; }
        public int UserID { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public int EmployeeID { get; set; }
        public int ServiceID { get; set; }
        public decimal Weight { get; set; }
        public string Status { get; set; }
        public static int nextTrackingNumber  = 3000;
        public int TrackingNumber { get; set; } 

        public DateTime DeliveryDate { get; set; }
        

        public Courier(int? courierID, string senderName,int userId, string senderAddress, string receiverName, string receiverAddress,int employeeId,int serviceId,
                      decimal weight, string status, DateTime deliveryDate)
        {
            CourierID = courierID;
            SenderName = senderName;
            UserID = userId;
            SenderAddress = senderAddress;
            ReceiverName = receiverName;
            ReceiverAddress = receiverAddress;
            EmployeeID = employeeId;
            ServiceID =serviceId;
            Weight = weight;
            Status = status;
            TrackingNumber = nextTrackingNumber++;
            DeliveryDate = deliveryDate;
            
        }

        public Courier()
        {
        }

        public override string ToString()
        {
            return $"{CourierID}, {SenderName},{UserID},{SenderAddress},{ReceiverName},{ReceiverAddress},{EmployeeID},{ServiceID}, {Status}, {TrackingNumber}, {DeliveryDate}";
        }
    }
}
