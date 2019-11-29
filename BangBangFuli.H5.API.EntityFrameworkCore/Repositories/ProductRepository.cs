using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.Utils.ORM.Imp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
{
    public class ProductRepository : BaseRepository<CouponSystemDBContext, ProductInformation>, IProductRepository
    {
        public ProductRepository(IDbContextManager<CouponSystemDBContext> dbContextManager)
: base(dbContextManager)
        {
        }

        public  List<ProductInformation> GetAll()
        {
            return Master.ProductInformations.ToList();
        }

        public void Save(ProductInformation product)
        {
            Master.ProductInformations.Add(product);
            Master.SaveChanges();
        }

        public List<ProductInformation> GetProductsByClass(int class1,int class2)
        {
           return  Master.ProductInformations.Where(item => item.Catelog1 == class1 && item.Catelog2 == class2).ToList();
        }
    }
}
