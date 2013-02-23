using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Yahoo.DataAccess.Common.Resources;

namespace Yahoo.DataAccess.Common
{
    public class PrivilegeDao : CommonDao, IPrivilegeDao
    {
        public PrivilegeDao()
            : base("security")
        {
        }

        IEnumerable<Privilege> IPrivilegeDao.GetMany(int? userId)
        {
            using (var connection = base.CreateConnection())
            {
                using (var dbCommand = connection.CreateCommand())
                {
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = base.Resource.GetString("GetMany.sql");

                    #region Prepare parameters

                    var userIdParameter = dbCommand.CreateParameter();
                    userIdParameter.ParameterName = "@priuser_id";
                    if (userId != null)
                    {
                        userIdParameter.Value = userId.Value;
                    }
                    else
                    {
                        userIdParameter.Value = DBNull.Value;
                    }
                    dbCommand.Parameters.Add(userIdParameter);

                    #endregion

                    using (var reader = dbCommand.ExecuteReader())
                    {
                        IList<Privilege> list = new List<Privilege>();
                        while (reader.Read())
                        {
                            var o = new Privilege
                            {
                                FunctionId = reader.GetInt32(0),
                            };
                            list.Add(o);
                        }
                        return list.ToArray();
                    }
                }
            }
        }

        void IPrivilegeDao.Remove(int privilegeId)
        {
            throw new NotImplementedException();
        }

        void IPrivilegeDao.Add(Privilege o)
        {
            throw new NotImplementedException();
        }

        void IPrivilegeDao.Update(Privilege o)
        {
            throw new NotImplementedException();
        }
    }
}
