using System.ComponentModel.DataAnnotations;

namespace ReadyMadeATMBackend.Models;

public class User: BaseEntity
{
    [MaxLength(50)]
    public string Name { get; set; }
    public string AtmNumber { get; set; }
    public int Pin { get; set; }
    public double Balance { get; set; }
    public List<Transaction> Transactions { get; set; }
}