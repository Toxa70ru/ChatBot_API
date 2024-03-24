using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ChatBotContext:DbContext
    {
        public ChatBotContext(DbContextOptions<ChatBotContext> options): base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
