using Microsoft.EntityFrameworkCore;
using TheFinalProject.Models;
using TheFinalProject.Data;

namespace TheFinalProject.Data.Services
{
    public class DepartmentService
    {
        private readonly JournalDbContext _context;

        public DepartmentService(JournalDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        // Новый метод: получить только главные отделы (без филиалов)
        public async Task<List<Department>> GetMainDepartmentsAsync()
        {
            return await _context.Departments
                .Where(d => !(d is Branch))
                .ToListAsync();
        }

        // Новый метод: получить только филиалы
        public async Task<List<Branch>> GetBranchesAsync()
        {
            return await _context.Branches.ToListAsync();
        }

        // Новый метод: получить филиалы по городу
        public async Task<List<Branch>> GetBranchesByCityAsync(string city)
        {
            return await _context.Branches
                .Where(b => b.City == city)
                .ToListAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task AddDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        // Новый метод: создать филиал
        public async Task AddBranchAsync(Branch branch)
        {
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();
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
