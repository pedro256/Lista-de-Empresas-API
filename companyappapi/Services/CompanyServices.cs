using companyappapi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace companyappapi.Services
{
    public class CompanyServices
    {
        private readonly IMongoCollection<Company> _company;

        public CompanyServices(ICompanyDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _company = database.GetCollection<Company>("company");
        }

        public List<Company> Get() =>
            _company.Find(book => true).ToList();

        public Company Get(string id) =>
            _company.Find<Company>(company => company.Id == id).FirstOrDefault();

        public Company Create(Company company)
        {
            _company.InsertOne(company);
            return company;
        }

        public void Update(string id, Company companyIn) =>
            _company.ReplaceOne(book => book.Id == id, companyIn);

        public void Remove(Company companyIn) =>
            _company.DeleteOne(comp => comp.Id == companyIn.Id);

        public void Remove(string id) =>
            _company.DeleteOne(company => company.Id == id);
    }
}
