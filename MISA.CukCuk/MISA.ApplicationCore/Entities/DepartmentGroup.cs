using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    public class DepartmentGroup : BaseEntity
    {
        /// <summary>
        /// Phòng ban
        /// </summary>
        /// CreatedBy HTTrrang(20/01/2021) 
        #region declare

        #endregion
        #region Constructor

        #endregion

        #region Property

        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid DepartmentGroupId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentGroupName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime? ModefiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModefiedBy { get; set; }
        #endregion
    }
}
