using System.ComponentModel.DataAnnotations;

namespace Supermaket.Resources
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        
    }
}
