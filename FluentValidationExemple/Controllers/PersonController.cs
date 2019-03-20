using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidationExemple.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationExemple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IValidator<Person> _personValidator;

        public PersonController(IValidator<Person> personValidator)
        {
            _personValidator = personValidator;
        }

        [HttpPost("PostWithFluentValidate")]
        public List<string> PostWithFluentValidate([FromBody] Person person)
        {
            List<string> response = new List<string>();

            var validationresult = _personValidator.Validate(person);

            if (!validationresult.IsValid)
            {
                foreach (var error in validationresult.Errors)
                {
                    response.Add(error.ToString());
                }
            }
            else
            {
                response.Add("All is OK.");
            }

            return response;
        }
    }
}