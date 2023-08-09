namespace Chapter07_Mapping_AutoMapper.Entity;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; } = DateTime.Parse("1990-12-12");
    public Address? Address { get; set; }
    public DateTimeOffset CreationDate { get; set; }
}
