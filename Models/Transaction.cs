using System.ComponentModel.DataAnnotations;

namespace ReadyMadeATMBackend.Models;

public class Transaction: BaseEntity
{
    
    [AllowedValues(["Withdraw", "AccountTransfer"], ErrorMessage = "Invalid Transaction Type")]
    public string Type { get; set; }
    public double Amount { get; set; }
    public string? Description { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public double CurrentBalance { get; set; }
    public int SenderId { get; set; }
    public User? Sender { get; set; }
    public int? ReceiverId { get; set; }
    public User? Receiver { get; set; }
}