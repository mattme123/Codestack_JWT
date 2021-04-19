using System.ComponentModel.DataAnnotations;

namespace JWTClaimsDemo.Entities
{
    public class AccountType
    {
        [Key]
        public int AccountTypeId { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
    }
}
