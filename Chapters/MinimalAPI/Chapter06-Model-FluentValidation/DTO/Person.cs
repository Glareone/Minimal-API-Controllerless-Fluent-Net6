namespace Chapter06_Model_FluentValidation.DTO;
using System.ComponentModel.DataAnnotations;


public class Person
{
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(30)]
    public string LastName { get; set; }
    [EmailAddress]
    [StringLength(100, MinimumLength = 6)]
    public string Email { get; set; }
}

