using System.ComponentModel.DataAnnotations;

namespace Exercice05.Models
{
    public class Marmoset
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Color { get; set; }

        [Range(0, 50)]
        public int Age { get; set; }
    }
}
