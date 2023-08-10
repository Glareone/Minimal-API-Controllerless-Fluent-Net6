namespace Chapter10_localization;
using System.ComponentModel.DataAnnotations;

public class Person
{
    
    [MaxLength(30)]
    public string FirstName { get; set; }
    
    [MaxLength(30)]
    public string LastName { get; set; }
    
    [EmailAddress]
    [StringLength(100, MinimumLength = 6)]
    public string Email { get; set; }
}
