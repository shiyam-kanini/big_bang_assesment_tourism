using MakeYourTrip_API.ModelDTO.AuthModels;
using MakeYourTrip_API.Models;
using MakeYourTrip_API.ModelsDTO.AuthModels;
using MakeYourTrip_API.ModelsResponse.AuthResponse;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip_API.Repositories.ProfileRepo
{
    public class RepoProfile : IRepoProfile
    {
        private readonly AppDbContext _context;
        private readonly Random _random = new Random();
        public RepoProfile(AppDbContext context)
        {
            _context = context;
        }
        User? user = new();
        Employee? employee = new();
        EmployeeRegisterResponse employeeResponse = new();
        UserRegisterResponse userResponse = new();

        public async Task<Employee> GetEmployeeProfile(string EmployeeId)
        {
            return await _context.Employees.Where(y => y.EmployeeId.Equals(EmployeeId)).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserProfile(string UserId)
        {
            return await _context.Users.FindAsync(UserId);
        }

        public async Task<EmployeeRegisterResponse> UpdateEmployeeProfile(EmployeeRequest updateData, string employeeId)
        {
            try
            {
                employee = await _context.Employees.FindAsync(employeeId);
                if (employee == null)
                {
                    AddEmployeeResponse(false, $"No employee found for id : {employeeId}", updateData); return employeeResponse;
                }
                _context.Entry(employee).State = EntityState.Detached;
                EmployeeUpdation(employeeId, updateData);
                _context.Entry(employee).State = EntityState.Modified;
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                AddEmployeeResponse(true, $"Employee profile updated", updateData); return employeeResponse;
            }
            catch(Exception ex)
            {
                AddEmployeeResponse(false, ex.Message, updateData); return employeeResponse;
            }
        }

        public async Task<UserRegisterResponse> UpdateUserProfile(UserRequest updateData, string userId)
        {
            try
            {
                user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    AddUserResponse(false, $"No User found for id : {userId}", updateData); return userResponse;
                }
                _context.Entry(user).State = EntityState.Detached;
                UserUpdation(userId, updateData);
                _context.Entry(user).State = EntityState.Modified;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                AddUserResponse(true, $"User profile updated", updateData); return userResponse;
            }
            catch (Exception ex)
            {
                AddUserResponse(false, ex.Message, updateData); return userResponse;
            }
        }
        public void EmployeeUpdation(string employeeId, EmployeeRequest updateData)
        {
            employee = new()
            {
                EmployeeId = employeeId,
                EmployeeFirstName = updateData.EmployeeFirstName,
                EmployeeLastName = updateData.EmployeeLastName,
                EmployeeEmail = updateData.EmployeeEmail,
                EmployeePhone = updateData.EmployeePhone,
                EmployeeImageUrl = updateData.EmployeeImageUrl,
                EmployeeState = updateData.EmployeeState,
                CountryCode = updateData.CountryCode,
                Specialization = updateData.Specialization,
            };
        }
        public void UserUpdation(string userId, UserRequest registerUserDTO)
        {
            user = new User()
            {
                UserId = userId,
                UserFirstName = registerUserDTO.UserFirstName,
                UserLastName = registerUserDTO.UserLastName,
                UserImageUrl = registerUserDTO.UserImageUrl,
                UserEmail = registerUserDTO.UserEmail,
                UserPhone = registerUserDTO.UserPhone,
                UserState = registerUserDTO.UserState,
                CountryCode = registerUserDTO.CountryCode,
            };
        }
        public void AddEmployeeResponse(bool status, string message, EmployeeRequest updatedEmployee)
        {
            employeeResponse = new()
            {
                Status = status,
                Message = message,
                Employee = updatedEmployee
            };
        }
        public void AddUserResponse(bool status, string message, UserRequest updatedUser)
        {
            userResponse = new()
            {
                Status = status,
                Message = message,
                User = updatedUser
            };
        }
    }
}
