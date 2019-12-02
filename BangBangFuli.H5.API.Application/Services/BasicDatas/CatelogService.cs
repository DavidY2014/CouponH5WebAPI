using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public class CatelogService : ICatelogService
    {
        private readonly ICatelogRepository _catelogRepository;

        public CatelogService(ICatelogRepository catelogRepository)
        {
            _catelogRepository = catelogRepository;
        }

        public Catelog GetCatelogInfoByClassId(int classId)
        {
            return _catelogRepository.GetCatelogInfoByClassId(classId);
        }

        public List<Catelog> GetAll()
        {
            return _catelogRepository.GetAll();
        }

    }
}
