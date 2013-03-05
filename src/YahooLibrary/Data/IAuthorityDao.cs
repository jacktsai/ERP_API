using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahoo.Data
{
    public interface IAuthorityDao
    {
        Task<IEnumerable<AuthorityData>> GetManyAsync(int userId);
        Task<IEnumerable<AuthorityData>> GetManyAsync(int userId, string url);
    }
}
