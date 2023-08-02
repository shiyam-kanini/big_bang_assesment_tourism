using MakeYourTrip_API.Models;
using MakeYourTrip_API.ModelsDTO.AuthModels;
using MakeYourTrip_API.ModelsResponse.AuthResponse;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MakeYourTrip_API.Repositories.AuthRepo
{
    public class RepoLogin : IRepoLogin
    {
        private readonly Random _random = new Random();
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        public RepoLogin(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        LoginLog loginLog = new();
        LoginResponse loginResponse = new();
        public async Task<LoginResponse> EmployeeLogin(LoginRequest loginData)
        {
            try
            {
                Employee isEmployee = await _context.Employees.FindAsync(loginData.LoginId);
                if(isEmployee == null)
                {
                    AddLoginResponse(false, $"No Employee found with id {loginData.LoginId}", loginLog);return loginResponse;
                }
                else if(!VerifyPassword(loginData.Password ?? "", isEmployee.PasswordHash, isEmployee.PasswordKey))
                {
                    AddLoginResponse(false, $"Passwords Dont Match {isEmployee.EmployeeFirstName}", loginLog); return loginResponse;
                }
                string token = CreateToken(loginData, isEmployee.Role != null ? isEmployee.Role.RoleId : "");
                AddLoginLog($"SID{_random.Next(1000, 9999)}", loginData, token);
                await _context.LoginLogs.AddAsync(loginLog);
                await _context.SaveChangesAsync();
                AddLoginResponse(true, $"Employee {isEmployee.EmployeeId} has logged in session : {loginLog.SessionId}", loginLog);
                return loginResponse;
            }
            catch(Exception ex)
            {
                AddLoginResponse(false, ex.Message, loginLog); return loginResponse;
            }
        }
        public async Task<LoginResponse> UserLogin(LoginRequest loginData)
        {
            try
            {
                User isUser = await _context.Users.FindAsync(loginData.LoginId);
                if (isUser == null)
                {
                    AddLoginResponse(false, $"No User found with id {loginData.LoginId}", loginLog); return loginResponse;
                }
                else if (!VerifyPassword(loginData.Password ?? "", isUser.PasswordHash, isUser.PasswordKey))
                {
                    AddLoginResponse(false, $"Passwords Dont Match", loginLog); return loginResponse;
                }
                string token = CreateToken(loginData, "User");
                AddLoginLog($"SID{_random.Next(1000, 9999)}", loginData, token);
                await _context.LoginLogs.AddAsync(loginLog);
                await _context.SaveChangesAsync();
                AddLoginResponse(true, $"Employee {isUser.UserId} has logged in session : {loginLog.SessionId}", loginLog);
                return loginResponse;
            }
            catch (Exception ex)
            {
                AddLoginResponse(false, ex.Message, loginLog); return loginResponse;
            }
        }
        public void AddLoginLog(string sId, LoginRequest loginCredentials, string token)
        {
            loginLog = new LoginLog()
            {
                SessionId = sId,
                LoginId = loginCredentials.LoginId,
                Token = token,
                IsLoggedIn = true,
            };
        }
        public void AddLoginResponse(bool status, string Message, LoginLog loginLog)
        {
            loginResponse = new LoginResponse()
            {
                Status = status,
                Message = Message,
                LoginLog = loginLog,
            };
        }
        public bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
        public async Task<LoginResponse> Logout(string SessionId)
        {
            try
            {
                loginLog = await _context.LoginLogs.FindAsync(SessionId);
                if (loginLog == null)
                {
                    AddLoginResponse(false, $"Session Not Found", loginLog);
                    return loginResponse;
                }
                if (!loginLog.IsLoggedIn)
                {
                    AddLoginResponse(false, $"Session already logged out", loginLog);
                    return loginResponse;
                }
                loginLog.IsLoggedIn = false;
                _context.LoginLogs.Update(loginLog);
                await _context.SaveChangesAsync();
                AddLoginResponse(true, $"Session {SessionId} Logged out", loginLog);
                return loginResponse;
            }
            catch (Exception ex)
            {
                AddLoginResponse(false, ex.Message, loginLog);
                return loginResponse;
            }
        }
        public string CreateToken(LoginRequest loginCredentials, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginCredentials.LoginId ?? ""),
                new Claim(ClaimTypes.Role, role)
            };
            string secretKey = _configuration["JWT:Key"] ?? "";
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
