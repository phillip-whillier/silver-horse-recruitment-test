using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilverHorseBackend.Controllers;
using SilverHorseBackend.Models;

namespace SilverHorseBackend.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest : BaseTest
    {

        [TestMethod]
        public void TestUserGetAll()
        {
            var userController = new UserController();
            userController.MoqResponse = new RestMoq(HttpStatusCode.OK, getResourceText("users.json"));
            IEnumerable<User> result = userController.GetAll();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 10);
            Assert.IsNotNull(result.ToArray()[0].id);
        }

        [TestMethod]
        public void TestUserGetSingleRecordSuccess()
        {
            var userController = new UserController();
            userController.MoqResponse = new RestMoq(HttpStatusCode.OK, getResourceText("user.json"));
            OkNegotiatedContentResult<User> result = (OkNegotiatedContentResult<User>)userController.GetById(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.id == 1);
        }

        [TestMethod]
        public void TestUserGetSingleRecordFails()
        {
            var userController = new UserController();
            userController.MoqResponse = new RestMoq(HttpStatusCode.NotFound, "");
            NotFoundResult result = (NotFoundResult)userController.GetById(111);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestUserDeleteSuccess()
        {
            var userController = new UserController();
            userController.MoqResponse = new RestMoq(HttpStatusCode.OK, "{}");
            OkNegotiatedContentResult<string> result = (OkNegotiatedContentResult<string>)userController.Delete(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content == "{}");
        }

        [TestMethod]
        public void TestUserDeleteFails()
        {
            var userController = new UserController();
            userController.MoqResponse = new RestMoq(HttpStatusCode.NotFound, "");
            NotFoundResult result = (NotFoundResult)userController.Delete(1);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void TestUserInsertSuccess()
        {
            var userController = new UserController();
            userController.MoqResponse = new RestMoq(System.Net.HttpStatusCode.Created, getResourceText("curesponse.json"));
            User user = new User();
            user.name = "Mary Dunnit";
            OkNegotiatedContentResult<CreateUpdateResponse> result = (OkNegotiatedContentResult<CreateUpdateResponse>)userController.Post(user);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.id != 0);
        }

        [TestMethod]
        public void TestUserInsertFails()
        {
            var userController = new UserController();
            userController.MoqResponse = new RestMoq(System.Net.HttpStatusCode.Conflict, getResourceText("curesponse.json"));
            User user = new User();
            user.name = "Joe Bloggs";
            ConflictResult result = (ConflictResult)userController.Post(user);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestUserUpdateSuccess()
        {
            var userController = new UserController();
            userController.MoqResponse = new RestMoq(System.Net.HttpStatusCode.OK, getResourceText("curesponse.json"));
            User user = new User();
            user.id = 1;
            user.name = "Joe Bloggs";
            OkNegotiatedContentResult<CreateUpdateResponse> result = (OkNegotiatedContentResult<CreateUpdateResponse>)userController.Put(1, user);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.id != 0);
        }

        [TestMethod]
        public void TestUserUpdateFails()
        {
            var userController = new UserController();
            userController.MoqResponse = new RestMoq(System.Net.HttpStatusCode.NotFound, getResourceText("curesponse.json"));
            User user = new User();
            user.id = 1;
            user.name = "Joe Bloggs";
            NotFoundResult result = (NotFoundResult)userController.Put(1, user);
            Assert.IsNotNull(result);
        }

    }
}
