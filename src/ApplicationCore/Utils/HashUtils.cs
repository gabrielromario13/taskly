using System.Security.Cryptography;
using System.Text;

namespace ApplicationCore.Utils;

public static class HashUtils
{
    public static string HashPassword(string password)
    {
        const string initialSalt = "b147V2";
        const string finalSalt = "cw@6492";
        password = initialSalt + password + finalSalt;

        var encodedPassword = Encoding.UTF8.GetBytes(password);
        var hashedPassword = MD5.HashData(encodedPassword);
        var fullPassword = Convert.ToBase64String(hashedPassword);

        if (fullPassword.Length > 30)
            fullPassword = fullPassword[..30];

        return fullPassword;
    }
}