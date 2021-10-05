using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApIAngular.model;

namespace WebApIAngular.respository
{
    public interface IEmployee
    {
        Employees CreateEmployee(Employees emp);
        Employees UpdateEmployee(Employees emp);
        List<Employees> GetEmployees();
        Employees GetEmployeeById(int id);
        Employees DeleteEmployee(int id);
    }
}
