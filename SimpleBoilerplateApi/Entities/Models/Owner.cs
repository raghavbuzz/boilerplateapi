using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Owner")]
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("OwnerId")]
        public long Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "Owner_Name_Required")]
        [StringLength(60, ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "Owner_Name_StringLength")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "Owner_DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "Owner_Address_Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "Owner_Address_StringLength")]
        public string Address { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
