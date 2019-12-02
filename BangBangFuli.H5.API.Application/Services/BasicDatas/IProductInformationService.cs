using BangBangFuli.H5.API.Core;
using BangBangFuli.H5.API.Core.Entities;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface IProductInformationService:IAppService
    {
        List<ProductInformation> GetAll();

        void Save(ProductInformation product);

        List<ProductInformation> GetProductsByClassType(ClassType type);

        ProductInformation GetProductById(int ProductId);

        List<ProductInformation> GetProductsByBatchId(int batchId);
    }


    public interface MyPersistance : IPersistedGrantStore
    {

    }
}
