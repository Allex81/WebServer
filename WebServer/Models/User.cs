using System;

namespace WebServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime EntryDateTime { get; set; }
    }
}
