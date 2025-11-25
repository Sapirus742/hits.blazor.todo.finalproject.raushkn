using Microsoft.EntityFrameworkCore;
using TheFinalProject.Models;

namespace TheFinalProject.Data.Services
{
    public class AccountService
    {
        private readonly JournalDbContext _context;

        public AccountService(JournalDbContext context) => _context = context;

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
    }
}
