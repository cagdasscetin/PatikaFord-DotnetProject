using BirdApi.Base;

namespace BirdApi.Data;

public class Person : BaseModel
{
    public string StaffId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
}
