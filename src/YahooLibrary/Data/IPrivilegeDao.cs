using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahoo.Data
{
    public interface IPrivilegeDao
    {
        Task<IEnumerable<PrivilegeData>> GetManyAsync(int userId);

        Task<PrivilegeData> GetOneAsync(int userId, string url);
    }
}
