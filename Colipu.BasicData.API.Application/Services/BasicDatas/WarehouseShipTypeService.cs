using Colipu.BasicData.API.Core;
using Colipu.BasicData.API.Core.BSystemDB;
using Colipu.BasicData.API.Core.IRepositories.BasicDatas;
using Colipu.BasicData.API.EntityFrameworkCore.BSystemDB;
using System.Collections.Generic;
using System.Linq;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public class WarehouseShipTypeService : IWarehouseShipTypeService
    {
        private readonly IWarehouseShipTypeRepository _warehouseShipTypeRepository;

        public WarehouseShipTypeService(IWarehouseShipTypeRepository warehouseShipTypeRepository)
        {
            _warehouseShipTypeRepository = warehouseShipTypeRepository;
        }
        /// <summary>
        /// 根据逻辑仓编号获取对应配送编号
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        public List<int> GetShipTypesByWarehouse(int warehouseId)
        {
            return _warehouseShipTypeRepository.GetAll().Where(x => x.WarehouseId == warehouseId && x.Status == "A").Select(x => x.ShipTypeId).ToList();
        }
    }
}
