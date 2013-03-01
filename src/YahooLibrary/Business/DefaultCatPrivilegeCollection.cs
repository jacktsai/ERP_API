using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Yahoo.DataAccess;

namespace Yahoo.Business
{
    internal class DefaultCatPrivilegeCollection : ICatPrivilegeCollection
    {
        private readonly IBusinessFactory factory;
        private readonly IUser user;

        public DefaultCatPrivilegeCollection(IBusinessFactory factory, IUser user)
        {
            this.factory = factory;
            this.user = user;
        }

        IEnumerator<CatPrivilege> IEnumerable<CatPrivilege>.GetEnumerator()
        {
            var dao = factory.GetCatPrivilegeDao();
            var data = dao.GetManyAsync(this.user.Id).Result;

            if (data == null)
            {
                data = new CatPrivilegeData[0];
            }

            return data.Select(o => new CatPrivilege(o)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var o = this as IEnumerable<CatPrivilege>;
            return o.GetEnumerator();
        }
    }
}
