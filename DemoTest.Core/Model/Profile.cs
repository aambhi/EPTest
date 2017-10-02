using System.Collections.Generic;

namespace DemoTest.Core.Model
{
    public class Profile
    {
        public long Id { get; set; }
        public string ClientName { get; set; }
        public string CompanyType { get; set; }
        public string FoundationYear { get; set; }
        public string TotalEmployees { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string ContactName { get; set; }
        public string Designation { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string EmailId { get; set; }
        public string WebSiteUrl { get; set; }
        public int BusinessSegmentId { get; set; }
        public List<ClientContact> lstClientContact { get; set; }
    }

    public class ClientContact
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public int BusinessAreaTypeId { get; set; }
        public string ContactName { get; set; }
        public string Designation { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string EmailId { get; set; }
    }
}
