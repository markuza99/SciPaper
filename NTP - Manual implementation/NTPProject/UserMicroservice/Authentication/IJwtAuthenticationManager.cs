namespace UserMicroservice.Authentication
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);

        int? ValidateJwtToken(string token);

        string ValidateManualy(string token);
    }
}
