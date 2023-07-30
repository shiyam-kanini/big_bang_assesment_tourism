namespace MakeYourTrip_API.ModelDTO.AuthModels
{
    public class EmployeeRequest
    {
        public string? EmployeeFirstName { get; set; }
        public string? EmployeeLastName { get; set; }
        public string? EmployeeImageUrl { get; set; }
        public string? EmployeeEmail { get; set; }
        public string? CountryCode { get; set; }
        public string? EmployeePhone { get; set; }
        public string? EmployeeState { get; set; }
        public string? Specialization { get; set; }
        public string?  Password { get; set; }
    }
}
