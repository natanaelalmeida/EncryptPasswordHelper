using System;
using System.Text;
using System.Security.Cryptography;
using EncryptPasswordHelper.Util;

namespace EncryptPasswordHelper.Crypto
{
    public sealed class CryptoService : IDisposable
    {
        private string _Internalkey;               
        private const int _KeySize = 2048;

        private string _xml;

        private RSACryptoServiceProvider _rsaProvider;        

        public CryptoService(string internalKey)
        {
            _Internalkey = internalKey;                                    
            _rsaProvider = new RSACryptoServiceProvider(_KeySize);
        }

        public byte[] Encrypt(string password, string publicKey)
        {
            if (XmlHelper.IsNotExists(publicKey))
                throw new Exception("Public key is already being used");

            var privKey = _rsaProvider.ExportParameters(false);
            var pub = _rsaProvider.ExportParameters(true);

            _xml = _rsaProvider.ToXmlString(true);
            _rsaProvider.ImportParameters(privKey);
            XmlHelper.Save(_xml, publicKey);

            return _rsaProvider.Encrypt(ConvertToByte($"{ _Internalkey }_{ password }"), false);
        }        

        public string Descrypt(byte[] password, string publicKey)
        {
            _rsaProvider.FromXmlString(XmlHelper.Load(publicKey));             
            return Encoding.UTF8.GetString(_rsaProvider.Decrypt(password, false)).Replace(_Internalkey + "_", "");
        }

        private byte[] ConvertToByte(string value) => new ASCIIEncoding().GetBytes(value);

        public bool IsExistsPublicKey(string publicKey) => XmlHelper.IsNotExists(publicKey);

        public void Dispose()
        {
            _rsaProvider.Dispose();            
        }
    }
}
