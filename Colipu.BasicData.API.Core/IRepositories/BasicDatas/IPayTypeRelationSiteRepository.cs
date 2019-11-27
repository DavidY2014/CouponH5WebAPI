using BangBangFuli.H5.API.Core.BSystemDB;
using Colipu.Utils.ORM.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Core.IRepositories.BasicDatas
{
    public interface IPayTypeRelationSiteRepository: IBaseRepository<PayTypeRelationSite>
    {
        List<PayTypeRelationSite> GetAll();
    }
}
