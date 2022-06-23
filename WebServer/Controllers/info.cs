using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models;

namespace WebServer.Controllers
{
    [ApiController]
    [Route("report/info")]
    public class info : Controller
    {
        private DatabaseContext _dbc;
        public info(DatabaseContext dbc)
        {
            _dbc = dbc;
        }
      
        [HttpGet]
        public async Task<Query> Get([FromQuery] string guid)
        {
            int count = 0;
            int sleep = 60000; //мс
            Query query = new Query();

            if (!(guid is null))
            {
                query = _dbc.Queries.Where(c => c.QueryGuid == guid).FirstOrDefault();//Получаем информацию о запросе по guid

                TimeSpan timeSpan = (DateTime.Now - query.StartsAt);
                int percent = (int)(timeSpan.TotalMilliseconds * 100 / sleep); //вычисляем процент выполнения запроса
                if (percent >= 100)
                {
                    percent = 100;//считаем количество удволетворяющих нас вхождений
                    count = _dbc.Users.Count(o => query.UserName == o.UserName && o.EntryDateTime >= query.DateBegin && o.EntryDateTime <= query.DateEnd);
                }
                if (count > 0)
                {
                    //если вхождения есть, выдаем записываем результат
                    User user = _dbc.Users.Where(w => w.UserName == query.UserName).FirstOrDefault();
                    query.Result = user.UserName + ":" + count;
                }

                query.Percent = ((int)percent);//обновляем проценты
                _dbc.SaveChanges();
            }
            else 
            {
                query.Result = "BAD REQUEST";
            } 
            return query;
        }

        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return _dbc.Queries.Find(id).QueryGuid;
        }
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Query query = new Query();
            query.QueryGuid = value;

            //_dbc.Queries.Add(user);
            _dbc.SaveChanges();
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] int value)
        {
            Query query = _dbc.Queries.Find(id);
            query.Percent = value;
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
