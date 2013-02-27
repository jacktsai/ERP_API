using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.DataAccess;

namespace Yahoo.Business
{
    /// <summary>
    /// 使用者權限資料。
    /// </summary>
    public class Authority
    {
        private readonly AuthorityData data;

        public Authority()
        {
            data = new AuthorityData();
        }

        internal Authority(AuthorityData data)
        {
            this.data = data;
        }

        public int SystemId
        {
            get { return this.data.SystemId; }
            set { this.data.SystemId = value; }
        }

        public string SystemName
        {
            get { return this.data.SystemName; }
            set { this.data.SystemName = value; }
        }

        public int CategoryId
        {
            get { return this.data.CategoryId; }
            set { this.data.CategoryId = value; }
        }

        public string CategoryName
        {
            get { return this.data.CategoryName; }
            set { this.data.CategoryName = value; }
        }

        public int SubCategoryId
        {
            get { return this.data.SubCategoryId; }
            set { this.data.SubCategoryId = value; }
        }

        public string SubCategoryName
        {
            get { return this.data.SubCategoryName; }
            set { this.data.SubCategoryName = value; }
        }

        public string Url
        {
            get { return this.data.Url; }
            set { this.data.Url = value; }
        }
    }
}
