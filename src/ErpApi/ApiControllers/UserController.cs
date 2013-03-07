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
using ErpApi.Services;
using ErpApi.Entities;

namespace ErpApi.ApiControllers
{
    /// <summary>
    /// 使用者。
    /// </summary>
    public class UserController : ApiController
    {
        private readonly IServiceAdapter _adapter;

        public UserController()
        {
            this._adapter = new ServiceAdapter();
        }

        [HttpPost]
        public GetUserProfileResponse GetProfile([FromBody]GetUserProfileRequest request)
        {
            var service = this._adapter.GetUserService();
            var profile = service.GetProfile(request.BackyardId);

            var response = new GetUserProfileResponse();
            if (profile != null)
            {
                response.Id = profile.User.Id;
                response.Name = profile.User.Name;
                response.FullName = profile.User.FullName;
                response.Department = profile.User.Department;
                response.Degree = profile.User.Degree;
                response.Homepage = profile.User.Homepage;
                response.ExtNumber = profile.User.ExtNumber;
                response.BackyardID = profile.User.BackyardId;
                response.SubCatIds = string.Join(",", profile.SubCatIds);
            };

            return response;
        }
    }
}
