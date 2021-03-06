using System.ComponentModel.DataAnnotations;

namespace Abby_Web.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; }
        [Display(Name ="Display Order")]
        [Range(1,100,ErrorMessage ="Display Order should be less than 100!!!")]
        public int DisplayOrder { get; set; }
    }
}
