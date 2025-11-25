namespace TheFinalProject.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
        public int DepartmentId { get; set; }
    }
}
