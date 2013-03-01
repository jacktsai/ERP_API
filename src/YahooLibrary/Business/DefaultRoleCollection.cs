using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Yahoo.DataAccess;

namespace Yahoo.Business
{
    internal class DefaultRoleCollection : IRoleCollection
    {
        private readonly IBusinessFactory factory;
        private readonly IUser user;

        private IEnumerable<Role> cache;

        public DefaultRoleCollection(IBusinessFactory factory, IUser user)
        {
            this.factory = factory;
            this.user = user;
        }

        IEnumerator<Role> IEnumerable<Role>.GetEnumerator()
        {
            if (cache == null)
            {
                var dao = factory.GetRoleDao();
                var data = dao.GetManyAsync(this.user.Id).Result;

                if (data == null)
                {
                    data = new RoleData[0];
                }

                cache = data.Select(o => new Role(o));
            }

            return cache.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var o = this as IEnumerable<Role>;
            return o.GetEnumerator();
        }

        bool IRoleCollection.HasSelect
        {
            get { return cache.Any(o => o.CanSelect); }
        }

        bool IRoleCollection.HasInsert
        {
            get { return cache.Any(o => o.CanInsert); }
        }

        bool IRoleCollection.HasUpdate
        {
            get { return cache.Any(o => o.CanUpdate); }
        }

        bool IRoleCollection.HasDelete
        {
            get { return cache.Any(o => o.CanDelete); }
        }

        bool IRoleCollection.HasParticular
        {
            get { return cache.Any(o => o.CanParticular); }
        }
    }
}
