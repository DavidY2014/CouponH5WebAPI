using BangBangFuli.H5.API.EntityFrameworkCore;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BangBangFuli.H5.API.Core
{
    /// <summary>
    /// dapper 接口
    /// </summary>
    public class DapperWrapper : IDapper
    {
        private readonly string connectionString = "";

        public List<T> Get<T>(string sql, Dictionary<string, object> paramDic)
        {
            var param = new DynamicParameters();
            if (paramDic != null)
            {
                foreach (var ele in paramDic)
                {
                    param.Add(ele.Key, ele.Value);
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<T>(sql, param).ToList();
            }
        }




    }
}
