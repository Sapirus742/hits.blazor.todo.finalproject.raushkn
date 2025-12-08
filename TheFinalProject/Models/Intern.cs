using System.ComponentModel.DataAnnotations;

namespace TheFinalProject.Models
{
    public class Intern : Account
    {
        [Required(ErrorMessage = "Укажите дату начала стажировки")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата начала стажировки")]
        public DateTime InternshipStartDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Укажите дату окончания стажировки")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата окончания стажировки")]
        public DateTime InternshipEndDate { get; set; } = DateTime.UtcNow.AddMonths(3);

        [StringLength(200)]
        [Display(Name = "Имя куратора")]
        public string? MentorName { get; set; }

        [Range(0, 100)]
        [Display(Name = "Процент выполнения программы стажировки")]
        public int CompletionPercentage { get; set; } = 0;
    }
}
