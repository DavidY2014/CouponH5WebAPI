using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.Utils.ORM.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
{
   public  class OrderRepository : BaseRepository<CouponSystemDBContext, Order>, IOrderRepository
    {
        public OrderRepository(IDbContextManager<CouponSystemDBContext> dbContextManager)
: base(dbContextManager)
        {
        }

        public void CreateNewOrder(Order order)
        {
            Master.Orders.Add(order);
            Master.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return Master.Orders.ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return Master.Orders.Find(orderId);
        }
    }
}
