using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApIAngular.model;

namespace WebApIAngular.respository
{
    public class EmployeeService : IEmployee
    {
        private ApplicationContext context;
        public EmployeeService()
        {
            context = new ApplicationContext();
        }
        public Employees CreateEmployee(Employees emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();
            return emp;
        }

        public Employees DeleteEmployee(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.Id == id);
            if (emp != null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();
                return emp;
            }
            else
            {
                return null;
            }
        }

        public Employees GetEmployeeById(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.Id == id);
            return emp;
        }

        public List<Employees> GetEmployees()
        {
            return context.Employees.ToList();
        }

        public Employees UpdateEmployee(Employees emp)
        {
            context.Employees.Update(emp);
            context.SaveChanges();
            return emp;
        }
    }
}
