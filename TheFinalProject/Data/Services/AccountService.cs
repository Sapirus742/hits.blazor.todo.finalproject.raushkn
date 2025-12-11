using Microsoft.EntityFrameworkCore;
using TheFinalProject.Models;
using TheFinalProject.Data;

namespace TheFinalProject.Data.Services
{
    public class AccountService
    {
        private readonly JournalDbContext _context;

        public AccountService(JournalDbContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<List<Account>> GetAccountsByDepartmentAsync(int departmentId)
        {
            return await _context.Accounts
                .Where(a => a.DepartmentId == departmentId)
                .ToListAsync();
        }

        // Новый метод: получить только стажеров
        public async Task<List<Intern>> GetInternsAsync()
        {
            return await _context.Interns.ToListAsync();
        }

        // Новый метод: получить стажеров определенного отдела
        public async Task<List<Intern>> GetInternsByDepartmentAsync(int departmentId)
        {
            return await _context.Interns
                .Where(i => i.DepartmentId == departmentId)
                .ToListAsync();
        }

        public async Task<Account?> GetAccountByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task CreateAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        // Новый метод: создать стажера
        public async Task CreateInternAsync(Intern intern)
        {
            _context.Interns.Add(intern);
            await _context.SaveChangesAsync();
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
