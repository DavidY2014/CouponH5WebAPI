using BangBangFuli.H5.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface IOrderService: IAppService
    {
        void CreateNewOrder(Order order);

        List<Order> GetAll();

        Order GetOrderById(int orderId);
        List<Order> GetOrdersByCoupon(int couponCode);
    }
}
