using System;
using System.Collections.Generic;

namespace project.Models
{
    public partial class Actor
    {
        public long Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CountryCode { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string GetName1()
        {
            return FirstName + LastName;
        }

        public string GetName2 => FirstName + LastName;
    }
}