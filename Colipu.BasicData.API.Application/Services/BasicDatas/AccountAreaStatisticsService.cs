using Colipu.BasicData.API.Core;
using Colipu.BasicData.API.Core.IRepositories.BasicDatas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public class AccountAreaStatisticsService : IAccountAreaStatisticsService
    {
        private readonly IAccountAreaStatisticsRepository _accountAreaStatisticsRepository;
        public AccountAreaStatisticsService(IAccountAreaStatisticsRepository accountAreaStatisticsRepository)
        {
            _accountAreaStatisticsRepository = accountAreaStatisticsRepository;
        }

        public string GetAccountArea(int accountId, int customerId, bool hasRefer = false)
        {
            if (hasRefer)
            {
                string res = SetAccountArea(accountId, customerId);
                return res;
            }
            var result = _accountAreaStatisticsRepository.GetAll().Where(entity => entity.AccountId == accountId).ToList();
            if (result != null && result.Any() && !result.All(x => string.IsNullOrWhiteSpace(x.AccountAreaNames)))
            {
                return result.FirstOrDefault().AccountAreaNames;
            }

            //如果没有获取到重新计算 （防止MonDb中间出问题）
            return this.SetAccountArea(accountId, customerId);
        }

        public void RefreshAccountArea(int accountId, int customerId)
        {
            throw new NotImplementedException();
        }

        public string SetAccountArea(int accountId, int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
