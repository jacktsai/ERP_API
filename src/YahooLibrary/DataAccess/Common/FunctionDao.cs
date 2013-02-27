using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Yahoo.DataAccess.Common
{
    public class FunctionDao : CommonDao, IFunctionDao
    {
        public FunctionDao()
            : base("security")
        {
        }

        IEnumerable<Function> IFunctionDao.GetMany(IEnumerable<int> functionIds)
        {
            using (var connection = base.CreateConnection())
            {
                using (var dbCommand = connection.CreateCommand())
                {
                    string ids = string.Join(", ", functionIds);

                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = base.Resource.GetString("GetMany.sql").Replace("{FunctionIds}", ids);

                    using (var reader = dbCommand.ExecuteReader())
                    {
                        IList<Function> list = new List<Function>();
                        while (reader.Read())
                        {
                            var o = new Function
                            {
                                Id = reader.GetInt32(0),
                                CategoryId = reader.GetInt32(1),
                                CategorySubId = reader.GetInt32(2),
                            };
                            list.Add(o);
                        }
                        return list.ToArray();
                    }
                }
            }
        }
    }
}
