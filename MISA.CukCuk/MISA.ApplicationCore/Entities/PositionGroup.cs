using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{

    /// <summary>
    /// Vị trí làm việc
    /// </summary>
    /// CreatedBy HTTrrang(20/01/2021) 
    public class PositionGroup:BaseEntity
    {

        #region declare

        #endregion
        #region Constructor

        #endregion

        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid PositionGroupId { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string PositionGroupName { get; set; }

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
