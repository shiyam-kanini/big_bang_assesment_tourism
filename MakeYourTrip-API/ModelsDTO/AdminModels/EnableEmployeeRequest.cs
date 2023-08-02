namespace MakeYourTrip_API.ModelsDTO.AdminModels
{
    public class EnableEmployeeRequest
    {
        public string? EmployeeId { get; set; }
        public string? RoleId { get; set; }
        public bool IsActivated { get; set; }
    }
}
