using DemoTest.Core.Model;
using DemoTest.Core.RepositoryInterface;
using DemoTest.Infrastructure.Data;
using DemoTest.Infrastructure.DBModel;
using DemoTest.Infrastructure.Utilities;
using EntityFrameworkExtras.EF6;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DemoTest.Infrastructure.Repository
{
    public class ProfileRepository : IProfile
    {
        EPTestEntities _entities;

        public bool Create(Profile profile)
        {
            try
            {
                _entities = new EPTestEntities();
                var procedure = new PROC_CLIENT_CREATE()
                {
                    ClientName = profile.ClientName,
                    CompanyType = profile.CompanyType,
                    FoundationYear = profile.FoundationYear,
                    TotalEmployees = profile.TotalEmployees,
                    City = profile.City,
                    Address = profile.Address,
                    PostCode = profile.PostCode,
                    ContactName = profile.ContactName,
                    Designation = profile.Designation,
                    PhoneNo = profile.PhoneNo,
                    FaxNo = profile.FaxNo,
                    EmailId = profile.EmailId,
                    WebSiteUrl = profile.WebSiteUrl,
                    BusinessSegmentId = profile.BusinessSegmentId,
                    UDT_CLIENT_CONTACT = GetLstClientContact(profile)
                };

                var result = _entities.Database.ExecuteStoredProcedure<string>(procedure);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<IEnumerable> GetMasterData()
        {
            try
            {
                var result = new EPTestEntities()
                    .MultipleResults("[dbo].[PROC_USER_GETMASTER]")
                    .With<BusinessSegment>()
                    .With<BusinessArea>()
                    .Execute();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<UDT_CLIENT_CONTACT> GetLstClientContact(Profile profile)
        {
            List<UDT_CLIENT_CONTACT> lstUdtClientContact = new List<UDT_CLIENT_CONTACT>();
            if (profile.lstClientContact != null && profile.lstClientContact.Count > 0)
            {
                lstUdtClientContact = profile.lstClientContact.Select(x => new UDT_CLIENT_CONTACT
                {
                    BusinessAreaTypeId = x.BusinessAreaTypeId,
                    ContactName = x.ContactName,
                    Designation = x.Designation,
                    PhoneNo = x.PhoneNo,
                    FaxNo = x.FaxNo,
                    EmailId = x.EmailId
                }).ToList();
            }
            return lstUdtClientContact;
        }
    }
}
