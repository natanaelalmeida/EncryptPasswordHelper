using System;

namespace EncryptPasswordHelper.Configuration.Properties
{
    public class RegisterPublicKey
    {
        public RegisterPublicKey(string publicKey)
        {
            PublicKey = publicKey;
            CreateDate = DateTime.Now;
        }

        public string PublicKey { get; private set; }
        public DateTime CreateDate { get; private set; }
    }
}
