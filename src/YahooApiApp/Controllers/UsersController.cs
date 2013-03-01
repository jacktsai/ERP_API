using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Yahoo.Business;

namespace Yahoo.Controllers
{
    public class UsersController : ApiController
    {
        private IBusinessFactory factory;

        public UsersController()
        {
            this.factory = new DefaultBusinessFactory();
        }

        [HttpGet]
        public string Test(string test)
        {
            return test;
        }

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
            public string CatSubIds;
        }

        [HttpPost]
        public GetProfileResponse GetProfile(GetProfileRequest request)
        {
            IUser user = new DefaultUser(this.factory);
            user.LoadAsync(request.BackyardId).Wait();

            return new GetProfileResponse
            {
                Id = user.Id,
                Name = user.Name,
                FullName = user.FullName,
                Department = user.Department,
                Degree = user.Degree,
                Homepage = user.Homepage,
                ExtensionNumber = user.ExtensionNumber,
                BackyardID = user.BackyardId,
                CatSubIds = string.Join(",", user.CatPrivileges.Select(o => o.SubId)),
            };
        }

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

        public GetAuthorityResponse GetAuthority(GetAuthorityRequest request)
        {
            IUser user;
            if (request.UserId != null)
            {
                user = new DefaultUser(this.factory, userId: request.UserId.Value); //short-cut
            }
            else
            {
                user = new DefaultUser(this.factory);
                user.LoadAsync(request.BackyardId).Wait();
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
    }
}
