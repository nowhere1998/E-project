using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_project.Models
{
    [Table("TransactionDetails")]
    public class TransactionDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionDetailId { get; set; }

        [DisplayName("Destination Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(250, ErrorMessage = "Email cannot exceed 250 characters.")]
        [Required]
        public string DestinationEmail { get; set; }
        [ForeignKey("TransactionId")]
        public int TransactionId { get; set; }
        public Transaction? Transaction { get; set; }
        public bool Status { get; set; }
    }
}
