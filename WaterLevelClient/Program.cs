using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WaterLevelClient
{
    public class WaterLevel
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
    }

    public class WaterLevelDto
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }
    }



    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            string filePath = "C:\\Users\\admin\\Downloads\\water_level_data.json";

            string jsonContent = await File.ReadAllTextAsync(filePath);
            List<WaterLevelDto> waterLevelDtos = JsonSerializer.Deserialize<List<WaterLevelDto>>(jsonContent);

            List<WaterLevel> waterLevels = new List<WaterLevel>();
            foreach (var dto in waterLevelDtos)
            {
                DateTime date = DateTime.ParseExact(dto.Date, "yyyy.MM.dd", null);
                waterLevels.Add(new WaterLevel { Date = date, Value = dto.Value });
            }

            string apiUrl = "https://localhost:7265/api/WaterLevel/data";
            foreach (var waterLevel in waterLevels)
            {
                var json = JsonSerializer.Serialize(waterLevel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Successfully posted data for date: {waterLevel.Date}");
                }
                else
                {
                    Console.WriteLine($"Failed to post data for date: {waterLevel.Date}. Status code: {response.StatusCode}");
                }
            }
        }
    }
}
