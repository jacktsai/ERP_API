using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net;
using Yahoo.Business.Security;
using System.Net.Http.Formatting;
using Yahoo.Business.Security.Cryptography;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Yahoo.Controllers
{
    public class SecurityController : ApiController
    {
        private readonly ISecurityService securityService;

        public SecurityController()
        {
            var userDao = new Yahoo.DataAccess.Common.UserDao();
            var roleDao = new Yahoo.DataAccess.Common.RoleDao();
            var privilegeDao = new Yahoo.DataAccess.Common.PrivilegeDao();
            var functionDao = new Yahoo.DataAccess.Common.FunctionDao();
            var hashProvider = new DefaultHashProvider();

            this.securityService = new DefaultSecurityService(userDao, roleDao, privilegeDao, functionDao, hashProvider);
        }

        public SecurityController(ISecurityService securityService)
        {
            this.securityService = securityService;
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
            public int? UserId { get; set; }
        }

        public class GetProfileResponse
        {
            public int PriuserID;
            public string PriuserName;
            public string CatprivilegeCatsubids;
            public string PriuserFullName;
            public string PriuserDepartment;
            public int PriuserDegree;
            public string PriuserHomepage;
            public string PriuserExtno;
            public string BackyardID;
            public bool HasSelect;
            public bool HasInsert;
            public bool HasUpdate;
            public bool HasDelete;
            public bool HasParticular;
        }

        [HttpPost]
        public GetProfileResponse GetProfile(GetProfileRequest request)
        {
            var profile = this.securityService.GetUser(request.UserId.Value);

            var response = new GetProfileResponse
            {
                PriuserID = profile.UserId,
                PriuserName = profile.Name,
                CatprivilegeCatsubids = "1,2,3,4",
                PriuserFullName = profile.FullName,
                PriuserDepartment = "研發",
                PriuserDegree = 1,
                PriuserHomepage = "http://",
                PriuserExtno = "124567",
                BackyardID = "jacktsai",
                HasSelect = false,
                HasInsert = true,
                HasUpdate = false,
                HasDelete = true,
                HasParticular = false,
            };

            return response;
        }
    }
}