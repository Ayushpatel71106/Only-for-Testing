using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApIAngular.model;
using WebApIAngular.respository;

namespace WebApIAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        // GET: api/Employee
        private IEmployee employeeService;

        public EmployeeController(IEmployee _employee)
        {
            employeeService = _employee;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(employeeService.GetEmployees());
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(employeeService.GetEmployeeById(id));
        }

        // POST: api/Employee
        [HttpPost]
        public void Post([FromBody] Employees emps )
        {
            employeeService.CreateEmployee(emps);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public void Put(Employees emps)
        {
            employeeService.UpdateEmployee(emps);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            employeeService.DeleteEmployee(id);
        }
    }
}
