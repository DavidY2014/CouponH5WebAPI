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

        void Save(ProductInformation product);

        List<ProductInformation> GetProductsByClass(int class1, int class2);

        ProductInformation GetProductById(int ProductId);
        List<ProductInformation> GetProductsByBatchId(int batchId);
    }
}
