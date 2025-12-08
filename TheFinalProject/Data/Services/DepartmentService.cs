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

        public async Task SeedDataAsync()
        {
            if (!_context.Departments.Any())
            {
                // Главные отделы
                var mainDepartments = new List<Department>
                {
                    new Department { Name = "Бухгалтерия" },
                    new Department { Name = "IT Отдел" },
                    new Department { Name = "Отдел Продаж" }
                };

                // Филиалы
                var branches = new List<Branch>
                {
                    new Branch
                    {
                        Name = "Филиал Москва",
                        City = "Москва",
                        Address = "ул. Тверская, д. 10",
                        PhoneNumber = "+7 (495) 123-45-67",
                        OpeningDate = new DateTime(2020, 3, 15),
                        OfficeArea = 250,
                        Status = "Active"
                    },
                    new Branch
                    {
                        Name = "Филиал Санкт-Петербург",
                        City = "Санкт-Петербург",
                        Address = "Невский проспект, д. 25",
                        PhoneNumber = "+7 (812) 987-65-43",
                        OpeningDate = new DateTime(2021, 6, 20),
                        OfficeArea = 180,
                        Status = "Active"
                    },
                    new Branch
                    {
                        Name = "Филиал Казань",
                        City = "Казань",
                        Address = "ул. Баумана, д. 5",
                        PhoneNumber = "+7 (843) 555-12-34",
                        OpeningDate = new DateTime(2023, 1, 10),
                        OfficeArea = 120,
                        Status = "Active"
                    }
                };

                _context.Departments.AddRange(mainDepartments);
                _context.Branches.AddRange(branches);
                await _context.SaveChangesAsync();
            }
        }
    }
}
