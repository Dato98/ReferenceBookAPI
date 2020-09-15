using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class LinkedPerson
    {
        public int Id { get; set; }
        public int LinkTypeId { get; set; }
        public int PersonId { get; set; }
        public LinkType LinkType { get; set; }
        public Person Person { get; set; }
    }
}
