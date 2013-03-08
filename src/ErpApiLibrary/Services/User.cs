using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.Data;

namespace ErpApi.Services
{
    /// <summary>
    /// 使用者資訊。
    /// </summary>
    public class User
    {
        /// <summary>
        /// 使用者資料。
        /// </summary>
        private readonly UserData _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        internal User(UserData data)
        {
            this._data = data;
        }

        /// <summary>
        /// 使用者序號。
        /// </summary>
        public int Id
        {
            get { return this._data.Id; }
        }

        /// <summary>
        /// 帳號。
        /// </summary>
        public string Name
        {
            get { return this._data.Name; }
        }

        /// <summary>
        /// 姓名。
        /// </summary>
        public string FullName
        {
            get { return this._data.FullName; }
        }

        /// <summary>
        /// 部門。
        /// </summary>
        public string Department
        {
            get { return this._data.Department; }
        }

        /// <summary>
        /// 等級。
        /// </summary>
        public int Degree
        {
            get { return this._data.Degree; }
        }

        /// <summary>
        /// Email。
        /// </summary>
        public string Email
        {
            get { return this._data.Email; }
        }

        /// <summary>
        /// 首頁。
        /// </summary>
        public string Homepage
        {
            get { return this._data.Homepage; }
        }

        /// <summary>
        /// 分機。
        /// </summary>
        public string ExtNumber
        {
            get { return this._data.ExtNumber; }
        }

        /// <summary>
        /// Backyard ID。
        /// </summary>
        public string BackyardId
        {
            get { return this._data.BackyardId; }
        }
    }
}
