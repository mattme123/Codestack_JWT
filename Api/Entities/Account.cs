using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTClaimsDemo.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public int AccountTypeId { get; set; }
        [ForeignKey("AccountTypeId")]
        public AccountType AccountType { get; set; }
        public int Funds { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
