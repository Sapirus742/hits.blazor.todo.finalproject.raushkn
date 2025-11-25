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

        // Метод для добавления отдела
        public async Task AddDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        // Метод для получения одного отдела по ID
        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
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

        public async Task UpdateDepartmentAsync(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }
    }
}
