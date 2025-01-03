﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_project.Models
{
    [Table("Subcribes")]
    public class Subcribe
    {
        public int SubcribeId { get; set; }
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(250, ErrorMessage = "Email cannot exceed 250 characters.")]
        [Required]
        public string? Email { get; set; }
        [Column(TypeName = "ntext")]
        public string? Content { get; set; } = string.Empty;
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
}
