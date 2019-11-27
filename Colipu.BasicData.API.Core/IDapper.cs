using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Core
{
    public interface IDapper
    {
        List<T> Get<T>(string sql, Dictionary<string, object> paramDic);
    }
}
