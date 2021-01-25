using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enums;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class CustomerService:BaseService<Customer>, ICustomerService
    {
        IBaseRepository<Customer> _baseRepository;
        ICustomerRepository _customerRepository;
        #region Constructor
        public CustomerService(IBaseRepository<Customer> baseRepository, ICustomerRepository customerRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _customerRepository = customerRepository;
        }

        protected override bool ValidateCustomer(Customer entity)
        {
            return true;
        }
        

        public IEnumerable<Customer> GetCustomerPaging(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomersByGroup(Guid departmantId)
        {
            throw new NotImplementedException();
        }
        //Sửa thông tin khách hàng

        //Xóa khách hàng
        #endregion
    }
}
