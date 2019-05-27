using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Library
{
  public class StringHelper
  {
    /// <summary>
    /// Call this method to generate a random string, for example, like a password
    /// </summary>
    /// <param name="length">How long to make the resulting string</param>
    /// <returns>A random set of values</returns>
    public static string CreateRandomString(int maxLength)
    {
      const string CHAR_LIST = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@";
      StringBuilder sb = new StringBuilder(32);
      byte[] buffer;
      uint num;

      using (RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider()) {
        buffer = new byte[sizeof(uint)];

        for (int i = maxLength; i > 0; i--) {
          csp.GetBytes(buffer);
          num = BitConverter.ToUInt32(buffer, 0);
          sb.Append(CHAR_LIST[(int)(num % (uint)CHAR_LIST.Length)]);
        }
      }

      return sb.ToString();
    }
    
    /// <summary>
    /// Is the value passed in a valid email format?
    /// </summary>
    /// <param name="email">The email to check</param>
    /// <returns>True if the email is valid, otherwise false.</returns>
    public static bool IsValidEmail(string email)
    {
      return Regex.IsMatch(email, (@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"));
    }


    /// <summary>
    /// Pass in a string and this method will determine if it is all lower case characters or not.
    /// </summary>
    /// <param name="value">The string to check</param>
    /// <returns>True if the string passed in is all lower case, otherwise false.</returns>
    public static bool IsAllLowerCase(string value)
    {
      return new Regex(@"^([^A-Z])+$").IsMatch(value);
    }

    /// <summary>
    /// Pass in a string and this method will determine if it is all upper case characters or not.
    /// </summary>
    /// <param name="value">The string to check</param>
    /// <returns>True if the string passed in is all upper case, otherwise false.</returns>
    public static bool IsAllUpperCase(string value)
    {
      return new Regex(@"^([^a-z])+$").IsMatch(value);
    }
  }
}
