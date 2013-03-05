using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.Data;
using System.Threading.Tasks;

namespace Yahoo
{
    /// <summary>
    /// 預設的 <see cref="IUser"/> 介面實作。
    /// </summary>
    public class DefaultUser : IUser
    {
        private readonly IDaoFactory factory;
        private readonly int? id;
        private readonly string name;
        private readonly string backyardId;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultUser" /> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="id">The user ID.</param>
        /// <param name="name">The user name.</param>
        /// <param name="backyardId">The backyard ID.</param>
        public DefaultUser(IDaoFactory factory, int? id = null, string name = null, string backyardId = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }
            if (id == null && name == null && backyardId == null)
            {
                throw new InvalidOperationException();
            }

            this.factory = factory;
            this.id = id;
            this.name = name;
            this.backyardId = backyardId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultUser" /> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="data">The data.</param>
        public DefaultUser(IDaoFactory factory, UserData data)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            this.factory = factory;
            this.data = data;
        }

        private UserData data;

        int IUser.Id
        {
            get
            {
                if (this.id != null)
                {
                    return this.id.Value;
                }

                CheckState();
                return data.Id;
            }
        }

        string IUser.Name
        {
            get
            {
                if (this.name != null)
                {
                    return this.name;
                }

                CheckState();
                return data.Name;
            }
        }

        string IUser.FullName
        {
            get { CheckState(); return data.FullName; }
        }

        string IUser.Department
        {
            get { CheckState(); return data.Department; }
        }

        byte IUser.Degree
        {
            get { CheckState(); return data.Degree; }
        }

        string IUser.Email
        {
            get { CheckState(); return data.Email; }
        }

        string IUser.Homepage
        {
            get { CheckState(); return data.Homepage; }
        }

        string IUser.ExtNumber
        {
            get { CheckState(); return data.ExtNumber; }
        }

        string IUser.BackyardId
        {
            get
            {
                if (this.backyardId != null)
                {
                    return this.backyardId;
                }

                CheckState();
                return data.BackyardId;
            }
        }

        private IRoleCollection roles;

        IRoleCollection IUser.Roles
        {
            get
            {
                if (roles == null)
                {
                    roles = CreateRoleCollection();
                }

                return roles;
            }
        }

        protected virtual IRoleCollection CreateRoleCollection()
        {
            return new DefaultRoleCollection(this.factory, this);
        }

        private IPrivilegeCollection privileges;

        IPrivilegeCollection IUser.Privileges
        {
            get
            {
                if (privileges == null)
                {
                    privileges = CreatePrivilegeCollection();
                }

                return privileges;
            }
        }

        protected virtual IPrivilegeCollection CreatePrivilegeCollection()
        {
            return new DefaultPrivilegeCollection(this.factory, this);
        }

        private ISubCategoryCollection subCategories;

        ISubCategoryCollection IUser.SubCategories
        {
            get
            {
                if (subCategories == null)
                {
                    subCategories = CreateSubCategoryCollection();
                }

                return subCategories;
            }
        }

        protected virtual ISubCategoryCollection CreateSubCategoryCollection()
        {
            return new DefaultSubCategoryCollection(this.factory, this);
        }

        public Task LoadAsync()
        {
            var dao = this.factory.GetUserDao();
            var task = dao.GetOneAsync(id, name, backyardId);

            return task.ContinueWith(t =>
            {
                if (t.Result == null)
                {
                    throw new UserNotFoundException();
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
