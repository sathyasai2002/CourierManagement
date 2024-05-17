using CourierManagement.Models;
using CourierManagement.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Repository
{
    internal class CourierAdminServiceImpl : ICourierAdminService
    {


        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;


        public CourierAdminServiceImpl()
        {
            //sqlConnection = new SqlConnection("Server=LAPTOP-GS6FUN4H;Database=couriermanagement;Trusted_Connection=True");
            cmd = new SqlCommand();
            sqlConnection = new SqlConnection(DbUtil.GetConnectionString());

        }

        /*
        public int AddCourierStaff(Employee obj)
        {
            sqlConnection.Open();
            cmd.CommandText = "Insert into Employee values(@EmployeeID,@Name,@Email,@ContactNumber,@Role,@Salary)";
            cmd.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
            cmd.Parameters.AddWithValue("@Name", obj.EmployeeName);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@ContactNumber", obj.ContactNumber);
            cmd.Parameters.AddWithValue("@Role", obj.Role);
            cmd.Parameters.AddWithValue("@Salary", obj.Salary);
            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();
            return obj.EmployeeID;
        }
        */

        public int AddCourierStaff(Employee obj)
        {
                int empid ;
               sqlConnection.Open();

                cmd.CommandText = "Insert into Employee OUTPUT INSERTED.EmployeeID values(@Name,@Email,@ContactNumber,@Role,@Salary)";
                cmd.Parameters.AddWithValue("@Name", obj.EmployeeName);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@ContactNumber", obj.ContactNumber);
                cmd.Parameters.AddWithValue("@Role", obj.Role);
                cmd.Parameters.AddWithValue("@Salary", obj.Salary);
                cmd.Connection = sqlConnection;
                empid = (int)cmd.ExecuteScalar();
                return empid;
                sqlConnection.Close();
            
        }

        
        

    }
}
