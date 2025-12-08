using System.ComponentModel.DataAnnotations;

namespace TheFinalProject.Models
{
    public class Branch : Department
    {
        [Required(ErrorMessage = "Укажите город филиала")]
        [StringLength(100)]
        [Display(Name = "Город")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите адрес филиала")]
        [StringLength(200)]
        [Display(Name = "Адрес")]
        public string Address { get; set; } = string.Empty;

        [Phone]
        [StringLength(20)]
        [Display(Name = "Телефон")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Дата открытия")]
        [DataType(DataType.Date)]
        public DateTime OpeningDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Площадь офиса (кв.м.)")]
        [Range(0, 100000)]
        public int OfficeArea { get; set; } = 0;

        [Display(Name = "Статус филиала")]
        [Required]
        public string Status { get; set; } = "Active"; // Active, Temporarily Closed, Closed
    }
}
