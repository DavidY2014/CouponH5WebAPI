using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.Utils.ORM.Interface;
using System.Collections.Generic;

namespace BangBangFuli.H5.API.Core.IRepositories
{
    public interface ICouponRepository: IBaseRepository<Coupon>
    {
        List<Coupon> GetAll();

        Coupon GetCouponById(int CouponId);

    }
}
