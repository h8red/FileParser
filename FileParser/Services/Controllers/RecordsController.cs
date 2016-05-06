using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using FileParser;

using Newtonsoft.Json;
using System.Runtime.Caching;

namespace Services.Controllers
{
    public class RecordsController : ApiController
    {        
        ObjectCache cache = MemoryCache.Default;
        
        
        // GET: api/Records/gender
        [Route("api/records/gender")]
        public string GetGender()
        {
            List<User> myUsers = cache.Get("CachedUsers") as List<User>;
            if (myUsers == null)
            {
                myUsers = new List<FileParser.User>();
            }

            return JsonConvert.SerializeObject((from u in myUsers orderby u.Gender ascending, u.LastName ascending select u).ToList());
        }

        // GET: api/Records/birthdate 
        [Route("api/records/birthdate")]
        public string GetDob()
        {
            List<User> myUsers = cache.Get("CachedUsers") as List<User>;
            if (myUsers == null)
            {
                myUsers = new List<FileParser.User>();
            }

            var v = (from i in myUsers orderby i.DOB ascending select i).ToList();
            if(v.Any())
            {
                return JsonConvert.SerializeObject(v);
            }

            return null;
        }

        //GET: api/Records/name
        [Route("api/records/name")]
        public string GetName()
        {
            List<User> myUsers = cache.Get("CachedUsers") as List<User>;
            if (myUsers == null)
            {
                myUsers = new List<FileParser.User>();
            }

            return JsonConvert.SerializeObject((from i in myUsers orderby i.LastName descending select i).ToList());
        }

        // POST: api/Records
        public void Post([FromBody]string value)
        {
            if(value == null)
            {
                return;
            }

            // get the cached User List
            List<User> myUsers = cache.Get("CachedUsers") as List<User>;
            if(myUsers == null)
            {
                myUsers = new List<FileParser.User>();
            }

            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddYears(1);// keep it for a year

            if(value.Contains("|"))
            {
                MyParser parser = new MyParser(new PipeParser(), value);                
                myUsers.AddRange(parser.myUsers);
                cache.Set("CachedUsers", myUsers, policy);                
            }
            else if(value.Contains(","))
            {
                MyParser parser = new MyParser(new CSVParser(), value);
                myUsers.AddRange(parser.myUsers);
                cache.Set("CachedUsers", myUsers, policy);
            }
            else if(value.Contains(" "))
            {
                MyParser parser = new MyParser(new SpaceParser(), value);
                myUsers.AddRange(parser.myUsers);
                cache.Set("CachedUsers", myUsers, policy);
            }

        }

        
    }
}
