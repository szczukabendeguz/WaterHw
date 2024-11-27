using Microsoft.AspNetCore.Mvc;
using Water.Entities.Dtos.WaterLevel;
using Water.Logic.Logic;
using System.Globalization;

namespace Water.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterLevelController : ControllerBase
    {
        private readonly WaterLevelLogic _waterLevelLogic;

        public WaterLevelController(WaterLevelLogic waterLevelLogic)
        {
            _waterLevelLogic = waterLevelLogic;
        }

        [HttpPost]
        [Route("data")]
        public IActionResult PostWaterLevel([FromBody] WaterLevelCreateUpdateDto dto)
        {
            try
            {
                _waterLevelLogic.AddWaterLevel(dto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("data")]
        public IActionResult GetWaterLevelStatistics()
        {
            var waterLevels = _waterLevelLogic.GetAllWaterLevels();

            var groupedData = waterLevels
                .GroupBy(wl => wl.Date.ToString("yyyy.MM"))
                .Select(g => new
                {
                    Month = g.Key,
                    AverageValue = g.Average(wl => wl.Value),
                    MinimalValue = g.Min(wl => wl.Value),
                    MaximalValue = g.Max(wl => wl.Value)
                })
                .ToList();

            return Ok(groupedData);
        }
    }
}
