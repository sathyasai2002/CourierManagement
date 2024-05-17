using CourierManagement.Models;
using CourierManagement.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Repository
{
    internal interface ICourierUserService
    {
        public int PlaceOrder(Courier courier);
        public string GetOrderStatus(int TrackingNumber);
        public bool CancelOrder(int TrackingNumber);
        public List<Courier> GetAssignedOrders(int courierStaffId);

    }
}
