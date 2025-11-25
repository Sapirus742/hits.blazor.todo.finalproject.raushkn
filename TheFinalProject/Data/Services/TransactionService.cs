using Microsoft.EntityFrameworkCore;
using TheFinalProject.Data;
using TheFinalProject.Models;

namespace TheFinalProject.Data.Services
{
    public class TransactionService
    {
        private readonly JournalDbContext _context;
        public TransactionService(JournalDbContext context) => _context = context;

        public async Task<List<Transaction>> GetTransactionsAsync()
            => await _context.Transactions.ToListAsync();

        public async Task AddTransactionAsync(Transaction tr)
        {
            _context.Transactions.Add(tr);
            await _context.SaveChangesAsync();
        }
    }
}
