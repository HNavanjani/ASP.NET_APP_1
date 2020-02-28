using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Helper;




namespace WebApplication1.Controllers
{
    public class UsersController : ApiController
    {
        IUserRepository _userRepository;
        public UsersController()
        {
            //because Dependancy injection is not used here
            _userRepository = new UserRepository(ConfigurationHelper.getConnectionString());
        }

        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult Get()
        {
            return Ok(_userRepository.GetUsers());
        }
        [HttpGet]
        [Route("api/users/{id}")]
        public IHttpActionResult Get([FromUri]int id)
        {
            return Ok(_userRepository.GetUser(id));
        }
        [HttpPost]
        [Route("api/users")]
        public IHttpActionResult Post([FromBody]User user)
        {
            return Ok(_userRepository.SaveUser(user));
        }

        [HttpDelete]
        [Route("api/users/{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            return Ok(_userRepository.DeleteUser(id));
        }
    }

    /*
    // GET api/<controller>
    public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
    */
}