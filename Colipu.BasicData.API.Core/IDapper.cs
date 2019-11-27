using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Core
{
    public interface IDapper
    {
        List<T> Get<T>(string sql, Dictionary<string, object> paramDic);
    }
}
