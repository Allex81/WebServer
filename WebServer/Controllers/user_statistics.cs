using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models;

namespace WebServer.Controllers
{
    [ApiController]
    [Route("report/user_statistics")]
    public class user_statistics : Controller
    {
        private DatabaseContext _dbc;
        public user_statistics (DatabaseContext dbc)
        {
            _dbc = dbc;
        }
       
        [HttpGet]
        public IEnumerable<string> Get() 
        {
            var users = _dbc.Queries.Select(u => u.QueryGuid).ToArray();
            return users;
        }

        [HttpGet("{id}")]
         public string Get(int id) 
        {
            return _dbc.Queries.Find(id).QueryGuid;
        }
        [HttpPost]
        public async Task<string> Post(string name, DateTime dateBegin, DateTime dateEnd)
        {
            Query query = new Query();//Собираем информацию из запроса и сохраняем её
            string guid = Guid.NewGuid().ToString();
            query.UserName = name;
            query.QueryGuid = guid;
            query.StartsAt = DateTime.Now;
            query.Result = "NULL";
            query.DateBegin = dateBegin;
            query.DateEnd = dateEnd;

            _dbc.Queries.Add(query);
            _dbc.SaveChanges();
            return guid;
        }
      /*  [HttpPut("{id}")]
        public void Put (int id, [FromBody] string value)
        {
            Query user = _dbc.Queries.Find(id);
            user.QueryGuid = value;
            _dbc.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Query user = _dbc.Queries.Find(id);
            _dbc.Queries.Remove(user);
            _dbc.SaveChanges();
        }*/
       
    }
}
