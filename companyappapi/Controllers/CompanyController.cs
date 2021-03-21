
using companyappapi.Models;
using companyappapi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace companyappapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyServices _companyServices;

        public CompanyController(CompanyServices compService)
        {
            _companyServices = compService;
        }

        [HttpGet]
        public ActionResult<List<Company>> Get() =>
            _companyServices.Get();

        [HttpGet("{id:length(24)}", Name = "GetCompany")]
        public ActionResult<Company> Get(string id)
        {
            var company = _companyServices.Get(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        [HttpPost]
        public ActionResult<Company> Create(Company company)
        {
           _companyServices.Create(company);

            return CreatedAtRoute("GetCompany", new { id = company.Id.ToString() }, company);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id,Company companyIn)
        {
            var company = _companyServices.Get(id);

            if (company == null)
            {
                return NotFound();
            }

            _companyServices.Update(id, companyIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var company = _companyServices.Get(id);

            if (company == null)
            {
                return NotFound();
            }

            _companyServices.Remove(company.Id.ToString());

            return NoContent();
        }
    }
}
