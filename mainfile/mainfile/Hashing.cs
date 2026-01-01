namespace mainfile;
using System.Security.Cryptography;
using System.Text;

public class Hashing
{
    // Convertește un text simplu într-un hash SHA256 (șir unic de caractere)
    public static string ToSHA256(string s)
    {
        using var sha256= SHA256.Create();
        // Transformăm string-ul în bytes și calculăm hash-ul
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

        var sb = new StringBuilder();
        // Convertim fiecare byte în format hexazecimal pentru a obține string-ul final
        for(int i=0;i<bytes.Length;i++)
        {
            sb.Append(bytes[i].ToString("x2"));
        }
        return sb.ToString();
    }
}