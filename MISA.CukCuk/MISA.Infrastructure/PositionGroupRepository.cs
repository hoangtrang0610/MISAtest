using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure
{
    public class PositionGroupRepository: BaseReponsitory<PositionGroup>, IPositionGroupRepository
    {
        public PositionGroupRepository(IConfiguration configuration) : base(configuration)
        {

        }

    }
}
