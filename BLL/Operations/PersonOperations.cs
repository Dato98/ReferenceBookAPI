using AutoMapper;
using BLL.DTOs.Person;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Operations
{
    public class PersonOperations : IPersonOperations
    {
        private readonly IUOW services;
        private readonly IMapper mapper;

        public PersonOperations(IUOW uOW,IMapper mapper)
        {
            services = uOW;
            this.mapper = mapper;
        }

        public void AddLinkedPerson(int Id, int linkTypeId, PersonFormDTO person)
        {
            Person dbModel = mapper.Map<PersonFormDTO,Person>(person);
            services.PersonRepository.AddLinkedPerson(Id, linkTypeId, dbModel);
        }

        public void Create(PersonFormDTO model)
        {
            Person dbModel = mapper.Map<PersonFormDTO, Person>(model);
            services.PersonRepository.Create(dbModel);
            services.Commit();
        }

        public void Delete(int Id)
        {
            Person dbModel = services.PersonRepository.Get(Id);
            if (dbModel != null)
            {
                services.PersonRepository.Delete(dbModel);
                services.Commit();
            }
        }

        public void Edit(PersonFormDTO model)
        {
            Person dbModel = services.PersonRepository.Get(model.Id);
            if (dbModel != null)
            {
                mapper.Map<PersonFormDTO, Person>(model, dbModel);
                services.PersonRepository.Update(dbModel);
                services.Commit();
            }
        }

        public PersonDTO GetDetailedInformation(int Id)
        {
            Person dbModel = services.PersonRepository.GetDetailedInformation(Id);
            if(dbModel == null)
                return null;
            return mapper.Map<PersonDTO>(dbModel);
        }

        public List<PersonDTO> GetLinkedPeople(int Id)
        {
            return mapper.Map<List<PersonDTO>>(services.PersonRepository.GetPersonLinkedPeople(Id));
        }

        public List<PersonDTO> GetList(string Property, string Value, int page, string sortOrder)
        {
            Expression<Func<Person, bool>> expression = null;
            switch (Property)
            {
                case "NameGeo":
                    expression = x => x.NameGeo.Contains(Value);
                    break;
                case "NameEng":
                    expression = x => x.NameEng.Contains(Value);
                    break;
                case "SurnameGeo":
                    expression = x => x.SurnameGeo.Contains(Value);
                    break;
                case "SurnameEng":
                    expression = x => x.SurnameEng.Contains(Value);
                    break;
                case "Address":
                    expression = x => x.Address.Contains(Value);
                    break;
            }
            var lst = services.PersonRepository.FindByCondition(expression, sortOrder, page);
            return mapper.Map<List<PersonDTO>>(lst);
        }
    }
}
