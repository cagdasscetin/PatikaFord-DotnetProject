using BirdApi.Base;
using System.ComponentModel.DataAnnotations;

namespace BirdApi.Dto.Token
{
    public class UpdatePasswordRequest
    {
        [Required]
        [PasswordAttribute]
        public string OldPassword { get; set; }

        [Required]
        [Password]
        public string NewPassword { get; set; }
    }
}
