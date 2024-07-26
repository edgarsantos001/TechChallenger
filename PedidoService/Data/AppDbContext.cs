using Microsoft.EntityFrameworkCore;
using Pedido.Models;

namespace PedidoService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<PedidoModel> Pedidos { get; set; }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
        string conns = "Server=127.0.0.1;Persist Security Info=True;DataBase=db;Uid=desenvolvimento;Pwd=Dev@PEP22;Convert Zero Datetime=True;";
        optionsBuilder.UseMySql(conns, ServerVersion.AutoDetect(conns));
     }

}
