using System;
using System.Text;
using System.Security.Cryptography;
using EncryptPasswordHelper.Util;
using EncryptPasswordHelper.Entities;

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

        public DataPassword Encrypt(string password)
        {            
            var privKey = _rsaProvider.ExportParameters(false);
            var pub = _rsaProvider.ExportParameters(true);

            _xml = _rsaProvider.ToXmlString(true);
            _rsaProvider.ImportParameters(privKey);

            var publicKey = PublicKey.From(_xml);
            var pass = _rsaProvider.Encrypt(ConvertToByte($"{ _Internalkey }_{ password }"), false);
            
            return new DataPassword(pass, publicKey);
        }        

        public string Descrypt(byte[] password, string publicKey)
        {
            _rsaProvider.FromXmlString(PublicKey.Parse(publicKey));             
            return Encoding.UTF8.GetString(_rsaProvider.Decrypt(password, false)).Replace(_Internalkey + "_", "");
        }

        private byte[] ConvertToByte(string value) => new ASCIIEncoding().GetBytes(value);        

        public void Dispose()
        {
            _rsaProvider.Dispose();            
        }
    }
}
