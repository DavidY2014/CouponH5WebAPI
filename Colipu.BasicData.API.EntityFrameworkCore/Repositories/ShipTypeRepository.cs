using BangBangFuli.H5.API.Core.BSystemDB;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.H5.API.EntityFrameworkCore.BSystemDB;
using Colipu.BasicData.API.Extension.Const;
using Colipu.Utils.ORM.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
{
    public class ShipTypeRepository : BaseRepository<BSystemDBContext, ShipType>, IShipTypeRepository
    {
        public ShipTypeRepository(IDbContextManager<BSystemDBContext> dbContextManager)
  : base(dbContextManager)
        {
        }

        public List<ShipType> GetAll()
        {
            return MasterSet.ToList();
        }

        public Dictionary<int, int> GetPriorityShipTypes()
        {
            string sql = string.Format(@"SELECT DISTINCT TB.ShipTypeId FROM (
                SELECT S.ShipTypeId,P.PayTypeId FROM dbo.TShipType(NOLOCK) AS S
                CROSS JOIN dbo.TPayType(NOLOCK) AS P
                WHERE S.Status='{0}' AND P.Status='{0}' AND P.IsWebsiteShow='{1}' AND P.PayClass IN ('{2}','{3}')
                ) AS TB
                LEFT JOIN dbo.TShipTypeUnPay(NOLOCK) AS SP 
                ON TB.ShipTypeId=SP.ShipTypeId AND TB.PayTypeId=SP.PayTypeId AND SP.Status='{0}'
                WHERE SP.UnPayId IS NULL "
               , AppStruct.StatusType.Active, AppStruct.YNStatus.Yes, AppStruct.PayClassStruct.AccountPeriodPayment, AppStruct.PayClassStruct.CashOnDelivery);

            return Query<int>(sql, null).ToDictionary(x=>x,y=>y);
        }
    }
}
