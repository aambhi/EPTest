using DemoTest.Controllers;
using DemoTest.Core.Model;
using DemoTest.Core.RepositoryInterface;
using DemoTest.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DemoTest.Tests
{
    [TestClass]
    public class ProfileTest
    {
        //private ProfileController _controller;
        private ProfileRepository _profilerepository = new ProfileRepository();

        [TestMethod]
        public void Test_Create()
        {
            try
            {
                //Arrange
                ProfileController _controller = new ProfileController(_profilerepository);

                var lstContact = new List<ClientContact>();
                lstContact.Add(new ClientContact { ContactName = "fitname", Designation = "fit desi", PhoneNo = "123456789", FaxNo = "1234567897", EmailId = "fit@fit.com", BusinessAreaTypeId = 1 });

                var profile = new Profile { ClientName = "Test1", CompanyType = "Type1", FoundationYear = "1995", TotalEmployees = "3", City = "Andheri", Address = "Vile Parle", PostCode = "400099", ContactName = "mock test 1", Designation = "engineer moq", EmailId = "ambikaprasad.gupta@northgateps.com", PhoneNo = "9987848971", FaxNo = "123456789", WebSiteUrl = "test.com", BusinessSegmentId = 2, lstClientContact = lstContact };

                //Act
                var result = (System.Web.Mvc.JsonResult)_controller.Create(profile);

                //Assert
                Assert.AreEqual("Successfully Registered. Email Sent", result.Data);
            }
            catch (System.Exception ex)
            {
                Assert.Fail("Unexpected exception thrown: " + ex.ToString());
            }
        }
    }
}
