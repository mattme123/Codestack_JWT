namespace JWTClaimsDemo.Entities.Models
{
    public class JWTRequest
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
    }
}
