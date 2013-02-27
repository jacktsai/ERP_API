using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.DataAccess;

namespace Yahoo.Business
{
    /// <summary>
    /// 預設的 <see cref="IUser"/> 介面實作。
    /// </summary>
    public class User : IUser
    {
        private readonly IBusinessFactory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public User(IBusinessFactory factory)
        {
            this.factory = factory;
        }

        private UserData data;

        int IUser.Id
        {
            get { CheckState(); return data.Id; }
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

        int IUser.Degree
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
            set { CheckState(); data.BackyardId = value; }
        }

        private IAuthorityCollection authorities;

        IAuthorityCollection IUser.Authorities
        {
            get
            {
                CheckState();

                if (authorities == null)
                {
                    authorities = new AuthorityCollection(this.factory, this);
                }

                return authorities;
            }
        }

        bool IUser.TryLoad(int userId)
        {
            var userDao = this.factory.GetUserDao();
            var userData = userDao.GetOne(userId);

            if (userData == null)
            {
                return false;
            }

            this.data = userData;

            return true;
        }

        void IUser.New()
        {
            throw new NotImplementedException();
        }

        bool IUser.TrySave()
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
