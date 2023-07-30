using MakeYourTrip_API.ModelDTO.AuthModels;
using MakeYourTrip_API.Models;
using MakeYourTrip_API.ModelsDTO.AuthModels;
using MakeYourTrip_API.ModelsResponse.AuthResponse;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;

namespace MakeYourTrip_API.Repositories.AuthRepo
{
    public class RepoRegister : IRepoRegister
    {
        private readonly Random random = new();
        private readonly AppDbContext _context;
        byte[]? passwordHash;
        byte[]? passwordSalt;
        public RepoRegister(AppDbContext context)
        {
            _context = context;
        }
        public EmployeeRegisterResponse employeeRegisterResponse = new();
        public UserRegisterResponse userRegisterResponse = new();
        public Employee newEmployee = new();
        public User newUser = new();
        public async Task<EmployeeRegisterResponse> RegisterEmployee(EmployeeRequest registerData)
        {
            try
            {
                newEmployee = await _context.Employees.Where(x => x.EmployeeEmail.Equals(registerData.EmployeeEmail)).FirstOrDefaultAsync();
                if (newEmployee != null) 
                {
                    AddRegisterEmployeeResponse(false, "Employee with same mail id already exists, try with different one", registerData);
                    return employeeRegisterResponse;
                }
                CreatePasswordHash(registerData.Password ?? "", out passwordHash, out passwordSalt);
                AddEmployee($"EMPID{random.Next(10000, 99999)}", registerData, false);
                await _context.Employees.AddAsync(newEmployee);
                await _context.SaveChangesAsync();
                AddRegisterEmployeeResponse(true, $"Mx.{registerData.EmployeeFirstName} {registerData.EmployeeLastName} has been registered as Employee, LoginId : {newEmployee.EmployeeId}", registerData);
                return employeeRegisterResponse;
            }
            catch (Exception ex)
            {
                AddRegisterEmployeeResponse(false, ex.Message,registerData);
                return employeeRegisterResponse;
            }
        }

        public async Task<UserRegisterResponse> RegisterUser(UserRequest registerData)
        {
            try
            {
                newUser = await _context.Users.Where(x => x.UserEmail.Equals(registerData.UserEmail)).FirstOrDefaultAsync();
                if (newUser != null)
                {
                    AddRegisterUserResponse(false, "User with same mail id already exists, try with different one", registerData);
                    return userRegisterResponse;
                }
                CreatePasswordHash(registerData.Password ?? "", out passwordHash, out passwordSalt);
                AddUser($"UID{random.Next(10000, 99999)}", registerData);
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                AddRegisterUserResponse(true, $"Mx.{registerData.UserFirstName} {registerData.UserLastName} has been registered as Employee, LoginId : {newUser.UserId}", registerData);
                return userRegisterResponse;
            }
            catch (Exception ex)
            {
                AddRegisterUserResponse(false, ex.Message, registerData);
                return userRegisterResponse;
            }
        }
        public void AddEmployee(string employeeId, EmployeeRequest registerEmloyeeDTO, bool isactive)
        {
            newEmployee = new Employee()
            {
                EmployeeId = employeeId,
                EmployeeFirstName = registerEmloyeeDTO.EmployeeFirstName,
                EmployeeLastName = registerEmloyeeDTO.EmployeeLastName,
                EmployeeImageUrl = registerEmloyeeDTO.EmployeeImageUrl,
                EmployeeEmail = registerEmloyeeDTO.EmployeeEmail,
                CountryCode = registerEmloyeeDTO.CountryCode,
                EmployeePhone= registerEmloyeeDTO.EmployeePhone,
                EmployeeState= registerEmloyeeDTO.EmployeeState,
                Specialization = registerEmloyeeDTO.Specialization,
                IsActive = isactive,
                PasswordHash = passwordHash,
                PasswordKey = passwordSalt,
                Role = null,
            };
        }
        public void AddUser(string userId, UserRequest registerUserDTO)
        {
            newUser = new User()
            {
                UserId= userId,
                UserFirstName= registerUserDTO.UserFirstName,
                UserLastName= registerUserDTO.UserLastName,
                UserImageUrl= registerUserDTO.UserImageUrl,
                UserEmail = registerUserDTO.UserEmail,
                UserPhone= registerUserDTO.UserPhone,
                UserState= registerUserDTO.UserState,
                CountryCode= registerUserDTO.CountryCode,
                PasswordHash = passwordHash,
                PasswordKey = passwordSalt,
            };
        }
        public void AddRegisterUserResponse(bool status, string message, UserRequest user)
        {
            userRegisterResponse = new UserRegisterResponse()
            {
                Status = status,
                Message = message,
                User = user
            };
        }
        public void AddRegisterEmployeeResponse(bool status, string message, EmployeeRequest employee)
        {
            employeeRegisterResponse = new EmployeeRegisterResponse()
            {
                Status = status,
                Message = message,
                Employee= employee
            };
        }
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
