using BangBangFuli.H5.API.Core;
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
        //        public ProductRepository(IDbContextManager<CouponSystemDBContext> dbContextManager)
        //: base(dbContextManager)
        //        {
        //        }

        public ProductRepository(CouponSystemDBContext dbContext):base(dbContext)
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

        public void UpdateProduct(ProductInformation product)
        {
            Master.ProductInformations.Update(product);
            Master.SaveChanges();
        }

        public List<ProductInformation> GetProductsByClassType (ClassType type)
        {
           return  Master.ProductInformations.Where(item => item.Type == type).ToList();
        }

        public ProductInformation GetProductById(int ProductId)
        {
            return Master.ProductInformations.Find(ProductId);
        }

        public List<ProductInformation> GetProductsByBatchId(int batchId)
        {
            return Master.ProductInformations.Where(item => item.BatchId == batchId).ToList();
        }

        public void RemoveProductById(int productId)
        {
            ProductInformation product =  GetProductById(productId);
            Master.ProductInformations.Remove(product);
            Master.SaveChanges();
        }


  
    }
}
