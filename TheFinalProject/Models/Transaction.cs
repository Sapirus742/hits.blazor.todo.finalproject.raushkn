using System.ComponentModel.DataAnnotations;

namespace TheFinalProject.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Дата обязательна")]
        public DateTime Date { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "Тип операции обязателен")]
        public string OperationType { get; set; } = string.Empty;
        [Required(ErrorMessage = "Сумма обязательна")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Сумма должна быть больше 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Описание обязательно")]
        [StringLength(300, ErrorMessage = "Описание не может быть длиннее 300 символов")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Выберите сотрудника")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите сотрудника")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Выберите отдел")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите отдел")]
        public int DepartmentId { get; set; }
    }
}
