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
        public DateTime CreateAt { get; set; }
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
}
