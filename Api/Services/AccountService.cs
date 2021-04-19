using JWTClaimsDemo.DataAccess;
using JWTClaimsDemo.Entities;
using JWTClaimsDemo.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace JWTClaimsDemo.Services
{
    public class AccountService
    {
        private readonly JWTContext _context;
        public AccountService(JWTContext context)
        {
            _context = context;
        }
        public void TransferFunds(Transfer transfer)
        {
            var fromAccount = GetAccount(transfer.FromAccountId);
            var toAccount = GetAccount(transfer.ToAccountId);

            fromAccount.Funds -= transfer.Amount;
            toAccount.Funds += transfer.Amount;

            _context.SaveChanges();
        }

        public Account GetAccount(int accountId)
        {
            return _context.Accounts.FirstOrDefault(x => x.AccountId == accountId);
        }

        public List<Account> GetAccounts(int userId)
        {
            return _context.Accounts.Where(x => x.UserId == userId).ToList();
        }

        public void AddChristmasGift()
        {
            var accounts = _context.Accounts.ToList();

            accounts.ForEach(x => x.Funds += 100);

            _context.SaveChanges();
        }
    }
}
