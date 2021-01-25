using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Danh sách</returns>
        /// CreatedBy: HTTrang(13/01/2021)
        IEnumerable<TEntity> GetEntities();
        TEntity GetEntityById(Guid entityId);
        ServiceResult Add(TEntity entity);
        ServiceResult Update(TEntity cuentitystomer);
        ServiceResult Delete(Guid entityId);
        TEntity GetEntityByCode(string entityCode);
        IEnumerable<Customer> GetEmployeesFilter(string specs,Guid? departmentGroupId, Guid? positionGroupId);

    }
}
