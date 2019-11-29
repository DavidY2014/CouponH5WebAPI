﻿using System;
using System.Collections.Generic;
using System.Text;
using BangBangFuli.H5.API.Core.Entities;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface IBannerService : IAppService
    {
        void Save(Banner banner);
        int GetMax();
        List<string> GetUniquePhotoNamesByBatchCode(string batchCode);
    }
}