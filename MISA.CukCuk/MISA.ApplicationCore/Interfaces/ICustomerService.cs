using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface ICustomerService:IBaseService<Customer>
    {
        /// <summary>
        /// lấy dữ liệu phân trang
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        /// CreatedBy: HTTrang(14/01/2021)
        IEnumerable<Customer> GetCustomerPaging(int limit, int offset);

        /// <summary>
        /// Lấy danh sách khách hàng theo nhóm khách hàng
        /// </summary>
        /// <param name="groupId">Id nhóm khách hàng</param>
        /// <returns></returns>
        /// CreatedBy: HTTrang(14/01/2021)
        IEnumerable<Customer> GetCustomersByGroup(Guid groupId);
    }
}
