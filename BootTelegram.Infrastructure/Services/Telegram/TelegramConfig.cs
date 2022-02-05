using System.Diagnostics.CodeAnalysis;

namespace BootTelegram.Infrastructure.Services.Telegram
{
    [ExcludeFromCodeCoverage]
    public class TelegramConfig
    {
        public TelegramConfig() { }

        public TelegramConfig(string apiId, string apiHash, string phoneNumber, string verificationCode, string firstName, string lastName, string password)
        {
            ApiId = apiId;
            ApiHash = apiHash;
            PhoneNumber = phoneNumber;
            VerificationCode = verificationCode;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }


        public string ApiId { get; set; }
        public string ApiHash { get; set; }
        public string PhoneNumber { get; set; }
        public string VerificationCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        
        public string Config(string what)
        {
            return what switch
            {
                "api_id" => ApiId,
                "api_hash" => ApiHash,
                "phone_number" => PhoneNumber,
                "verification_code" => null,
                "first_name" => FirstName,
                "last_name" => LastName,
                _ => what == "password" ? Password : null
            };
        }
        
    }
}