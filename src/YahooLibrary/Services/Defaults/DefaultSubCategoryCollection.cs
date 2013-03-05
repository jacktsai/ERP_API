using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Yahoo.Data;

namespace Yahoo.Services.Defaults
{
    public class DefaultSubCategoryCollection : ISubCategoryCollection
    {
        private readonly IDaoFactory factory;
        private readonly IUser user;

        public DefaultSubCategoryCollection(IDaoFactory factory, IUser user)
        {
            this.factory = factory;
            this.user = user;
        }

        IEnumerator<ISubCategory> IEnumerable<ISubCategory>.GetEnumerator()
        {
            var dao = factory.GetSubCategoryDao();
            var data = dao.GetManyAsync(this.user.Id).Result;

            if (data == null)
            {
                data = new SubCategoryData[0];
            }

            return data.Select(o => CreateCatPrivilege(o)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var o = this as IEnumerable<ISubCategory>;
            return o.GetEnumerator();
        }

        protected virtual ISubCategory CreateCatPrivilege(SubCategoryData data)
        {
            return new DefaultSubCategory(this.factory, data);
        }
    }
}
