using BirdApi.Base;
using System.ComponentModel.DataAnnotations;

namespace BirdApi.Dto;

public class PersonDto : BaseDto
{
    [Required]
    [MaxLength(15)]
    [Display(Name = "Staff Id")]
    public string StaffId { get; set; }

    [Required]
    [MaxLength(25)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(25)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    [Phone]
    [MaxLength(25)]
    public string Phone { get; set; }

    [Required]
    [DateOfBirth]
    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    public DateTime DateOfBirth { get; set; }

    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }
}
