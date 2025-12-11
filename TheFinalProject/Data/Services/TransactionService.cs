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
        public async Task<Transaction?> GetTransactionByIdAsync(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            // Отсоединяем все отслеживаемые экземпляры этой транзакции
            var trackedEntity = _context.ChangeTracker.Entries<Transaction>()
                .FirstOrDefault(e => e.Entity.Id == transaction.Id);

            if (trackedEntity != null)
            {
                trackedEntity.State = EntityState.Detached;
            }

            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTransactionAsync(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }
    }
}
