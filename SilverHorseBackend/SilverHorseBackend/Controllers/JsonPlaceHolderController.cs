using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using SilverHorseBackend.Models;
using System.Configuration;

namespace SilverHorseBackend.Controllers
{
    /// <summary>
    /// Interface to JsonPlaceholder https://jsonplaceholder.typicode.com
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonPlaceHolderController<T> : ApiController
    {

        public List<T> dataList = new List<T>();
        private string classType;

        private string baseUrl = ConfigurationManager.AppSettings["jsonUrl"];
        private RestController restfulApi = new RestController();

        /// <summary>
        /// Set the Moq response for testing
        /// </summary>
        public RestMoq MoqResponse 
        { 
            set {
                restfulApi.MoqResponse = value;
            }
        }

        public JsonPlaceHolderController()
        {
            classType = typeof(T).Name.ToLower();
        }

        /// <summary>
        /// Gets all the data as an Array.
        /// </summary>
        public IEnumerable<T> GetAll()
        {
            return JsonConvert.DeserializeObject<List<T>>(restfulApi.handle(RestController.HttpMethod.GET, $"{baseUrl}/{classType}s"));
        }

        private T GetTById(int id)
        {
            T thisRecord = JsonConvert.DeserializeObject<T>(restfulApi.handle(RestController.HttpMethod.GET, $"{baseUrl}/{classType}s/{id}"));
            return thisRecord;
        }

        /// <summary>
        /// Gets a single record.
        /// </summary>
        /// <param name="id">The UID of the record.</param>
        public IHttpActionResult GetById(int id)
        {
            var record = GetTById(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        /// <summary>
        /// Create a new record
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public IHttpActionResult Post(T record)
        {
            string jsonValue =  restfulApi.handle(RestController.HttpMethod.POST, $"{baseUrl}/{classType}s", JsonConvert.SerializeObject(record));
            CreateUpdateResponse createUpdateResponse = JsonConvert.DeserializeObject<CreateUpdateResponse>(jsonValue);
            if (restfulApi.getResponse().StatusCode == System.Net.HttpStatusCode.Created)
            {
                return Ok(createUpdateResponse);
            }
            else
            {
                return Conflict();
            }
        }


        /// <summary>
        /// Updates an existing record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public IHttpActionResult Put(int id, T record)
        {
            string jsonValue = restfulApi.handle(RestController.HttpMethod.PUT, $"{baseUrl}/{classType}s/{id}", JsonConvert.SerializeObject(record));
            CreateUpdateResponse createUpdateResponse = JsonConvert.DeserializeObject<CreateUpdateResponse>(jsonValue);
            if (restfulApi.getResponse().StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(createUpdateResponse);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Deletes a single record
        /// </summary>
        /// <param name="record"></param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Delete(int id)
        {
            string retVal = restfulApi.handle(RestController.HttpMethod.DELETE, $"{baseUrl}/{classType}s/{id}");
            if (restfulApi.getResponse().StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(retVal);
            } 
            else
            {
                return NotFound();
            }
        }
    }
}
