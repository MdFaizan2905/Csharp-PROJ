
using Microsoft.AspNetCore.Mvc;
using ExcelDataApi.Services;
using ExcelDataApi.Models;
using System.Collections.Generic;

namespace ExcelDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly ExcelService _excelService;

        public ExcelController(ExcelService excelService)
        {
            _excelService = excelService;
        }

        [HttpGet]
        public ActionResult<List<ExcelData>> Get([FromQuery] string filter)
        {
            var data = _excelService.GetData(filter);
            return Ok(data);
        }
    }
}
