using MakeYourTrip_API.Models;
using MakeYourTrip_API.ModelsDTO.AdminModels;
using MakeYourTrip_API.ModelsResponse;
using Microsoft.EntityFrameworkCore;

namespace MakeYourTrip_API.Repositories.AdminRepo
{
    public class RepoAdmin : IRepoAdmin
    {
        private readonly AppDbContext _context;
        public RepoAdmin(AppDbContext context)
        {
            _context = context;
        }
        CommonResponse response = new();
        public async Task<CommonResponse> EnableEmployee(EnableEmployeeRequest enableEmployeeRequest)
        {
            try
            {
                Employee? isEmployee = await _context.Employees.FindAsync(enableEmployeeRequest.EmployeeId);
                if (isEmployee == null)
                {
                    AddResponse(false, $"No Employee found with id : {enableEmployeeRequest.EmployeeId}");return response;
                }
                _context.Entry(isEmployee).State = EntityState.Detached;
                isEmployee.Role = await _context.Roles.FindAsync(enableEmployeeRequest.RoleId);
                isEmployee.IsActive = enableEmployeeRequest.IsActivated;
                _context.Entry(isEmployee).State = EntityState.Modified;
                _context.Employees.Update(isEmployee);
                await _context.SaveChangesAsync();
                AddResponse(true, enableEmployeeRequest.IsActivated ? $"Employee {isEmployee.EmployeeId}({isEmployee.EmployeeLastName} {isEmployee.EmployeeLastName}) has been activated" : $"Employee {isEmployee.EmployeeId}({isEmployee.EmployeeLastName} {isEmployee.EmployeeLastName}) has been deactivated");
                return response;
            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message);return response;
            }
        }
        public void AddResponse(bool status, string message)
        {
            response = new()
            {
                Status = status,
                Message = message
            };
        }
    }
}
