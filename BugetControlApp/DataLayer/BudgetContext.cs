using Microsoft.EntityFrameworkCore;
using DataLayer.Models;

namespace DataLayer
{
    public class BudgetContext : DbContext
    {
        // Constructor que acepta DbContextOptions<BudgetContext>
        public BudgetContext(DbContextOptions<BudgetContext> options)
            : base(options) // Llamada al constructor de la clase base DbContext
        {
        }

        // Definición del DbSet para los presupuestos
        public DbSet<Budget> Budgets { get; set; }
    }
}
