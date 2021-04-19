using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTClaimsDemo.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public int RoleId { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("RoleId")]
        public virtual UserRole UserRole { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<Account> Accounts { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
