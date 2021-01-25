
using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface danh mục khách hàng
    /// </summary>
    /// CreatedBy: HTTrang(13/01/2021)
    
    public interface ICustomerRepository:IBaseRepository<Customer>
    {
        /// <summary>
        /// Lấy thông tin khách hàng theo mã khách hàng
        /// </summary>
        /// <returns>Dánh sách khách hàng</returns>
        /// CreatedBy: HTTrang(13/01/2021)
      
        Customer GetCustomerByCode(string customerCode);
    }
}
