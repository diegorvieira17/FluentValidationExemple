using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationExemple.Model
{
    public class Person
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool HasDiscount { get; set; }
        public decimal Discount { get; set; }
    }
}
