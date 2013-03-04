using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yahoo.Business;
using Yahoo.Business.Defaults;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Yahoo.Controllers
{
    public class CategoryController : ApiController
    {
        private IBusinessFactory factory;

        public CategoryController()
        {
            // TODO: 有多餘的時間再將 dependency 抽出
            this.factory = new DefaultBusinessFactory();
        }

        [HttpGet]
        public string Test(string test)
        {
            return test;
        }

        #region GetContacts

        [DataContract]
        public class GetContactsRequest
        {
            [DataMember(IsRequired = true), Required]
            public int? SubCategoryId { get; set; }
        }

        public class GetContactsResponse
        {
            public int SubCategoryId;

            public string UserBackyardId;
            public string UserFullName;
            public string UserExtNo;
            public string UserEmail;

            public string MgrBackyardId;
            public string MgrFullName;
            public string MgrExtNo;
            public string MgrEmail;

            public string PhrBackyardId;
            public string PhrFullName;
            public string PhrExtNo;
            public string PhrEmail;

            public string StaffBackyardId;
            public string StaffFullName;
            public string StaffExtNo;
            public string StaffEmail;
        }

        [HttpPost]
        public GetContactsResponse GetContacts(GetContactsRequest request)
        {
            ISubCategory cat = new DefaultSubCategory(this.factory, request.SubCategoryId.Value);

            var r = new GetContactsResponse
            {
                SubCategoryId = cat.Id
            };

            if (cat.User != null)
            {
                r.UserBackyardId = cat.User.BackyardId;
                r.UserFullName = cat.User.FullName;
                r.UserExtNo = cat.User.ExtNumber;
                r.UserEmail = cat.User.Email;
            }

            if (cat.Manager != null)
            {
                r.MgrBackyardId = cat.Manager.BackyardId;
                r.MgrFullName = cat.Manager.FullName;
                r.MgrExtNo = cat.Manager.ExtNumber;
                r.MgrEmail = cat.Manager.Email;
            }

            if (cat.Purchaser != null)
            {
                r.PhrBackyardId = cat.Purchaser.BackyardId;
                r.PhrFullName = cat.Purchaser.FullName;
                r.PhrExtNo = cat.Purchaser.ExtNumber;
                r.PhrEmail = cat.Purchaser.Email;
            }

            if (cat.Staff != null)
            {
                r.StaffBackyardId = cat.Staff.BackyardId;
                r.StaffFullName = cat.Staff.FullName;
                r.StaffExtNo = cat.Staff.ExtNumber;
                r.StaffEmail = cat.Staff.Email;
            }

            return r;
        }

        #endregion
    }
}
