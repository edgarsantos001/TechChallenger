using ClienteService.Models;
using Microsoft.EntityFrameworkCore;

namespace ClienteService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        string conns = "Server=127.0.0.1;Persist Security Info=True;DataBase=db;Uid=desenvolvimento;Pwd=Dev@PEP22;Convert Zero Datetime=True;";
        optionsBuilder.UseMySql(conns, ServerVersion.AutoDetect(conns));
    }

    public DbSet<ClienteModel> Clientes { get; set; }
}

