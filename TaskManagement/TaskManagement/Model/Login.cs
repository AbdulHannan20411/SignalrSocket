namespace TaskManagement.Model
{
    public class Login
    {
        public long Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int? OTP { get; set; }
        public DateTime? OTPExpiry { get; set; }
        public User? User { get; set; }
    }
}
