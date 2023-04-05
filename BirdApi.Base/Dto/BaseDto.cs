using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdApi.Base;

public abstract class BaseDto
{
    public int Id { get; set; }

    [MaxLength(50)]
    [Display(Name = "Created By")]
    public string CreatedBy { get; set; }

    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; }
}
