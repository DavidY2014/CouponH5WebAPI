using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.Utils.ORM.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
{
    public class BatchInformationRepository : BaseRepository<CouponSystemDBContext, BatchInformation>, IBatchInformationRepository
    {
        public BatchInformationRepository(CouponSystemDBContext dbContext) : base(dbContext)
        {

        }

        public List<BatchInformation> GetAll()
        {
            return Master.BatchInformations.ToList();
        }


    }
}
