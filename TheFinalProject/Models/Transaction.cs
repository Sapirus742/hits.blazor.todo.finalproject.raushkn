using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheFinalProject.Data;

namespace TheFinalProject.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Выберите отдел")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите отдел")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Выберите сотрудника")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите сотрудника")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Выберите тип операции")]
        public string OperationType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите сумму")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Сумма должна быть больше нуля")]
        [Column(TypeName = "decimal(18,2)")] 
        public decimal Amount { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        // Для межотдельских переводов
        public int? TargetDepartmentId { get; set; }
    }
}
