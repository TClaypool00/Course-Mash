using CourseMash.app.App_Code.BLL;

namespace CourseMash.app.App_Code.DAL
{
    public class BCryptService : IBCryptService
    {
        public string HashPassword(string text)
        {
            return BCrypt.Net.BCrypt.HashPassword(text);
        }

        public bool VerifyPassword(string text, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(text, hash);
        }
    }
}
