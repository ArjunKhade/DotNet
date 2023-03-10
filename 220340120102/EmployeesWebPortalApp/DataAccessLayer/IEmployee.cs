using EmployeesWebPortalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesWebPortalApp.DataAccessLayer
{
    interface IEmployee
    {
        bool AddEmployee(Employee obj);
        List<Employee> GetAllEmployees();

        bool UpdateEmployee(Employee obj);

        bool DeleteEmployee(int Id);


    }
}
