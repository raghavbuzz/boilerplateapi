using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class OwnerDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public IEnumerable<AccountDto> Accounts {get; set;}
    }
}
