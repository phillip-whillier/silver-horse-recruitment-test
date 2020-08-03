using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverHorseBackend.Models
{
    public class Album
    {
        /// <summary>
        /// Unique ID or user (UID)
        /// </summary>
        public int userId { get; set; }

        /// <summary>
        /// Primary key of this Album
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Title of the Album
        /// </summary>
        public string title { get; set; }
    }
}