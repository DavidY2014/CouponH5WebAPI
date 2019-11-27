using BangBangFuli.H5.API.Core.CouponSystemDB;
using System.Collections.Generic;

namespace BangBangFuli.H5.API.Core.IRepositories
{
    public interface ICouponRepository: IRepository<Coupon>
    {
        List<Coupon> GetAll();

        Coupon GetBranchById(int branchId);

    }
}
