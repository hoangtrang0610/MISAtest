using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class PositionGroupService : BaseService<PositionGroup>, IPositionGroupService
    {
        IBaseRepository<PositionGroup> _baseRepository;
        IPositionGroupRepository _positiontGroupRepository;

        public PositionGroupService(IBaseRepository<PositionGroup> baseRepository, IPositionGroupRepository positiontGroupRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _positiontGroupRepository = positiontGroupRepository;
        }
    }
}
