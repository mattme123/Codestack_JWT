using JWTClaimsDemo.DataAccess;
using JWTClaimsDemo.Entities;
using JWTClaimsDemo.Entities.Models;
using JWTClaimsDemo.Extentions.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace JWTClaimsDemo.Services
{
    public class AuthService
    {
        public IConfiguration Configuration { get; set; }
        private readonly JWTContext _context;
        public AuthService(JWTContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public User Login(LoginRequest request)
        {
            return _context.Users.Include(x => x.Accounts).FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);
        }

        public string WriteToken()
        {
            string signingKey = Configuration.GetValue<string>("TokenSigningKey");
            string clientUrl = Configuration.GetValue<string>("ClientUrl");
            try
            {
                SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
                SigningCredentials credentials = new SigningCredentials(secretKey,
                    SecurityAlgorithms.HmacSha256);
                JwtSecurityToken tokenOptions = new JwtSecurityToken(
                    issuer: clientUrl,
                    audience: clientUrl,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials
                );
                return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            }
            catch (Exception)
            {
                throw new CustomException(500, "Something went wrong while writing the auth token");
            }
        }
    }
}
