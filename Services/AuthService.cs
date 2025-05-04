using System.Security.Cryptography;
using System.Text;
using HospitalManagementSystemAPI.Data;
using HospitalManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystemAPI.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystemAPI.Services
{
    public class AuthService
    {
        private readonly HospitalContext _context;
        public AuthService(HospitalContext context)
        {
            _context = context;
        }

        public void Register(UserDTO user)
        {
            var newUser = new SystemUser
            {
                Username = user.Username,
                Password = HashPassword(user.Password)
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public string? Authnticate(LoginDTO loginUser)
        {
            var user = _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(u => u.Role)
                .FirstOrDefault(u => u.Username == loginUser.Username && u.Password == HashPassword(loginUser.Password));

            if (user == null) return null;

            List<Claims> myClaims = user.UserRoles.Select(u => new Claim(ClaimTypes.Role, x.Role.Name)).ToList();

            var stringSK = "mySecretKey";

            SecurityKey mySK = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(stringSK));

            SigningCredentials mySC = new SigningCredentials(mySK, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken myJWT = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(1),
                claims: myClaims,
                signingCredentials: mySC
            );

            return new JwtSecurityTokenHandler().WriteToken(myJWT);
        }
    }
}
