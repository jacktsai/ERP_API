using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.DataAccess;
using System.Threading.Tasks;

namespace Yahoo.Business
{
    /// <summary>
    /// 預設的 <see cref="IUser"/> 介面實作。
    /// </summary>
    public class DefaultUser : IUser
    {
        private readonly IBusinessFactory factory;
        private readonly int? userId;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultUser" /> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="userId">The user ID.</param>
        public DefaultUser(IBusinessFactory factory, int? userId = null)
        {
            this.factory = factory;
            this.userId = userId;
        }

        private UserData data;

        int IUser.Id
        {
            get
            {
                if (this.userId != null)
                {
                    return this.userId.Value;
                }

                CheckState();
                return data.Id;
            }
        }

        string IUser.Name
        {
            get { CheckState(); return data.Name; }
            set { CheckState(); data.Name = value; }
        }

        string IUser.FullName
        {
            get { CheckState(); return data.FullName; }
            set { CheckState(); data.FullName = value; }
        }

        string IUser.Department
        {
            get { CheckState(); return data.Department; }
            set { CheckState(); data.Department = value; }
        }

        byte IUser.Degree
        {
            get { CheckState(); return data.Degree; }
            set { CheckState(); data.Degree = value; }
        }

        string IUser.Homepage
        {
            get { CheckState(); return data.Homepage; }
            set { CheckState(); data.Homepage = value; }
        }

        string IUser.ExtensionNumber
        {
            get { CheckState(); return data.ExtensionNumber; }
            set { CheckState(); data.ExtensionNumber = value; }
        }

        string IUser.BackyardId
        {
            get { CheckState(); return data.BackyardId; }
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

        private ICatPrivilegeCollection catPrivileges;

        ICatPrivilegeCollection IUser.CatPrivileges
        {
            get
            {
                if (catPrivileges == null)
                {
                    catPrivileges = CreateCatPrivilegeCollection();
                }

                return catPrivileges;
            }
        }

        protected virtual ICatPrivilegeCollection CreateCatPrivilegeCollection()
        {
            return new DefaultCatPrivilegeCollection(this.factory, this);
        }

        Task IUser.LoadAsync(string backyardId)
        {
            var userDao = this.factory.GetUserDao();
            var task = userDao.GetOneAsync(backyardId);

            return task.ContinueWith(t =>
            {
                if (t.Result == null)
                {
                    throw new UserNotFoundException(backyardId);
                }

                this.data = t.Result;
            });
        }

        Task IUser.SaveAsync()
        {
            throw new NotImplementedException();
        }

        void CheckState()
        {
            if (data == null)
            {
                throw new InvalidOperationException("User data has not been loaded!");
            }
        }
    }
}
