using System.Web.Http;
using ErpApi.Entities;
using ErpApi.Services;

namespace ErpApi.ApiControllers
{
    /// <summary>
    /// 使用者相關服務。
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// The instance of <see cref="IServiceAdapter"/> interface.
        /// </summary>
        private readonly IServiceAdapter _adapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        public UserController()
        {
            this._adapter = new ServiceAdapter();
        }

        /// <summary>
        /// Gets the profile.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response.</returns>
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
            }

            return response;
        }

        /// <summary>
        /// Gets the authority.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response.</returns>
        [HttpPost]
        public GetUserAuthorityResponse GetAuthority([FromBody]GetUserAuthorityRequest request)
        {
            var service = this._adapter.GetUserService();
            var authority = service.GetAuthority(request.BackyardId, request.Url);

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