using System.ComponentModel.DataAnnotations;

namespace TheFinalProject.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(100, ErrorMessage = "Имя не может быть длиннее 100 символов")]
        public string DisplayName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Должность обязательна")]
        [StringLength(100, ErrorMessage = "Должность не может быть длиннее 100 символов")]
        public string Role { get; set; } = string.Empty;

        [Required(ErrorMessage = "Выберите отдел")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите отдел")]
        public int DepartmentId { get; set; }
    }
}
