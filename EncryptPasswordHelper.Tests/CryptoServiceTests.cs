using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncryptPasswordHelper.Crypto;

namespace EncryptPasswordHelper.Tests
{
    [TestClass]
    public class CryptoServiceTests
    {
        private readonly CryptoService cryptoService = new CryptoService("G3soft#2628");        

        [TestMethod]
        [TestCategory("CryptoService")]
        public void EncryptPassword()
        {
            string pass = "test123";

            var password = cryptoService.Encrypt(pass, "ExistspublicKeyTest");
            Assert.IsTrue(password.Length > 0);
        }

        [TestMethod]
        [TestCategory("CryptoService")]
        public void DescryptPassword()
        {
            string pass = "test";

            CryptoService cryptoService = new CryptoService("G3soft#2628");
            var password = cryptoService.Encrypt(pass, "publicKeyTest");
            var descrypt = cryptoService.Descrypt(password, "publicKeyTest");

            Assert.IsTrue(descrypt == pass);
        }

        [TestMethod]
        [TestCategory("CryptoService")]
        public void IsExistsPublicKey() => Assert.IsTrue(cryptoService.IsExistsPublicKey("ExistspublicKeyTest"));        

        [TestMethod]
        [TestCategory("CryptoService")]
        public void IsNotExistsPublicKey() => Assert.IsFalse(cryptoService.IsExistsPublicKey("NotExistsPublicKeyTest"));
    }
}
