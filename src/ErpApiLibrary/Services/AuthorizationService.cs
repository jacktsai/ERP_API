using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.Data;

namespace ErpApi.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IDaoFactory _factory;

        public AuthorizationService(IDaoFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            this._factory = factory;
        }

        Authority IAuthorizationService.GetAuthority(string backyardId, string url)
        {
            if (backyardId == null)
            {
                throw new ArgumentNullException("backyardId");
            }
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            var dao = this._factory.GetAuthorityDao();
            var datas = dao.GetMany(backyardId, url);

            var authority = new Authority();

            if (datas == null || datas.Count() == 0)
            {
                return authority;
            }

            authority.CanAccess = true;
            authority.CanSelect = Judge(datas, d => d.CanSelect, d => d.DenySelect);
            authority.CanInsert = Judge(datas, d => d.CanInsert, d => d.DenyInsert);
            authority.CanUpdate = Judge(datas, d => d.CanUpdate, d => d.DenyUpdate);
            authority.CanDelete = Judge(datas, d => d.CanDelete, d => d.DenyDelete);
            authority.CanParticular = Judge(datas, d => d.CanParticular, d => d.DenyParticular);

            return authority;
        }

        private bool Judge(IEnumerable<AuthorityData> datas, Func<AuthorityData, bool?> canGetter, Func<AuthorityData, bool?> denyGetter)
        {
            // is denied ?
            if (datas.Any(o => denyGetter(o) == true))
            {
                return false;
            }

            // is granted ?
            if (datas.Any(o => canGetter(o) == true))
            {
                return true;
            }

            // default is false.
            return false;
        }
    }
}
