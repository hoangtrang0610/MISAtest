using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    public class EmployeesController : BaseEntityController<Employee>
    {
        IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("filter")]
        public IActionResult GetEmployeeFilter([FromQuery] string specs, [FromQuery] Guid? departmentGroupId,[FromQuery]Guid? positionGroupId)
        {
            return Ok(_employeeService.GetEmployeesFilter(specs, departmentGroupId, positionGroupId));
        }
    }
}
