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

        public async Task SeedAccountsAsync()
        {
            if (!_context.Accounts.Any())
            {
                var departments = await _context.Departments.ToListAsync();

                if (departments.Any())
                {
                    // Обычные сотрудники
                    var accounts = new List<Account>
                    {
                        new Account
                        {
                            DisplayName = "Иванов Иван",
                            Role = "Главный бухгалтер",
                            DepartmentId = departments[0].Id
                        },
                        new Account
                        {
                            DisplayName = "Петрова Анна",
                            Role = "Бухгалтер",
                            DepartmentId = departments[0].Id
                        },
                        new Account
                        {
                            DisplayName = "Сидоров Петр",
                            Role = "Старший разработчик",
                            DepartmentId = departments[1].Id
                        },
                        new Account
                        {
                            DisplayName = "Козлова Мария",
                            Role = "Разработчик",
                            DepartmentId = departments[1].Id
                        },
                        new Account
                        {
                            DisplayName = "Смирнов Алексей",
                            Role = "Менеджер по продажам",
                            DepartmentId = departments[2].Id
                        }
                    };

                    // Стажеры
                    var interns = new List<Intern>
                    {
                        new Intern
                        {
                            DisplayName = "Новиков Дмитрий",
                            Role = "Стажер-разработчик",
                            DepartmentId = departments[1].Id,
                            InternshipStartDate = DateTime.UtcNow.AddMonths(-1),
                            InternshipEndDate = DateTime.UtcNow.AddMonths(2),
                            MentorName = "Сидоров Петр",
                            CompletionPercentage = 35
                        },
                        new Intern
                        {
                            DisplayName = "Морозова Ольга",
                            Role = "Стажер в продажах",
                            DepartmentId = departments[2].Id,
                            InternshipStartDate = DateTime.UtcNow.AddDays(-15),
                            InternshipEndDate = DateTime.UtcNow.AddMonths(3),
                            MentorName = "Смирнов Алексей",
                            CompletionPercentage = 15
                        }
                    };

                    _context.Accounts.AddRange(accounts);
                    _context.Interns.AddRange(interns);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
