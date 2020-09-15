using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace BLL.DTOs.Person
{
    public class PersonFormDTO
    {
        public int Id { get; set; }
        [Required]
        public string NameGeo { get; set; }
        [Required]
        public string NameEng { get; set; }
        [Required]
        public string SurnameGeo { get; set; }
        [Required]
        public string SurnameEng { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Address { get; set; }

        public string Thumb { get; set; }
        public IFormFile Picture { get; set; }
        public List<string> ContactInformation { get; set; }
        public List<int> LinkedPerson { get; set; }
    }
}
