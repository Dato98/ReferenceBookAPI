using BLL.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IPersonOperations
    {
        void Create(PersonFormDTO model);
        void Edit(PersonFormDTO model);
        void Delete(int Id);
        PersonDTO GetDetailedInformation(int Id);
        List<PersonDTO> GetList(string Property, string Value, int page, string sortOrder);
        List<PersonDTO> GetLinkedPeople(int Id);
        void AddLinkedPerson(int Id, int linkTypeId, PersonFormDTO person);
    }
}
