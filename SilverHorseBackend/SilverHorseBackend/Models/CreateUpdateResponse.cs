using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverHorseBackend.Models
{
    /// <summary>
    /// Return value from Put or Post REST API Methods
    /// </summary>
    public class CreateUpdateResponse
    {
        /// <summary>
        /// Returned ID from a Put or Post method
        /// </summary>
        public int id { get; set; }

    }
}