using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilverHorseBackend.Controllers;
using SilverHorseBackend.Models;

namespace SilverHorseBackend.Tests.Controllers
{
    [TestClass]
    public class CollectionControllerTest : BaseTest
    {

        [TestMethod]
        public void TestCollectionGetAll()
        {
            var collectionController = new CollectionController();
            collectionController.UserMoq = new RestMoq(HttpStatusCode.OK, getResourceText("users.json"));
            collectionController.PostMoq = new RestMoq(HttpStatusCode.OK, getResourceText("posts.json"));
            collectionController.AlbumMoq = new RestMoq(HttpStatusCode.OK, getResourceText("albums.json"));
            IEnumerable<Collection> result = collectionController.GetAll();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 30);
        }
    }
}
