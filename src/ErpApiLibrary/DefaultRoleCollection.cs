using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ErpApi.Data;

namespace ErpApi
{
    public class DefaultRoleCollection : IRoleCollection
    {
        private readonly IDaoFactory factory;
        private readonly IUser user;

        private IEnumerable<IRole> cache;

        public DefaultRoleCollection(IDaoFactory factory, IUser user)
        {
            this.factory = factory;
            this.user = user;
        }

        IEnumerator<IRole> IEnumerable<IRole>.GetEnumerator()
        {
            if (cache == null)
            {
                var dao = factory.GetRoleDao();
                var data = dao.GetManyAsync(this.user.Id).Result;

                if (data == null)
                {
                    data = new RoleData[0];
                }

                cache = data.Select(o => CreateRole(o));
            }

            return cache.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var o = this as IEnumerable<IRole>;
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

        protected virtual IRole CreateRole(RoleData data)
        {
            return new DefaultRole(data);
        }
    }
}
