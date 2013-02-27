using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Yahoo.DataAccess;

namespace Yahoo.Business
{
    internal class AuthorityCollection : IAuthorityCollection
    {
        private readonly IBusinessFactory factory;
        private readonly IUser user;

        public AuthorityCollection(IBusinessFactory factory, IUser user)
        {
            this.factory = factory;
            this.user = user;
        }

        Authority IAuthorityCollection.Find(string url)
        {
            var dao = this.factory.GetAuthorityDao();
            var data = dao.GetOne(this.user.Id, url);

            if (data == null)
            {
                return null;
            }

            return new Authority(data);
        }

        IEnumerator<Authority> IEnumerable<Authority>.GetEnumerator()
        {
            var dao = this.factory.GetAuthorityDao();
            var data = dao.GetMany(this.user.Id);

            if (data == null)
            {
                data = new AuthorityData[0];
            }

            return data.Select(o => new Authority(o)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var o = this as IEnumerable<Authority>;
            return o.GetEnumerator();
        }
    }
}
