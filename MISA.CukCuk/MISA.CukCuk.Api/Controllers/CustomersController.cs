using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enums;

namespace MISA.CukCuk.Api.Controllers
{
    public class CustomerController: BaseEntityController<Customer>
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService):base(customerService)
        {
            _customerService = customerService;
        }
    }

}

