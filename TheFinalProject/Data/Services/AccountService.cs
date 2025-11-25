using Microsoft.EntityFrameworkCore;
using TheFinalProject.Models;

namespace TheFinalProject.Data.Services
{
    public class AccountService
    {
        private readonly JournalDbContext _context;

        public AccountService(JournalDbContext context) => _context = context;

        // Получить всех сотрудников
        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        // Получить сотрудников конкретного отдела
        public async Task<List<Account>> GetAccountsByDepartmentAsync(int departmentId)
        {
            return await _context.Accounts
                .Where(a => a.DepartmentId == departmentId)
                .ToListAsync();
        }

        public async Task CreateAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        // Метод для заполнения тестовыми данными
        public async Task SeedAccountsAsync()
        {
            if (!_context.Accounts.Any())
            {
                var departments = await _context.Departments.ToListAsync();

                if (departments.Any())
                {
                    _context.Accounts.AddRange(
                        new Account { DisplayName = "Иванов Иван", Role = "Бухгалтер", DepartmentId = departments[0].Id },
                        new Account { DisplayName = "Петров Петр", Role = "Программист", DepartmentId = departments[1].Id },
                        new Account { DisplayName = "Сидорова Мария", Role = "Менеджер", DepartmentId = departments[2].Id }
                    );
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<Account?> GetAccountByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}
