using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Yahoo.Services;
using Yahoo.Services.Defaults;
using Yahoo.Data;
using Yahoo.Data.Common;

namespace Yahoo.Controllers
{
    public class UserController : ApiController
    {
        private IDaoFactory factory;

        public UserController()
        {
            // TODO: 有多餘的時間再將 dependency 抽出
            this.factory = new CommonDaoFactory();
        }

        [HttpGet]
        public string Test(string test)
        {
            return test;
        }

        #region GetProfile
        
        [DataContract]
        public class GetProfileRequest
        {
            [DataMember(IsRequired = true), Required]
            public string BackyardId { get; set; }
        }

        public class GetProfileResponse
        {
            public int Id;
            public string Name;
            public string FullName;
            public string Department;
            public int Degree;
            public string Homepage;
            public string ExtensionNumber;
            public string BackyardID;
            public string SubCatIds;
        }

        [HttpPost]
        public GetProfileResponse GetProfile(GetProfileRequest request)
        {
            IUser user = new DefaultUser(this.factory, backyardId: request.BackyardId);

            return new GetProfileResponse
            {
                Id = user.Id,
                Name = user.Name,
                FullName = user.FullName,
                Department = user.Department,
                Degree = user.Degree,
                Homepage = user.Homepage,
                ExtensionNumber = user.ExtNumber,
                BackyardID = user.BackyardId,
                SubCatIds = string.Join(",", user.Category.Select(o => o.Id)),
            };
        }

        #endregion

        #region GetAuthority
        
        [DataContract]
        public class GetAuthorityRequest
        {
            [DataMember(IsRequired = true), Required]
            public string BackyardId { get; set; }

            [DataMember]
            public int? UserId { get; set; }

            [DataMember(IsRequired = true), Required]
            public string Url { get; set; }
        }

        public class GetAuthorityResponse
        {
            public string BackyardId;
            public string Url;
            public bool CanSelect;
            public bool CanInsert;
            public bool CanUpdate;
            public bool CanDelete;
            public bool CanParticular;
        }

        [HttpPost]
        public GetAuthorityResponse GetAuthority(GetAuthorityRequest request)
        {
            IUser user;
            if (request.UserId == null)
            {
                user = new DefaultUser(this.factory, backyardId: request.BackyardId);
            }
            else
            {
                user = new DefaultUser(this.factory, id: request.UserId.Value);
            }

            var privilege = user.Privileges.Find(request.Url);

            if (privilege == null || privilege.Authority == null)
            {
                return new GetAuthorityResponse
                {
                    BackyardId = request.BackyardId,
                    Url = request.Url,
                };
            }

            var authority = privilege.Authority;

            return new GetAuthorityResponse
            {
                BackyardId = request.BackyardId,
                Url = request.Url,
                CanSelect = authority.CanSelect,
                CanInsert = authority.CanInsert,
                CanUpdate = authority.CanUpdate,
                CanDelete = authority.CanDelete,
                CanParticular = authority.CanParticular,
            };
        }

        #endregion
    }
}
