using System.ComponentModel.DataAnnotations;

namespace JWTClaimsDemo.Entities
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
    }
}
