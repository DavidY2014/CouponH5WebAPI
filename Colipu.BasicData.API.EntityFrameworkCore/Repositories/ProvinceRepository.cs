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
    public class ProvinceRepository: BaseRepository<BSystemDBContext, Province>, IProvinceRepository
    {
        public ProvinceRepository(IDbContextManager<BSystemDBContext> dbContextManager)
         : base(dbContextManager)
        {
        }

        public List<Province> GetProvinceList()
        {
            return Where(x => x.Status == AppStruct.StatusType.Active).OrderBy(x => x.ShowOrder).ThenBy(x => x.ProvinceId).ToList();
        }

        public List<Province> GetAll()
        {
            return MasterSet.ToList();
        }

    }
}
