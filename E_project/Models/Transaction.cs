﻿using System.ComponentModel.DataAnnotations;
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
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public Account? Account { get; set; }
        [ForeignKey("CardId")]
        public int CardId { get; set; }
        public Card? Card { get; set; }

        public ICollection<TransactionDetail> transactionDetails { get; set; } = new List<TransactionDetail>();

    }
}
