using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_project.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Category Name must be between 3 and 100 characters.")]
        [DisplayName("Category Name")]
        public string? CategoryName { get; set; }
        public bool Status { get; set; }
        public string? ParentCategory { get; set; }
        [DisplayName("Creation Date")]
        public DateTime? CreationDate { get; set; }
        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
