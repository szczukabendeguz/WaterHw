using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Water.Entities.Helpers;


namespace Water.Entities
{
    public class WaterLevel : IIdEntity
    {
        public WaterLevel(DateTime date, int value)
        {
            Id = Guid.NewGuid().ToString();
            Date = date;
            Value = value;
        }

        [StringLength(50)]
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public int Value { get; set; }
    }
}
