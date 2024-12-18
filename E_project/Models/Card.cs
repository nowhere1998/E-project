using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_project.Models
{
    [Table("Cards")]
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; set; }

        [Required(ErrorMessage = "Card Name is required.")]
        [DisplayName("Card Name")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Card Name must be between 3 and 200 characters.")]
        public string? CardName { get; set; }
        public bool Status { get; set; }

        [StringLength(300, ErrorMessage = "Picture URL cannot exceed 300 characters.")]
        public string? Image { get; set; }
        public DateTime CreateAt { get; set; }
        public string? Description { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
