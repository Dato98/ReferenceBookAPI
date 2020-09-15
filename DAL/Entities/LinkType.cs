using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class LinkType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<LinkedPerson> linkedPeople { get; set; }
    }
}
