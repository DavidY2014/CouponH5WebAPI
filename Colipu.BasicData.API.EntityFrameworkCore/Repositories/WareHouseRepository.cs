﻿using BangBangFuli.H5.API.Core.BSystemDB;
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
   public class WareHouseRepository : BaseRepository<BSystemDBContext, Warehouse>, IWareHouseRepository
    {
        public WareHouseRepository(IDbContextManager<BSystemDBContext> dbContextManager)
  : base(dbContextManager)
        {
        }

        public Warehouse GetByLogicalWarehouseId(int logicalWarehouseId)
        {
            string sql = string.Format(@"SELECT w.* FROM dbo.TWarehouse(nolock) AS w
                                                INNER JOIN   dbo.TLogicalWarehouse(nolock) AS l
                                                ON w.WarehouseId=l.WarehouseId
                                                WHERE w.Status='A' and l.Status='A' and l.LogicalWarehouseId=@LogicalWarehouseId");
            if (BasicDatacfg.DefaultSmallB2BWarehouseId > 0)
            {
                sql += " and w.WarehouseId != @WarehouseId";
            }
            var paramDic = new Dictionary<string, object>();
            paramDic.Add("@LogicalWarehouseId", logicalWarehouseId);
            paramDic.Add("@WarehouseId", BasicDatacfg.DefaultSmallB2BWarehouseId);


            var data = Query<Warehouse>(sql, paramDic).FirstOrDefault();
            return data;
        }

       
    }
}
