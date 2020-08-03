using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SilverHorseBackend.Models;

namespace SilverHorseBackend.Controllers
{
    public class CollectionController : ApiController
    {
        private int MAX_WANTED = 30;

        PostController postController = new PostController();
        AlbumController albumController = new AlbumController();
        UserController userController = new UserController();

        /// <summary>
        /// Set the Moq response for testing Post model
        /// </summary>
        public RestMoq PostMoq
        {
            set
            {
                postController.MoqResponse = value;
            }
        }

        /// <summary>
        /// Set the Moq response for testing Album model
        /// </summary>
        public RestMoq AlbumMoq
        {
            set
            {
                albumController.MoqResponse = value;
            }
        }

        /// <summary>
        /// Set the Moq response for testing User model
        /// </summary>
        public RestMoq UserMoq
        {
            set
            {
                userController.MoqResponse = value;
            }
        }


        /// <summary>
        /// Get an array of collections
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Collection> GetAll()
        {
            List<Collection> retVal = new List<Collection>();
            Post[] posts = postController.GetAll().ToArray();
            Album[] albums = albumController.GetAll().ToArray();
            User[] users = userController.GetAll().ToArray();
            for (int i = 0; i < MAX_WANTED; i++)
            {
                Random rnd = new Random();
                retVal.Add(
                    new Collection(
                        posts[rnd.Next(0, posts.Length)], 
                        albums[rnd.Next(0, albums.Length)], 
                        users[rnd.Next(0, users.Length)]
                    )
                );
            }
            return retVal;
        }
    }
}
