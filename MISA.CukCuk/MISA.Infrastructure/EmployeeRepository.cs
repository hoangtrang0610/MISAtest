using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    public class EmployeeRepository :BaseReponsitory<Employee>, IEmployeeRepository
    {
    
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public Customer GetEmployeeByCode(string employeeCode)
        {
            var customerDuplicate = _dbConnection.Query<Customer>($"select * from employee where EmployeeCode = '{employeeCode}'", commandType: CommandType.Text).FirstOrDefault();
            return customerDuplicate;
        }

        public List<Employee> GetEmployeesFilter(string specs, Guid? departmentGroupId, Guid? positionGroupId)
        {
            var input = specs != null ? specs : string.Empty;
            //built tham số đầu vào cho store:
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeCode", input, DbType.String);
            parameters.Add("@FullName", input, DbType.String);
            parameters.Add("@PhoneNumber", input, DbType.String);
            parameters.Add("@DepartmentGroupId", departmentGroupId, DbType.String);
            parameters.Add("@PositionGroupId", positionGroupId, DbType.String);
            var employees = _dbConnection.Query<Employee>("Proc_GetEmployeePaging", parameters, commandType: CommandType.StoredProcedure).ToList();
            return employees;
        }

        Employee IEmployeeRepository.GetEmployeeByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }
    }
}
