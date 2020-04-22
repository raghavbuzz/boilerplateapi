using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class AccountDto
    {
        public long Id { get; set; }        
        public DateTime DateCreated { get; set; }        
        public string AccountType { get; set; }                
    }
}
