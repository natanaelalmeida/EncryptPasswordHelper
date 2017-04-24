namespace EncryptPasswordHelper.Entities
{
    public class DataPassword
    {
        internal DataPassword(byte[] password, string publicKey)
        {
            Password = password;
            PublicKey = publicKey;
        }

        public byte[] Password { get; private set; }
        public string PublicKey { get; private set; }
    }
}
