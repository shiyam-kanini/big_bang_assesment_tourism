namespace MakeYourTrip_API.ModelsDTO.AuthModels
{
    public class UserRequest
    {
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserImageUrl { get; set; }
        public string? UserEmail { get; set; }
        public string? CountryCode { get; set; }
        public string? UserPhone { get; set; }
        public string? UserState { get; set; }
        public string? Password { get; set; }
    }
}
