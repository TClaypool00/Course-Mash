namespace CourseMash.app.App_Code.BLL
{
    public interface IBCryptService
    {
        public string HashPassword(string text);

        public bool VerifyPassword(string text, string hash);
    }
}
