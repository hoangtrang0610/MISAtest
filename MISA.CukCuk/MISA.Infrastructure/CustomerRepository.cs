using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MISA.Infrastructure
{
    public class CustomerRepository :BaseReponsitory<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public Customer GetCustomerByCode(string customerCode)
        {
            var customerDuplicate = _dbConnection.Query<Customer>($"select * from customer where CustomerCode = '{customerCode}'", commandType: CommandType.Text).FirstOrDefault();
            return customerDuplicate;
        }
    }
}
