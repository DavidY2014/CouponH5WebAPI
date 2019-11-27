using BangBangFuli.H5.API.Core;
using BangBangFuli.H5.API.Core.BSystemDB;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.H5.API.EntityFrameworkCore.BSystemDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public class HolidayService : IHolidayService
    {
        private readonly IHolidayRepository _holidayRepository;
        public HolidayService(IHolidayRepository holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }

        public bool CheckIsHoliday(DateTime orderData)
        {
            var holidays = this.GetAll();
            return holidays != null && holidays.Any(x => x.Date == orderData.Date);
        }


        public List<DateTime> GetAll()
        {
            return _holidayRepository.Where(x => x.Status == "A")
                .Select(x => x.Date)
                .ToList();
        }
    }
}
