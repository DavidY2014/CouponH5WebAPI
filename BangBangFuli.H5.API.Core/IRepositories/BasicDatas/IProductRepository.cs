using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.Utils.ORM.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Core.IRepositories.BasicDatas
{
    public interface IProductRepository: IBaseRepository<ProductInformation>
    {
        List<ProductInformation> GetAll();
    }
}
