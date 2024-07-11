using System.ComponentModel.DataAnnotations;

namespace ReadyMadeATMBackend.Models;

public class BaseEntity
{
    [Key] public int Id { get; set; }
}
