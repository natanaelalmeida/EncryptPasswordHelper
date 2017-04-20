using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace EncryptPasswordHelper.Util
{
    public static class XmlHelper
    {
        private const string Path = "EphXML";

        public static string Load(string fileName)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load($"{ Path }/{ fileName }.xml");
            return xmlDoc.InnerXml;
        }

        public static void Save(string xml, string fileName)
        {
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            xmlDoc.Save($"{ Path }/{ fileName }.xml");
        }

        public static bool IsNotExists(string publicKey)
        {
            if (!Directory.Exists(Path))
                return false;

            List<string> lstFiles = Directory.GetFiles(Path).ToList() ?? new List<string>();                    
            return lstFiles.Any(l => l == $@"EphXML\{ publicKey }.xml");
        }
    }
}
