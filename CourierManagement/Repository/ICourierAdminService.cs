using CourierManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.Repository
{
    internal interface ICourierAdminService
    {
        int AddCourierStaff(Employee obj);
    }
}
