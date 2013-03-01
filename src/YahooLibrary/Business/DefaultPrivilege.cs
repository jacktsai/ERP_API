using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.DataAccess;

namespace Yahoo.Business
{
    public class DefaultPrivilege : IPrivilege
    {
        private readonly IBusinessFactory factory;
        private readonly IUser user;
        private readonly PrivilegeData data;

        internal DefaultPrivilege(IBusinessFactory factory, IUser user, PrivilegeData data)
        {
            this.factory = factory;
            this.user = user;
            this.data = data;
        }

        string IPrivilege.Url { get { return this.data.Url; } }

        string IPrivilege.Name { get { return this.data.Name; } }

        private Authority authority;

        Authority IPrivilege.Authority
        {
            get
            {
                if (authority == null)
                {
                    var dao = this.factory.GetAuthorityDao();
                    var data = dao.GetManyAsync(this.user.Id, this.data.Url).Result;

                    authority = new Authority(data);
                }

                return authority;
            }
        }
    }
}
