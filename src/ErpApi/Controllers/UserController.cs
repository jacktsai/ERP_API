﻿using System.Linq;
using System.Web.Http;
using ErpApi.Entities;
using ErpApi.BLL;
using ErpApi.Utilities;

namespace ErpApi.ApiControllers
{
    /// <summary>
    /// 使用者相關服務。
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// The instance of <see cref="ErpApi.BLL.IUserService"/> interface.
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        public UserController()
        {
            this._userService = ServiceFactory.GetUserService();
        }

        /// <summary>
        /// 取得使用者相關資訊。
        /// </summary>
        /// <param name="request">Request 內容。</param>
        /// <returns>Response 內容。</returns>
        [HttpPost]
        public GetUserProfileResponse GetProfile([FromBody]GetUserProfileRequest request)
        {
            var profile = this._userService.GetProfile(request.BackyardId);

            var response = new GetUserProfileResponse();
            if (profile != null)
            {
                response.Id = profile.User.Id;
                response.Name = profile.User.Name;
                response.FullName = profile.User.FullName;
                response.Department = profile.User.Department;
                response.Degree = profile.User.Degree;
                response.Homepage = profile.User.Homepage;
                response.ExtNumber = profile.User.ExtNo;
                response.BackyardId = profile.User.BackyardId;
                response.CategoryIds = profile.SubCatIds.ToArray();
            }

            return response;
        }

        /// <summary>
        /// 取得使用者 URL 的權限資訊。
        /// </summary>
        /// <param name="request">Request 內容。</param>
        /// <returns>Response 內容。</returns>
        [HttpPost]
        public GetUserAuthorityResponse GetAuthority([FromBody]GetUserAuthorityRequest request)
        {
            var authority = this._userService.GetAuthority(request.BackyardId, request.Url);

            return new GetUserAuthorityResponse
            {
                BackyardId = request.BackyardId,
                Url = request.Url,
                CanAccess = authority.CanAccess,
                CanSelect = authority.CanSelect,
                CanInsert = authority.CanInsert,
                CanUpdate = authority.CanUpdate,
                CanDelete = authority.CanDelete,
                CanParticular = authority.CanParticular,
            };
        }
    }
}