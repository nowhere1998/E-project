using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_project.Models
{
    public class PaymentHistory
    {
        [Key]
        public int PaymentHistoryId { get; set; }
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public double Amount { get; set; }
        public bool PaymentType { get; set; }
    }
}
