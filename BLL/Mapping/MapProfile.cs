using AutoMapper;
using BLL.DTOs.Person;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<PersonFormDTO, Person>();
            CreateMap<Person, PersonDTO>();
            CreateMap<LinkedPerson, PersonDTO>()
                .ForMember(dest => 
                dest.LinkType,
                opt => opt.MapFrom(src => src.LinkType.Type));

        }
    }
}
