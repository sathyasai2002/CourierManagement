using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Models
{
    internal class Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        public Users()
        {
        }
        public Users(int userID, string userName, string email, string password, string contactNumber, string address)
        {
            UserID = userID;
            UserName = userName;
            Email = email;
            Password = password;
            ContactNumber = contactNumber;
            Address = address;
        }

        

        public override string ToString()
        {
            return $"{UserID}, {UserName}, {Email}, {ContactNumber}, {Address}";
        }
    }

}
