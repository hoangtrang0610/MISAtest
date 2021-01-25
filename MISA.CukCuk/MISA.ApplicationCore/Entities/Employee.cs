using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Thông tin nhân viên
    /// </summary>
    /// CreatedBy: HTTrang(14/01/2020)
    public class Employee : BaseEntity
    {
        #region declare

        #endregion
        #region Constructor

        #endregion

        #region Property

        /// <summary>
        ///Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Requied]
        [CheckDupplicate]
        [DisplayName("Mã nhân viên")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ tên nhân viên
        /// </summary>
        [Requied]
        [DisplayName("Họ và tên")]
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Số CMND/ Căn cước
        /// </summary>
        [Requied]
        [DisplayName("Số CMND")]
        [CheckDupplicate]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Requied]
        [DisplayName("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Requied]
        [DisplayName("Số điện thoại")]
        [CheckDupplicate]
        [MaxLength(13, "Số điện thoại không quá 13 ký tự")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Khóa ngoại(vị trí làm việc)
        /// </summary>
        public Guid? PositionGroupId { get; set; }

        /// <summary>
        /// Tên vị trí làm việc
        /// </summary>
        public string PositionGroupName { get; set; }

        /// <summary>
        /// khóa ngoại(phòng ban)
        /// </summary>
        public Guid? DepartmentGroupId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentGroupName { get; set; }

        /// <summary>
        /// Mã thuế cá nhân
        /// </summary>

        public string PersonalTaxCode { get; set; }

        /// <summary>
        /// Mức lương cơ bản
        /// </summary>
        public double? Salary { get; set; }

        /// <summary>
        /// Ngày gia nhập
        /// </summary>
        public DateTime? JoinDate { get; set; }

        /// <summary>
        /// Trạng thái làm việc
        /// </summary>
        public int? WorkStatusName { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
