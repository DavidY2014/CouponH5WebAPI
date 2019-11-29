using BangBangFuli.H5.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface IProductInformationService:IAppService
    {
        List<ProductInformation> GetAll();

        void Save(ProductInformation product);

        List<ProductInformation> GetProductsByClass(int class1, int class2);
    }
}
