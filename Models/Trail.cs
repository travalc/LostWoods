using System.ComponentModel.DataAnnotations;

namespace LostWoods.Models
{
    public abstract class BaseEntity {}

    public class Trail : BaseEntity
    {
        [Key]
        public int id {get; set;}
        [Required]
        public string name {get; set;}
        [Required]
        [MinLength(10)]
        public string description {get; set;}
        [Required]
        [RegularExpression(@"^[+-]?([0-9]*[.])?[0-9]+$")]
        public double length {get; set;}
        [Required]
        [RegularExpression(@"^\d+$")]
        public int elevationChange {get; set;}
        [Required]
        [RegularExpression(@"^[+-]?([0-9]*[.])?[0-9]+$")]
        public double latitude {get; set;}
        [Required]
        [RegularExpression(@"^[+-]?([0-9]*[.])?[0-9]+$")]
        public double longitude {get; set;}

    }
}


