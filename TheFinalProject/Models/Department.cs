using System.ComponentModel.DataAnnotations;

namespace TheFinalProject.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Название отдела обязательно")]
        [StringLength(100, ErrorMessage = "Название не может быть длиннее 100 символов")]
        public string Name { get; set; } = string.Empty;
    }
}
