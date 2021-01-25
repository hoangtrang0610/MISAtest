using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
   public  class DepartmentGroupRepository : BaseReponsitory<DepartmentGroup>, IDepartmentGroupRepository
    {
        public DepartmentGroupRepository(IConfiguration configuration) : base(configuration)
        {

        }
        //public Customer GetDepartmentGroupname(string departmentGroupname)
        //{
        //    var department = _dbConnection.Query<DepartmentGroup>($"Pro_Get{_tableName}GroupName", commandType: CommandType.StoredProcedure).FirstOrDefault();
        //    return department;
        //}
    }
}
