using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilverHorseBackend.Models
{
    /// <summary>
    /// Postal address record
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Street address
        /// </summary>
        public string street { get; set; }
        
        /// <summary>
        /// Corporate unit address 
        /// </summary>
        public string suite { get; set; }

        /// <summary>
        /// City 
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// Poscode / Zipcode
        /// </summary>
        public string zipcode { get; set; }

        /// <summary>
        /// Geographic GPS coordinate data
        /// </summary>
        public Geo geo = new Geo();
    }

    public class Geo
    {
        /// <summary>
        /// GPS coordinate for latitude
        /// </summary>
        public double lat { get; set; }

        /// <summary>
        /// GPS coordinate for longitude
        /// </summary>
        public double lng { get; set; }
    }

    public class Company
    {
        /// <summary>
        /// Company name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Super duper sales phrase
        /// </summary>
        public string catchPhrase { get; set; }

        /// <summary>
        /// Ummm bs, yep every company has it ;)
        /// </summary>
        public string bs { get; set; }
    }

    public class User
    {
        /// <summary>
        /// Unique ID of this record (UID)
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Name of user
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Secondary name identifier for user
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Email address of user
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Address of user
        /// </summary>
        public Address address = new Address();

        /// <summary>
        /// Primary phone contact for user
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// Website URI if the user has one
        /// </summary>
        public string website { get; set; }

        /// <summary>
        /// The company this user fronts for
        /// </summary>
        public Company company = new Company();
    }
}