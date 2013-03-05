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
    /// 使用者。
    /// </summary>
    public class UserController : ApiController
    {
        private IDaoFactory factory;

        public UserController()
        {
            // TODO: 有多餘的時間再將 dependency 抽出
            this.factory = new CommonDaoFactory();
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
            public string ExtNumber;
            public string BackyardID;
            public string SubCatIds;
        }

        [HttpPost]
        public GetProfileResponse GetProfile([FromBody]GetProfileRequest request)
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
                ExtNumber = user.ExtNumber,
                BackyardID = user.BackyardId,
                SubCatIds = string.Join(",", user.SubCategories.Select(o => o.Id)),
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
            public bool CanAccess;
            public bool CanSelect;
            public bool CanInsert;
            public bool CanUpdate;
            public bool CanDelete;
            public bool CanParticular;
        }

        [HttpPost]
        public GetAuthorityResponse GetAuthority([FromBody]GetAuthorityRequest request)
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

            var response = new GetAuthorityResponse
            {
                BackyardId = request.BackyardId,
                Url = request.Url,
            };

            if (privilege != null)
            {
                response.CanAccess = true;
            }

            if (privilege.Authority != null)
            {
                var authority = privilege.Authority;
                response.CanSelect = authority.CanSelect;
                response.CanInsert = authority.CanInsert;
                response.CanUpdate = authority.CanUpdate;
                response.CanDelete = authority.CanDelete;
                response.CanParticular = authority.CanParticular;
            }

            return response;
        }

        #endregion
    }
}
