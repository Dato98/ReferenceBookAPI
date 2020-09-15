using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs.Person;
using BLL.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReferenceBookAPI.Validation;

namespace ReferenceBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IPersonOperations personOperations;
        
        public PersonController(IHostingEnvironment hostingEnvironment,IPersonOperations personOperations)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.personOperations = personOperations;
        }

        [HttpGet("GetPersonList/{property}/{value}/{page}/{sortorder}")]
        public ActionResult<IEnumerable<PersonDTO>> GetPersonList(string property,string value,int page,string sortorder)
        {
            var lst = personOperations.GetList(property, value, page, sortorder);
            if(lst == null)
            {
                return NotFound();
            }
            return Ok(lst);
        }

        [HttpGet("GetPersonDetails/{Id}")]
        public ActionResult<PersonDTO> GetPersonDetails(int Id)
        {
            PersonDTO person = personOperations.GetDetailedInformation(Id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        [HttpGet("GetLinkedPeople/{Id}")]
        public ActionResult<IEnumerable<PersonDTO>> GetLinkedPeople(int Id)
        {
            var lst = personOperations.GetLinkedPeople(Id);
            if (lst == null)
                return NotFound();
            return Ok(lst);
        }

        [HttpPost("AddLinkedPerson/{Id}/{linktypeId}")]
        public ActionResult AddLinkedPerson(int Id,int linktypeId,[FromBody]PersonFormDTO person)
        {
            personOperations.AddLinkedPerson(Id, linktypeId, person);
            return Ok();
        }

        [HttpPost("CreatePerson")]
        public ActionResult CreatePerson([FromBody]PersonFormDTO model)
        {
            PersonValidator validator = new PersonValidator();
            ValidationResult validationResult = validator.Validate(model); 
            if(validationResult.IsValid)
            {
                model.Thumb = UploadFile(model.Picture);
                personOperations.Create(model);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("UpdatePerson")]
        public ActionResult UpdatePerson([FromBody]PersonFormDTO model)
        {
            PersonValidator validator = new PersonValidator();
            ValidationResult validationResult = validator.Validate(model);
            if (validationResult.IsValid)
            {
                string thumb = UploadFile(model.Picture);
                model.Thumb = string.IsNullOrEmpty(thumb) ? model.Thumb : thumb;
                personOperations.Edit(model);
                return Ok();
            }
            return BadRequest();
        }




        private string GenerateFileDirectoryName()
        {
            return $"{DateTime.Now.Year}/{DateTime.Now.Month}/";
        }

        private void checkAndCreateDirectory(string path)
        {
            bool exists = Directory.Exists(Path.Combine(hostingEnvironment.WebRootPath, path));
            if (!exists)
            {
                Directory.CreateDirectory(Path.Combine(hostingEnvironment.WebRootPath, path));
            }
        }

        private string FileVersionCheckAndUpdate(string filename, string path, string ext)
        {
            int count = 1;
            string newFilename = filename;
            string newPath = Path.Combine(path, filename + ext);
            while (System.IO.File.Exists(Path.Combine(hostingEnvironment.WebRootPath, newPath)))
            {
                newFilename = String.Format("{0}({1})", filename, count++);
                newPath = Path.Combine(path, newFilename + ext);
            }
            return newFilename;
        }

        private string UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string name = Path.GetFileNameWithoutExtension(file.FileName);
                string ext = Path.GetExtension(file.FileName);
                string fileDirectoryName = GenerateFileDirectoryName();
                checkAndCreateDirectory($"Storage/{fileDirectoryName}");
                name = FileVersionCheckAndUpdate(name, $"Storage/{fileDirectoryName}", ext);
                var path = Path.Combine(hostingEnvironment.WebRootPath, "Storage", fileDirectoryName + name + ext);

                using (var stream = System.IO.File.Create(path))
                {
                    file.CopyTo(stream);
                }
                return Path.Combine("Storage", fileDirectoryName + name + ext);
            }
            return String.Empty;
        }
    }
}