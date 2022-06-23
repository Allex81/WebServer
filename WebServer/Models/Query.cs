using System;

namespace WebServer.Models
{
    public class Query
    {
        public int Id { get; set; }
        public string QueryGuid { get; set; }
        public string Result { get; set; }
        public DateTime StartsAt { get; set; }
        public string UserName { get; set; }
        public int Percent { get; set; }

        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
