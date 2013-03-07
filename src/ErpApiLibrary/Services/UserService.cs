using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.Data;

namespace ErpApi.Services
{
    public class UserService : IUserService
    {
        private readonly IDaoFactory _factory;

        public UserService(IDaoFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            this._factory = factory;
        }

        Profile IUserService.GetProfile(string backyardId)
        {
            if (backyardId == null)
            {
                throw new ArgumentNullException("backyardId");
            }

            var userDao = this._factory.GetUserDao();
            var userData = userDao.GetOne(backyardId);

            if (userData == null)
            {
                return null;
            }

            var subCatDao = this._factory.GetSubCategoryDao();
            var subCats = subCatDao.GetMany(userData.Id);

            return new Profile
            {
                User = new User(userData),
                SubCatIds = subCats.Select(o => o.Id),
            };
        }
    }
}
