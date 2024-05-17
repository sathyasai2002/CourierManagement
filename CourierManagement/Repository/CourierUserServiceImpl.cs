using CourierManagement.Exceptions;
using CourierManagement.Models;
using CourierManagement.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Repository
{
    internal class CourierUserServiceImpl : ICourierUserService
    {





        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;


        public CourierUserServiceImpl()
        {
            //sqlConnection = new SqlConnection("Server=LAPTOP-GS6FUN4H;Database=couriermanagement;Trusted_Connection=True");
            cmd = new SqlCommand();
            sqlConnection = new SqlConnection(DbUtil.GetConnectionString());
        }

        public int PlaceOrder(Courier courier)
        {
            try
            {
                sqlConnection.Open();
                cmd.CommandText = "Insert into Courier values(@userId,@SenderName,@SenderAddress,@ReceiverName,@ReceiverAddress,@employeeId,@serviceId,@Weight,@Status,@TrackingNumber,@DeliveryDate)";
                //cmd.Parameters.AddWithValue("@CourierID", courier.CourierID);
                cmd.Parameters.AddWithValue("@SenderName", courier.SenderName);
                cmd.Parameters.AddWithValue("@userId", courier.UserID);
                cmd.Parameters.AddWithValue("@SenderAddress", courier.SenderAddress);
                cmd.Parameters.AddWithValue("@ReceiverName", courier.ReceiverName);
                cmd.Parameters.AddWithValue("@ReceiverAddress", courier.ReceiverAddress);
                cmd.Parameters.AddWithValue("@employeeId", courier.EmployeeID);
                cmd.Parameters.AddWithValue("@serviceId", courier.ServiceID);
                cmd.Parameters.AddWithValue("@Weight", courier.Weight);
                cmd.Parameters.AddWithValue("@Status", courier.Status);
                cmd.Parameters.AddWithValue("@TrackingNumber", Convert.ToString(courier.TrackingNumber));
                cmd.Parameters.AddWithValue("@DeliveryDate", courier.DeliveryDate);
                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
                return courier.TrackingNumber;
            }
            catch (Exception ex)
            {
                throw new Exception("Error placing order: " + ex.Message);
            }
            finally
            {

                sqlConnection.Close();

            }
        }



        public string GetOrderStatus(int TrackingNumber)
        {
            return GetOrderStatusFromDatabase(TrackingNumber);
        }

        private string GetOrderStatusFromDatabase(int trackingNumber)
        {
            string status = "";

            try
            {
                sqlConnection.Open();
                cmd.CommandText = "SELECT Status FROM Courier WHERE TrackingNumber = @TrackingNumber";
                cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);
                cmd.Connection = sqlConnection;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    status = reader["Status"].ToString();
                }

                reader.Close();
                Console.WriteLine(status);
            }
            catch (InvalidDataException Iex)
            {
                Console.WriteLine("Invalid" + Iex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return null;

        }

        public bool CancelOrder(int TrackingNumber)
        {
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.CommandText = "delete from courier where trackingNumber=@trackingNumber";
            cmd.Parameters.AddWithValue("@trackingNumber", TrackingNumber);
            int status = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return status > 0;
        }



        public List<Courier> GetAssignedOrders(int courierStaffId)
        {
            sqlConnection.Open();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "SELECT CourierId,EmployeeId FROM Courier WHERE employeeId  = @EmployeeID";
            cmd.Parameters.AddWithValue("@EmployeeID", courierStaffId);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Courier> couriers = new List<Courier>();


            while (reader.Read())
            {
                Courier courier = new Courier();
                courier.CourierID = (int)reader["CourierId"];
                courier.EmployeeID = (int)reader["EmployeeId"];
                Console.WriteLine(courier.CourierID + " " + courier.EmployeeID);
                couriers.Add(courier);
            }

            reader.Close();
            sqlConnection.Close();
            return couriers;
        }
    }

}
