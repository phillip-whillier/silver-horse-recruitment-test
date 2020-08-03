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
    public class PostControllerTest : BaseTest
    {

        [TestMethod]
        public void TestPostGetAll()
        {
            var postController = new PostController();
            postController.MoqResponse = new RestMoq(HttpStatusCode.OK, getResourceText("posts.json"));
            IEnumerable<Post> result = postController.GetAll();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 100);
            Assert.IsNotNull(result.ToArray()[0].id);
        }

        [TestMethod]
        public void TestPostGetSingleRecordSuccess()
        {
            var postController = new PostController();
            postController.MoqResponse = new RestMoq(HttpStatusCode.OK, getResourceText("post.json"));
            OkNegotiatedContentResult<Post> result = (OkNegotiatedContentResult<Post>)postController.GetById(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.id == 1);
        }

        [TestMethod]
        public void TestPostGetSingleRecordFails()
        {
            var postController = new PostController();
            postController.MoqResponse = new RestMoq(HttpStatusCode.NotFound, "");
            NotFoundResult result = (NotFoundResult)postController.GetById(111);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestPostDeleteSuccess()
        {
            var postController = new PostController();
            postController.MoqResponse = new RestMoq(HttpStatusCode.OK, "{}");
            OkNegotiatedContentResult<string> result = (OkNegotiatedContentResult<string>)postController.Delete(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content == "{}");
        }

        [TestMethod]
        public void TestPostDeleteFails()
        {
            var postController = new PostController();
            postController.MoqResponse = new RestMoq(HttpStatusCode.NotFound, "");
            NotFoundResult result = (NotFoundResult)postController.Delete(1);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void TestPostInsertSuccess()
        {
            var postController = new PostController();
            postController.MoqResponse = new RestMoq(System.Net.HttpStatusCode.Created, getResourceText("curesponse.json"));
            Post post = new Post();
            post.title = "1234";
            OkNegotiatedContentResult<CreateUpdateResponse> result = (OkNegotiatedContentResult<CreateUpdateResponse>)postController.Post(post);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.id != 0);
        }

        [TestMethod]
        public void TestPostInsertFails()
        {
            var postController = new PostController();
            postController.MoqResponse = new RestMoq(System.Net.HttpStatusCode.Conflict, getResourceText("curesponse.json"));
            Post post = new Post();
            post.title = "1234";
            ConflictResult result = (ConflictResult)postController.Post(post);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestPostUpdateSuccess()
        {
            var postController = new PostController();
            postController.MoqResponse = new RestMoq(System.Net.HttpStatusCode.OK, getResourceText("curesponse.json"));
            Post post = new Post();
            post.id = 1;
            post.title = "1234";
            OkNegotiatedContentResult<CreateUpdateResponse> result = (OkNegotiatedContentResult<CreateUpdateResponse>)postController.Put(1, post);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.id != 0);
        }

        [TestMethod]
        public void TestPostUpdateFails()
        {
            var postController = new PostController();
            postController.MoqResponse = new RestMoq(System.Net.HttpStatusCode.NotFound, getResourceText("curesponse.json"));
            Post post = new Post();
            post.id = 1;
            post.title = "1234";
            NotFoundResult result = (NotFoundResult)postController.Put(1, post);
            Assert.IsNotNull(result);
        }

    }
}
