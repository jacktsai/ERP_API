using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using ErpApi.Data;
using ErpApi.Data.Common;

namespace ErpApi.ApiControllers
{
    /// <summary>
    /// 子站。
    /// </summary>
    public class SubCategoryController : ApiController
    {
        private IDaoFactory factory;

        public SubCategoryController()
        {
            // TODO: 有多餘的時間再將 dependency 抽出
            this.factory = new CommonDaoFactory();
        }

        #region class of SubCategoryContact

        public class SubCategoryContact
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

            public SubCategoryContact()
            {
            }

            public SubCategoryContact(ISubCategory subCategory)
            {
                this.SubCategoryId = subCategory.Id;

                if (subCategory.User != null)
                {
                    this.UserBackyardId = subCategory.User.BackyardId;
                    this.UserFullName = subCategory.User.FullName;
                    this.UserExtNo = subCategory.User.ExtNumber;
                    this.UserEmail = subCategory.User.Email;
                }

                if (subCategory.Manager != null)
                {
                    this.MgrBackyardId = subCategory.Manager.BackyardId;
                    this.MgrFullName = subCategory.Manager.FullName;
                    this.MgrExtNo = subCategory.Manager.ExtNumber;
                    this.MgrEmail = subCategory.Manager.Email;
                }

                if (subCategory.Purchaser != null)
                {
                    this.PhrBackyardId = subCategory.Purchaser.BackyardId;
                    this.PhrFullName = subCategory.Purchaser.FullName;
                    this.PhrExtNo = subCategory.Purchaser.ExtNumber;
                    this.PhrEmail = subCategory.Purchaser.Email;
                }

                if (subCategory.Staff != null)
                {
                    this.StaffBackyardId = subCategory.Staff.BackyardId;
                    this.StaffFullName = subCategory.Staff.FullName;
                    this.StaffExtNo = subCategory.Staff.ExtNumber;
                    this.StaffEmail = subCategory.Staff.Email;
                }
            }
        }

        #endregion

        #region GetContact

        [DataContract]
        public class GetContactRequest
        {
            [DataMember(IsRequired = true), Required]
            public int? SubCategoryId { get; set; }
        }

        public class GetContactResponse : SubCategoryContact
        {
            public GetContactResponse(ISubCategory subCategory)
                : base(subCategory)
            {
            }
        }

        [HttpPost]
        public GetContactResponse GetContact([FromBody]GetContactRequest request)
        {
            ISubCategory subCategory = new DefaultSubCategory(this.factory, request.SubCategoryId.Value);

            var response = new GetContactResponse(subCategory);

            return response;
        }

        #endregion

        #region GetManyContact

        [DataContract]
        public class GetManyContactRequest
        {
            [DataMember(IsRequired = true), Required]
            public int[] SubCategoryIds { get; set; }
        }

        public class GetManyContactResponse
        {
            public SubCategoryContact[] Contacts;
        }

        [HttpPost]
        public GetManyContactResponse GetManyContact([FromBody]GetManyContactRequest request)
        {
            IList<SubCategoryContact> contacts = new List<SubCategoryContact>(request.SubCategoryIds.Length);

            foreach (var id in request.SubCategoryIds)
            {
                ISubCategory subCategory = new DefaultSubCategory(this.factory, id);
                var contact = new SubCategoryContact(subCategory);
                contacts.Add(contact);
            }

            var response = new GetManyContactResponse
            {
                Contacts = contacts.ToArray()
            };

            return response;
        }

        #endregion
    }
}
