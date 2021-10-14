using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using myapp.Entities;

namespace myapp.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public AppDbContext(){}

        public DbSet<Cliente> Tb_Cliente {get; set;}
        public DbSet<Endereco> Tb_Endereco {get; set;}
        
    }
}