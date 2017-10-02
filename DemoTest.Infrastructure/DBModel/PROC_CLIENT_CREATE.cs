using EntityFrameworkExtras.EF6;
using System.Collections.Generic;

namespace DemoTest.Infrastructure.DBModel
{
    [StoredProcedure("PROC_CLIENT_CREATE")]
    public class PROC_CLIENT_CREATE
    {
        [StoredProcedureParameter(System.Data.SqlDbType.Int, ParameterName = "ClientId")]
        public int ClientId { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.NVarChar, ParameterName = "ClientName")]
        public string ClientName { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.NVarChar, ParameterName = "CompanyType")]
        public string CompanyType { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.NVarChar, ParameterName = "FoundationYear")]
        public string FoundationYear { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.NVarChar, ParameterName = "TotalEmployees")]
        public string TotalEmployees { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.NVarChar, ParameterName = "City")]
        public string City { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.NVarChar, ParameterName = "Address")]
        public string Address { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.NVarChar, ParameterName = "PostCode")]
        public string PostCode { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.NVarChar, ParameterName = "ContactName")]
        public string ContactName { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.NVarChar, ParameterName = "Designation")]
        public string Designation { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.NVarChar, ParameterName = "PhoneNo")]
        public string PhoneNo { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.NVarChar, ParameterName = "FaxNo")]
        public string FaxNo { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.NVarChar, ParameterName = "EmailId")]
        public string EmailId { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.NVarChar, ParameterName = "WebSiteUrl")]
        public string WebSiteUrl { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Int, ParameterName = "BusinessSegmentId")]
        public int BusinessSegmentId { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "CLIENT_CONTACT")]
        public List<UDT_CLIENT_CONTACT> UDT_CLIENT_CONTACT { get; set; }
    }
}
