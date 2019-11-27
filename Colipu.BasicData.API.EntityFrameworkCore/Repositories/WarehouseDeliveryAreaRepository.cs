using BangBangFuli.H5.API.Core.BSystemDB;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.H5.API.Core.Param;
using BangBangFuli.H5.API.EntityFrameworkCore.BSystemDB;
using Colipu.BasicData.API.Extension.Configuration.DBConfig;
using Colipu.Utils.ORM.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
{
    public class WarehouseDeliveryAreaRepository : BaseRepository<BSystemDBContext, WarehouseDeliveryArea>, IWarehouseDeliveryAreaRepository
    {
        public WarehouseDeliveryAreaRepository(IDbContextManager<BSystemDBContext> dbContextManager)
: base(dbContextManager)
        {
        }

        public int GetLogicalWarehouseByCity(int cityId)
        {
            string sql = string.Format(@"SELECT TOP 1 b.LogicalWarehouseId FROM TWarehouseDeliveryArea(nolock) a
                    JOIN TLogicalWarehouse(nolock) b ON a.WarehouseId=b.WarehouseId
                    WHERE a.Status='A' AND B.Status='A' AND a.CityId={0}
                    AND b.IsDefault = 'Y' AND b.LogicalWarehouseType = 'D'", cityId);
            if (BasicDatacfg.DefaultSmallB2BWarehouseId > 0)
            {
                sql += " and b.WarehouseId != " + BasicDatacfg.DefaultSmallB2BWarehouseId;
            }
            return Query<int>(sql, null).FirstOrDefault();
        }

        public List<WarehouseParamOutputDto> GetWarehouseByProvince(int provinceId)
        {
            var warehouseParamList = new List<WarehouseParamOutputDto>();
            string sql = string.Format(@"SELECT a.CityId,c.* FROM TWarehouseDeliveryArea(nolock) a
                    JOIN TLogicalWarehouse(nolock) b ON a.WarehouseId=b.WarehouseId
                    join dbo.TWarehouse c on b.WarehouseId=c.WarehouseId
                    join TCity ci on ci.CityId=a.CityId
                    WHERE a.Status='A' AND B.Status='A' AND ci.ProvinceId = ({0})
                    AND b.IsDefault = 'Y' AND b.LogicalWarehouseType = 'D' and c.Status='A'", provinceId);
            if (BasicDatacfg.DefaultSmallB2BWarehouseId > 0)
            {
                sql += " and c.WarehouseId != " + BasicDatacfg.DefaultSmallB2BWarehouseId;
            }
            return Query<WarehouseParamOutputDto>(sql, null).ToList();
        }
    }
}
