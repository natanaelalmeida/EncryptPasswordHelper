using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncryptPasswordHelper.Crypto;

namespace EncryptPasswordHelper.Tests
{
    [TestClass]
    public class CryptoServiceTests
    {
        private readonly CryptoService cryptoService = new CryptoService("InternalKey#3005");        

        [TestMethod]
        [TestCategory("CryptoService")]
        public void EncryptPassword()
        {
            string pass = "test123";

            var password = cryptoService.Encrypt(pass);
            Assert.IsTrue(password.Password.Length > 0);
        }

        [TestMethod]
        [TestCategory("CryptoService")]
        public void DescryptPassword()
        {
            string pass = "test";

            CryptoService cryptoService = new CryptoService("G3soft#2628");
            var data = cryptoService.Encrypt(pass);
            var descrypt = cryptoService.Descrypt(data.Password, data.PublicKey);

            Assert.IsTrue(descrypt == pass);
        }
    }
}
