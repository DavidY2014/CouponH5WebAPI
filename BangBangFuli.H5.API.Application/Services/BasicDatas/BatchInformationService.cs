using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public class BatchInformationService: IBatchInformationService
    {
        private readonly IBatchInformationRepository _batchInformationRepository;

        public BatchInformationService(IBatchInformationRepository batchInformationRepository)
        {
            _batchInformationRepository = batchInformationRepository;
        }
        public List<BatchInformation> GetAll()
        {
            return _batchInformationRepository.GetAll();
        }
    }
}
