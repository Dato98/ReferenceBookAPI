using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs.Person
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string NameGeo { get; set; }
        public string NameEng { get; set; }
        public string SurnameGeo { get; set; }
        public string SurnameEng { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
        public string Thumb { get; set; }
        public string LinkType { get; set; }
        public List<string> ContactInformation { get; set; }
    }
}
