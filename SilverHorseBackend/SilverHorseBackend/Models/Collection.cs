using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SilverHorseBackend;

namespace SilverHorseBackend.Models
{
    public class Collection
    {
        /// <summary>
        /// Post entry for the collection record
        /// </summary>
        public Post post = null;

        /// <summary>
        /// Album entry for the collection record
        /// </summary>
        public Album album = null;

        /// <summary>
        /// User entry for the collection record
        /// </summary>
        public User user = null;

        public Collection(Post p, Album a, User u)
        {
            post = p;
            album = a;
            user = u;
        }
    }
}