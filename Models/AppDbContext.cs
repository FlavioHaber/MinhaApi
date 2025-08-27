using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace MinhaApi.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options) { }
        public DbSet<Produto> Produtos { get; set; } = null!;
    }
}