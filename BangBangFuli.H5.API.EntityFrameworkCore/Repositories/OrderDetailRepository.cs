﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.Utils.ORM.Imp;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
{
    public class OrderDetailRepository: BaseRepository<CouponSystemDBContext, OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbContextManager<CouponSystemDBContext> dbContextManager)
: base(dbContextManager)
        {
        }

        public List<OrderDetail> GetOrderDetailByOrderId(int orderId)
        {
            return Master.OrderDetails.Where(item => item.OrderId == orderId).ToList();
        }

    }
}
