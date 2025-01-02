using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_project.Models
{
    [Table("Feedbacks")]
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackId { get; set; }
        [Required]
        public string? Content { get; set; }
        [DisplayName("Creation Date")]
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
}
