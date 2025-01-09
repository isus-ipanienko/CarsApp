using System.ComponentModel.DataAnnotations;

namespace CarsApp.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string? Brand { get; set; }

        [Required, StringLength(20)]
        public string? Model { get; set; }
    }
}
