using DataLayer;
using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class BudgetService
    {
        private readonly BudgetContext _context;

        public BudgetService(BudgetContext context)
        {
            _context = context;
        }

        public List<Budget> GetAllBudgets()
        {
            return _context.Budgets.ToList();
        }

        public Budget GetBudgetById(int id)
        {
            return _context.Budgets.Find(id);
        }

        public void AddBudget(Budget budget)
        {
            _context.Budgets.Add(budget);
            _context.SaveChanges();
        }

        public void UpdateBudget(Budget budget)
        {
            _context.Budgets.Update(budget);
            _context.SaveChanges();
        }

        public void DeleteBudget(int id)
        {
            var budget = _context.Budgets.Find(id);
            if (budget != null)
            {
                _context.Budgets.Remove(budget);
                _context.SaveChanges();
            }
        }
    }
}
