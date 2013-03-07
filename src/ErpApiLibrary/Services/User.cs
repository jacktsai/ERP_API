using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.Data;

namespace ErpApi.Services
{
    /// <summary>
    /// 操作者個人資料。
    /// </summary>
    public class User
    {
        /// <summary>
        /// 操作者資料。
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
        /// 取得 ID。
        /// </summary>
        public int Id
        {
            get { return this._data.Id; }
        }

        /// <summary>
        /// 取得姓名。
        /// </summary>
        public string Name
        {
            get { return this._data.Name; }
        }

        /// <summary>
        /// 取得中文姓名。
        /// </summary>
        public string FullName
        {
            get { return this._data.FullName; }
        }

        /// <summary>
        /// 取得部門。
        /// </summary>
        public string Department
        {
            get { return this._data.Department; }
        }

        /// <summary>
        /// 取得操作等級。
        /// </summary>
        public int Degree
        {
            get { return this._data.Degree; }
        }

        /// <summary>
        /// 取得電子郵件位址。
        /// </summary>
        public string Email
        {
            get { return this._data.Email; }
        }

        /// <summary>
        /// 取得首頁。
        /// </summary>
        public string Homepage
        {
            get { return this._data.Homepage; }
        }

        /// <summary>
        /// 取得分機號碼。
        /// </summary>
        public string ExtNumber
        {
            get { return this._data.ExtNumber; }
        }

        /// <summary>
        /// 取得 Backyard ID。
        /// </summary>
        public string BackyardId
        {
            get { return this._data.BackyardId; }
        }
    }
}
