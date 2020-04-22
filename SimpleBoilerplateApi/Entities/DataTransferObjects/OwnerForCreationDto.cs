using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class OwnerForCreationDto
    {
        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "OwnerForCreationDto_Name_Required")]
        [StringLength(60, ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "OwnerForCreationDto_Name_StringLength")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "OwnerForCreationDto_DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "OwnerForCreationDto_Address_Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(ModelsResource), ErrorMessageResourceName = "OwnerForCreationDto_Address_StringLength")]
        public string Address { get; set; }
    }
}
