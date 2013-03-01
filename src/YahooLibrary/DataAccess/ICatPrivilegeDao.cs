using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahoo.DataAccess
{
    public interface ICatPrivilegeDao
    {
        Task<IEnumerable<CatPrivilegeData>> GetManyAsync(int userId);
    }
}
