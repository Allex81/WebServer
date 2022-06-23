using Microsoft.EntityFrameworkCore;
using WebServer.Models;

namespace WebServer
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
          : base(options)
        {

        }
        public DbSet<Query> Queries { get; set; } //Контейнер(таблица) с состоянием запросов
        public DbSet<User> Users { get; set; }//Контейнер(таблица) с информацией о пользователях
    }
}
