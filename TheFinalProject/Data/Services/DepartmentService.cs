using Microsoft.EntityFrameworkCore;
using TheFinalProject.Models;

namespace TheFinalProject.Data.Services
{
    public class DepartmentService
    {
        private readonly JournalDbContext _context;

        public DepartmentService(JournalDbContext context) => _context = context;

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        // Метод для добавления тестовых данных (если база пустая)
        public async Task SeedDataAsync()
        {
            if (!_context.Departments.Any())
            {
                _context.Departments.AddRange(
                    new Department { Name = "Бухгалтерия" },
                    new Department { Name = "IT Отдел" },
                    new Department { Name = "Отдел Продаж" }
                );
                await _context.SaveChangesAsync();
            }
        }
    }
}
