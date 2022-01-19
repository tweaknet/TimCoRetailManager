﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMApiv2.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryData _inventoryData;

        public InventoryController(IInventoryData inventoryData)
        {
            _inventoryData = inventoryData;
        }
        [Authorize(Roles = "Manager,Admin")]
        [HttpGet]
        public List<InventoryModel> Get()
        {
            return _inventoryData.GetInventory();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void Post(InventoryModel item)
        {
            _inventoryData.SaveInventoryRecord(item);
        }
    }
}
