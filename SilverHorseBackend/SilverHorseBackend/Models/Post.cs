using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverHorseBackend.Models
{
    /// <summary>
    /// User blog entry
    /// </summary>
    public class Post 
    { 
        /// <summary>
        /// UID of Associated user
        /// </summary>
        public int userId { get; set; }

        /// <summary>
        /// Unique ID (UID) of this record
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Title of this blog post entry
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// The text the user entered for this blog post
        /// </summary>
        public string body { get; set; }
    }
}