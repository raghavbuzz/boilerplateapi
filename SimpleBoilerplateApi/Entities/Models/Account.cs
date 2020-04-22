using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("AccountId")]
        public long Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "Account_DateCreated")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "Account_AccountType")]
        public string AccountType { get; set; }

        [ForeignKey(nameof(Owner))]
        public long OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
