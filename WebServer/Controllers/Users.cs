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
    [Route("api/Users")]
    public class Users : Controller
    {
        private DatabaseContext _dbc;
        public Users(DatabaseContext dbc)
        {
            _dbc = dbc;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var users = _dbc.Users.Select(u => u.UserName).ToArray();
            return users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _dbc.Users.Find(id);
        }
        [HttpPost]
        public async Task <int> Post([FromBody] string name)
        {
            if (name.Length != 0)
            {
                User newUser = new User();
                newUser.UserName = name;
                newUser.EntryDateTime = DateTime.Now;

                _dbc.Users.Add(newUser);
                _dbc.SaveChanges();
                return newUser.Id;
            }
            else return -1;
        }




        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
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
        }

    }
}
