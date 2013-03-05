using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.Data;
using System.Threading.Tasks;

namespace Yahoo.Services.Defaults
{
    public class DefaultSubCategory : ISubCategory
    {
        private readonly IDaoFactory factory;
        private readonly int? id;
        private SubCategoryData data;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultSubCategory" /> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="id">The id.</param>
        public DefaultSubCategory(IDaoFactory factory, int id)
        {
            this.factory = factory;
            this.id = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultSubCategory" /> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="data">The data.</param>
        public DefaultSubCategory(IDaoFactory factory, SubCategoryData data)
        {
            this.factory = factory;
            this.data = data;
        }

        int ISubCategory.Id
        {
            get
            {
                if (this.id != null)
                {
                    return this.id.Value;
                }

                CheckState();
                return this.data.Id;
            }
        }

        string ISubCategory.Name { get { CheckState(); return this.data.Name; } }

        short ISubCategory.ZoneId { get { CheckState(); return this.data.ZoneId; } }

        IUser user;

        IUser ISubCategory.User
        {
            get
            {
                CheckState();

                if (string.IsNullOrEmpty(this.data.UserName))
                {
                    return null;
                }

                if (user == null)
                {
                    user = CreateUser(this.data.UserName);
                }

                return user;
            }
        }

        IUser ISubCategory.Manager
        {
            get
            {
                CheckState();

                if (string.IsNullOrEmpty(this.data.ManagerName))
                {
                    return null;
                }

                if (user == null)
                {
                    user = CreateUser(this.data.ManagerName);
                }

                return user;
            }
        }

        IUser ISubCategory.Purchaser
        {
            get
            {
                CheckState();

                if (string.IsNullOrEmpty(this.data.PurchaserName))
                {
                    return null;
                }

                if (user == null)
                {
                    user = CreateUser(this.data.PurchaserName);
                }

                return user;
            }
        }

        IUser ISubCategory.Staff
        {
            get
            {
                CheckState();

                if (string.IsNullOrEmpty(this.data.StaffName))
                {
                    return null;
                }

                if (user == null)
                {
                    user = CreateUser(this.data.StaffName);
                }

                return user;
            }
        }

        protected virtual IUser CreateUser(string name)
        {
            var u = new DefaultUser(this.factory, name: name);

            try
            {
                u.LoadAsync().Wait();
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is UserNotFoundException)
                {
                    // 如果 sale.dbo.catsub 未正確對應到 privilege.dbo.priuser，則回傳 null。
                    return null;
                }
                throw;
            }

            return u;
        }

        public Task LoadAsync()
        {
            if (this.id == null)
            {
                throw new InvalidOperationException();
            }

            var dao = this.factory.GetSubCategoryDao();
            var task = dao.GetOneAsync(this.id.Value);

            return task.ContinueWith(t =>
            {
                if (t.Result == null)
                {
                    throw new SubCategoryNotFoundException(this.id.Value);
                }

                this.data = t.Result;
            });
        }

        void CheckState()
        {
            if (data == null)
            {
                this.LoadAsync().Wait();
            }
        }
    }
}
