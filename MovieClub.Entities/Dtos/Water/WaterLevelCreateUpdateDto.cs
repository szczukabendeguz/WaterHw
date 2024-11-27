using System;

namespace Water.Entities.Dtos.WaterLevel
{
    public class WaterLevelCreateUpdateDto
    {
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }
}
