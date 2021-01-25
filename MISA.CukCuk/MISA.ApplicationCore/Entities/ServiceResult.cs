
using MISA.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    public class ServiceResult
    {
        #region declare

        #endregion
        #region Constructor

        #endregion

        #region Property
        public object Data { get; set; }
        public string Messenger { get; set; }

        public MISACode MISACode { get; set; }
        #endregion
    }
}
