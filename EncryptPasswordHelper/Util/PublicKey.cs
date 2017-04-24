using System;
using System.Text;

namespace EncryptPasswordHelper.Util
{
    public static class PublicKey
    {        
        public static string Parse(string value) => Encoding.UTF8.GetString(Convert.FromBase64String(value));        

        public static string From(string xml) => Convert.ToBase64String(Encoding.UTF8.GetBytes(xml));        
    }
}
