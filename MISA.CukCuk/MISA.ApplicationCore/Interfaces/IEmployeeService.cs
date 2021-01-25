using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IEmployeeService:IBaseService<Employee>
    {
        Employee GetEmployeeByCode(string employeeCode);
        /// <summary>
        /// lấy dữ liệu danh sách nhân viên theo các tiêu chí
        /// </summary>
        /// <param name="specs">theo mã, tên hoặc số điện thoại của nhân viên</param>
        /// <param name="departmentGroupId">Id phòng ban</param>
        /// <param name="positionGroupId">Id vị trí</param>
        /// <returns>Danh sách nhân viên theo các tiêu chí</returns>
        /// CreatedBy: HTTrang(199/01/2021)
        List<Employee> GetEmployeesFilter(string specs, Guid? departmentGroupId, Guid? positionGroupId);
    }
}
