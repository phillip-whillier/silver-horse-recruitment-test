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
    public class AlbumControllerTest: BaseTest
    {

        [TestMethod]
        public void TestAlbumGetAll()
        {
            var albumController = new AlbumController();
            albumController.MoqResponse = new RestMoq(HttpStatusCode.OK, getResourceText("albums.json"));
            IEnumerable<Album> result = albumController.GetAll();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 100);
            Assert.IsNotNull(result.ToArray()[0].id);
        }

        [TestMethod]
        public void TestAlbumGetSingleRecordSuccess()
        {
            var albumController = new AlbumController();
            albumController.MoqResponse = new RestMoq(HttpStatusCode.OK, getResourceText("album.json"));
            OkNegotiatedContentResult<Album> result = (OkNegotiatedContentResult<Album>)albumController.GetById(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.id == 1);
        }

        [TestMethod]
        public void TestAlbumGetSingleRecordFails()
        {
            var albumController = new AlbumController();
            albumController.MoqResponse = new RestMoq(HttpStatusCode.NotFound, "");
            NotFoundResult result = (NotFoundResult)albumController.GetById(111);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestAlbumDeleteSuccess()
        {
            var albumController = new AlbumController();
            albumController.MoqResponse = new RestMoq(HttpStatusCode.OK, "{}");
            OkNegotiatedContentResult<string> result = (OkNegotiatedContentResult<string>)albumController.Delete(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content == "{}");
        }

        [TestMethod]
        public void TestAlbumDeleteFails()
        {
            var albumController = new AlbumController();
            albumController.MoqResponse = new RestMoq(HttpStatusCode.NotFound, "");
            NotFoundResult result = (NotFoundResult)albumController.Delete(1);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void TestAlbumInsertSuccess()
        {
            var albumController = new AlbumController();
            albumController.MoqResponse = new RestMoq(System.Net.HttpStatusCode.Created, getResourceText("curesponse.json"));
            Album album = new Album();
            album.title = "1234";
            OkNegotiatedContentResult<CreateUpdateResponse> result = (OkNegotiatedContentResult<CreateUpdateResponse>)albumController.Post(album);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.id != 0);
        }

        [TestMethod]
        public void TestAlbumInsertFails()
        {
            var albumController = new AlbumController();
            albumController.MoqResponse = new RestMoq(System.Net.HttpStatusCode.Conflict, getResourceText("curesponse.json"));
            Album album = new Album();
            album.title = "1234";
            ConflictResult result = (ConflictResult)albumController.Post(album);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestAlbumUpdateSuccess()
        {
            var albumController = new AlbumController();
            albumController.MoqResponse = new RestMoq(System.Net.HttpStatusCode.OK, getResourceText("curesponse.json"));
            Album album = new Album();
            album.id = 1;
            album.title = "1234";
            OkNegotiatedContentResult<CreateUpdateResponse> result = (OkNegotiatedContentResult<CreateUpdateResponse>)albumController.Put(1, album);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.id != 0);
        }

        [TestMethod]
        public void TestAlbumUpdateFails()
        {
            var albumController = new AlbumController();
            albumController.MoqResponse = new RestMoq(System.Net.HttpStatusCode.NotFound, getResourceText("curesponse.json"));
            Album album = new Album();
            album.id = 1;
            album.title = "1234";
            NotFoundResult result = (NotFoundResult)albumController.Put(1, album);
            Assert.IsNotNull(result);
        }

    }
}
