using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Models
{
    public class RoleCreateModel
    {
        [Required(ErrorMessage ="Ad alanı gereklidir")]
        public string Name { get; set; }
    }
}
