
using Microsoft.Build.Framework;

using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace CRUD_EntityFramework.Models
{
    public class Category
    {
        
        [Key]  //used to apply increement on database
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? MainCategory { get; set; }
        public DateTime? CreatedDate { get; set; }=DateTime.Now;
    }
}
