namespace TransactionsManagementApp.Model
{
    public class TransactionsDTO
    {
        public int TransactionId { get; set; } 
        public decimal Amount { get; set; }  
        public int TransactionTypeId { get; set; } 
        public DateTime TransactionDate { get; set; }  
        public string? Description { get; set; }  
        public int StatusId { get; set; }  
        public string? CustomerFullName { get; set; }  
        public string? CustomerMainPhoneNumber { get; set; }  
        public string? CustomerMainAddress { get; set; }  
        public string? CustomerMainEmailAddress { get; set; } 
    }
}
