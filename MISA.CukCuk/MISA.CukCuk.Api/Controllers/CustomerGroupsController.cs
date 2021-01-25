using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    public class CustomerGroupsController : BaseEntityController<CustomerGroup>
    {
        IBaseService<CustomerGroup> _baseService;

        public CustomerGroupsController(IBaseService<CustomerGroup> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
