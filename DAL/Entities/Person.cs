using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string NameGeo { get; set; }
        public string NameEng { get; set; }
        public string SurnameGeo { get; set; }
        public string SurnameEng { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Thumb { get; set; }
        public ICollection<ContactInformation> ContactInformation { get; set; }
        public ICollection<LinkedPerson> LinkedPerson { get; set; }
    }
}
