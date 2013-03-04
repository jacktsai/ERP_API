using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahoo.DataAccess
{
    public interface IUserDao
    {
        Task<UserData> GetOneAsync(int? id = null, string name = null, string backyardId = null);
    }
}
