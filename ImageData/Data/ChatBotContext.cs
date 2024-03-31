using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ChatBotContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ImageModel> ImageModel { get; set; }
        public ChatBotContext(DbContextOptions<ChatBotContext> options): base(options) { }
        
    }
}
