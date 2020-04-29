using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("AccountType")]
    public class AccountType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("AccountTypeId")]
        public long Id { get; set; }

        [Required()]
        [StringLength(10)]
        public string AccountTypeCode { get; set; }

        [Required()]
        [StringLength(50)]
        public string AccountTypeDescription { get; set; }

    }
}
