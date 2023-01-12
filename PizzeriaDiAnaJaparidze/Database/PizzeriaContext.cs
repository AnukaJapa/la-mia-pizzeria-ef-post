using Microsoft.EntityFrameworkCore;
using PizzeriaDiAnaJaparidze.Models;
using System.Data.Common;

namespace PizzeriaDiAnaJaparidze.Database
{
    public class PizzeriaContext : DbContext 
    {
      public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=PizzeriaAnaDB;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
