using BangBangFuli.H5.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface IBatchInformationService:IAppService
    {
        List<BatchInformation> GetAll();

        void CreateNew(BatchInformation batchInfo);

        BatchInformation GetBatchInfoByBatchId(string batchId);

        BatchInformation GetBatchInfoById(int Id);

        void RemoveBatchById(int Id);

        void UpdateBatchInfo(BatchInformation batchInfo);
    }
}
