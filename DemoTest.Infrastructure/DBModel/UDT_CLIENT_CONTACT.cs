using EntityFrameworkExtras.EF6;
using System;

namespace DemoTest.Infrastructure.DBModel
{
    [UserDefinedTableType("UDT_CLIENT_CONTACT")]
    public class UDT_CLIENT_CONTACT
    {
        [UserDefinedTableTypeColumn(1)]
        public int Id { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public int ClientId { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public int BusinessAreaTypeId { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public string ContactName { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public string Designation { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public string PhoneNo { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public string FaxNo { get; set; }

        [UserDefinedTableTypeColumn(8)]
        public string EmailId { get; set; }

        [UserDefinedTableTypeColumn(9)]
        public int UpdatedBy { get; set; }

        [UserDefinedTableTypeColumn(10)]
        public DateTime? UpdatedAt { get; set; }

        [UserDefinedTableTypeColumn(11)]
        public string CreatedBy { get; set; }

        [UserDefinedTableTypeColumn(12)]
        public DateTime? CreatedAt { get; set; }

    }
}
