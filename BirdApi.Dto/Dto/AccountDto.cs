using BirdApi.Base;
using System.ComponentModel.DataAnnotations;

namespace BirdApi.Dto;

public class AccountDto : BaseDto
{
    [MaxLength(100)]
    [UserNameAttribute]
    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Required]
    [PasswordAttribute]
    public string Password { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [EmailAddressAttribute]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required]
    [RoleAttribute]
    public string Role { get; set; }

    [Display(Name = "Last Activity")]
    public DateTime LastActivity { get; set; }
}
