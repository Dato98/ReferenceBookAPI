using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ContactInformation
    {
        public int Id { get; set; }
        public string Information { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
