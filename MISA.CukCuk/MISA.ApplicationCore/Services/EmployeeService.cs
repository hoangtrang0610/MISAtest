using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService( IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //public Employee GetEmployeeByCode(string employeeCode)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Employee> GetEmployeesFilter(string specs, Guid? departmentGroupId, Guid? positionGroupId)
        //{
        //    return _employeeRepository.GetEmployeesFilter(specs, departmentGroupId, positionGroupId);
        //}

        Employee IEmployeeService.GetEmployeeByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        List<Employee> IEmployeeService.GetEmployeesFilter(string specs, Guid? departmentGroupId, Guid? positionGroupId)
        {
            return _employeeRepository.GetEmployeesFilter(specs, departmentGroupId, positionGroupId);
        }
    }
}
