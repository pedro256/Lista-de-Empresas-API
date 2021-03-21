

namespace companyappapi.Models
{
    public class CompanyDBSettings : ICompanyDBSettings
    {
        public string CompanyCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface ICompanyDBSettings
    {
        string CompanyCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
