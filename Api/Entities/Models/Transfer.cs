namespace JWTClaimsDemo.Entities.Models
{
    public class Transfer
    {
        public int Amount { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
    }
}
