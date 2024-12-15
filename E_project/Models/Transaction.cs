using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_project.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [StringLength(300, ErrorMessage = "Picture URL cannot exceed 300 characters.")]
        public string? Image { get; set; }
        public DateTime CreateAt { get; set; }
        public int Success { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("CategoryId")]
        public Account? Account { get; set; }
        public int CardId { get; set; }
        [ForeignKey("CardId")]
        public Card? Card { get; set; }

    }
}
