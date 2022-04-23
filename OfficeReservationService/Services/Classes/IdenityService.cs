using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OfficeReservationService.Contracts.Models;
using OfficeReservationService.Data;
using OfficeReservationService.Domain;
using OfficeReservationService.Options;
using OfficeReservationService.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace OfficeReservationService.Services.Classes
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly DataContext _context;

        public IdentityService(UserManager<AppUser> userManager, JwtSettings jwtSettings, TokenValidationParameters tokenValidationParameters,
            DataContext context)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            _tokenValidationParameters = tokenValidationParameters;
            _context = context;
        }
        public async Task<AuthenticationResult> LoginAsync(string credential, string password)
        {
            var isEmail = IsCredentialAnEmail(credential);
            AppUser appUser;
            if (isEmail)
            {
                appUser = await _userManager.FindByEmailAsync(credential);
            }
            else
            {
                appUser = await _userManager.FindByNameAsync(credential);
            }

            if (appUser == null || await _userManager.CheckPasswordAsync(appUser, password) == false)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Incorrect e-mail address or password." }
                };
            }
            if (!appUser.EmailConfirmed)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Email address not confirmed." }
                };
            }
            return await GenerateAuthenticationResultForUserAsync(appUser);
        }
        private async Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var userRoles = await _userManager.GetRolesAsync(user);
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("id", user.Id),
                    new Claim("username", user.UserName)
                }),
                Expires = DateTime.MaxValue,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            foreach (var item in userRoles)
            {
                tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, item));
            }

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                UserId = user.Id,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(3)
            };

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            return new Domain.AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token.ToString()
            };
        }
        private bool IsCredentialAnEmail(string credential)
        {
            if (!MailAddress.TryCreate(credential, out _))
            {
                return false;
            }
            return true;
        }
    }

}
