using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Serialization;
using ErpApi.Data;
using ErpApi.Data.Common;
using System.ComponentModel.DataAnnotations;
using ErpApi.Services;
using ErpApi.Entities;

namespace ErpApi.ApiControllers
{
    public class AuthorizationController : ApiController
    {
        private readonly IServiceAdapter _adapter;

        public AuthorizationController()
        {
            this._adapter = new ServiceAdapter();
        }

        [HttpPost]
        public GetUserAuthorityResponse GetAuthority([FromBody]GetUserAuthorityRequest request)
        {
            IAuthorizationService service = this._adapter.GetAuthorizationService();
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
