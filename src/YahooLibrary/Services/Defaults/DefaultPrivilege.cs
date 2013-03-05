using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.Data;

namespace Yahoo.Services.Defaults
{
    public class DefaultPrivilege : IPrivilege
    {
        private readonly IDaoFactory factory;
        private readonly IUser user;
        private readonly PrivilegeData data;

        public DefaultPrivilege(IDaoFactory factory, IUser user, PrivilegeData data)
        {
            this.factory = factory;
            this.user = user;
            this.data = data;
        }

        string IPrivilege.Url { get { return this.data.Url; } }

        string IPrivilege.Name { get { return this.data.Name; } }

        private IAuthority authority;

        IAuthority IPrivilege.Authority
        {
            get
            {
                if (authority == null)
                {
                    var dao = this.factory.GetAuthorityDao();
                    var data = dao.GetManyAsync(this.user.Id, this.data.Url).Result;

                    authority = CreateAuthority(data);
                }

                return authority;
            }
        }

        protected virtual IAuthority CreateAuthority(IEnumerable<AuthorityData> data)
        {
            return new DefaultAuthority(data);
        }
    }
}
