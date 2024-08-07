using System;
using DataLayer;
using DataLayer.Models;
using BusinessLayer.Services;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        // Construcción de opciones de DbContext con la cadena de conexión
        var options = new DbContextOptionsBuilder<BudgetContext>()
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BudgetControlDb;Trusted_Connection=True;")
            .Options;

        // Creación de una instancia de BudgetContext con las opciones
        using (var context = new BudgetContext(options))
        {
            var budgetService = new BudgetService(context);
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("        Control de Presupuestos");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("1. Ver todos los presupuestos");
                Console.WriteLine("2. Ver presupuesto por ID");
                Console.WriteLine("3. Añadir presupuesto");
                Console.WriteLine("4. Actualizar presupuesto");
                Console.WriteLine("5. Eliminar presupuesto");
                Console.WriteLine("6. Salir");
                Console.WriteLine("---------------------------------------");
                Console.Write("Seleccione una opción: ");

                

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var budgets = budgetService.GetAllBudgets();
                        foreach (var Budget in budgets)
                        {
                            Console.WriteLine($"ID: {Budget.Id}, Nombre: {Budget.Name}, Cantidad: {Budget.Amount}");
                        }
                        break;
                    case "2":
                        Console.Write("Ingrese el ID del presupuesto: ");
                        var id = int.Parse(Console.ReadLine());
                        var budget = budgetService.GetBudgetById(id);
                        if (budget != null)
                        {
                            Console.WriteLine($"ID: {budget.Id}, Nombre: {budget.Name}, Cantidad: {budget.Amount}");
                        }
                        else
                        {
                            Console.WriteLine("Presupuesto no encontrado.");
                        }
                        break;
                    case "3":
                        Console.Write("Ingrese el nombre del presupuesto: ");
                        var name = Console.ReadLine();
                        Console.Write("Ingrese la cantidad del presupuesto: ");
                        var amount = decimal.Parse(Console.ReadLine());
                        budgetService.AddBudget(new Budget { Name = name, Amount = amount });
                        Console.WriteLine("Presupuesto añadido.");
                        break;
                    case "4":
                        Console.Write("Ingrese el ID del presupuesto: ");
                        var updateId = int.Parse(Console.ReadLine());
                        var updateBudget = budgetService.GetBudgetById(updateId);
                        if (updateBudget != null)
                        {
                            Console.Write("Ingrese el nuevo nombre del presupuesto: ");
                            updateBudget.Name = Console.ReadLine();
                            Console.Write("Ingrese la nueva cantidad del presupuesto: ");
                            updateBudget.Amount = decimal.Parse(Console.ReadLine());
                            budgetService.UpdateBudget(updateBudget);
                            Console.WriteLine("Presupuesto actualizado.");
                        }
                        else
                        {
                            Console.WriteLine("Presupuesto no encontrado.");
                        }
                        break;
                    case "5":
                        Console.Write("Ingrese el ID del presupuesto: ");
                        var deleteId = int.Parse(Console.ReadLine());
                        budgetService.DeleteBudget(deleteId);
                        Console.WriteLine("Presupuesto eliminado.");
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
