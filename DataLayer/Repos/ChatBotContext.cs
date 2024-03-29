using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repos
{
    public class ChatBotContext : DbContext
    {
        public ChatBotContext(DbContextOptions<ChatBotContext> options)
            : base(options)
        {

        }

        public ChatBotContext()
        {
        }
        public DbSet<Executor> Executor { get; set; }
        public DbSet<SoftwareName> softwareNames { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Appeal> Appeal { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Picture> Pictures { get; set; }

    }
}
