using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class DepartmentGroupService : BaseService<DepartmentGroup>, IDepartmentGroupService
    {
        IBaseRepository<DepartmentGroup> _baseRepository;
        IDepartmentGroupRepository _departmentGroupRepository;

        public DepartmentGroupService(IBaseRepository<DepartmentGroup> baseRepository, IDepartmentGroupRepository departmentGroupRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _departmentGroupRepository = departmentGroupRepository;
        }
    }
}
