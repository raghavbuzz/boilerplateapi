using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class OwnerForUpdateDto
    {
        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "OwnerForUpdateDto_Name_Required")]
        [StringLength(60, ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "OwnerForUpdateDto_Name_StringLength")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "OwnerForUpdateDto_DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "OwnerForUpdateDto_Address_Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "OwnerForUpdateDto_Address_StringLength")]
        public string Address { get; set; }
    }
}
