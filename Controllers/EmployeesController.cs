using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APIAsistencia.Models;

namespace APIAsistencia.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly List<Employee> _employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "John Smith", Email = "john.smith@example.com", Department = "IT" },
        new Employee { Id = 2, Name = "Jane Doe", Email = "jane.doe@example.com", Department = "HR" },
        new Employee { Id = 3, Name = "Bob Johnson", Email = "bob.johnson@example.com", Department = "Finance" }
    };

        // GET: api/employees
        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        // GET: api/employees/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
    }
}
