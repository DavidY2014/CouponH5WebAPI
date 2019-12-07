﻿using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.Utils.ORM.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Core.IRepositories.BasicDatas
{
    public interface IBatchInformationRepository: IBaseRepository<BatchInformation>
    {
        List<BatchInformation> GetAll();

        void CreateNew(BatchInformation batchInfo);
        BatchInformation GetBatchInfoByBatchId(string batchId);

        BatchInformation GetBatchInfoById(int Id);

        void RemoveBatchById(int Id);

        void UpdateBatchInfo(BatchInformation batchInfo);
    }
}
