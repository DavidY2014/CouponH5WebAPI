using BangBangFuli.H5.API.Core.BSystemDB;
using Colipu.Utils.ORM.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Core.IRepositories.BasicDatas
{
    public interface IPayTypeRepository: IBaseRepository<PayType>
    {
        List<PayType> GetAll();
    }
}
