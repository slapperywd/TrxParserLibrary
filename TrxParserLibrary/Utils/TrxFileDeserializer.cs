using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TrxParserLibrary.Utils
{
    /// <summary>
    /// Deserializes trx files
    /// </summary>
    public class TrxFileDeserializer
    {
        /// <summary>
        /// Deserializes Trx 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns>T</returns>
        public static T Deserialize<T>(string fileName) where T : class
        {
            RemoveXmlnsAndRewriteFile(fileName);
            T entity;

            var xs = new XmlSerializer(typeof(T));
            using (Stream sr = File.OpenRead(fileName))
            {
                entity = (T)xs.Deserialize(sr);
            }

            return entity;
        }

        /// <summary>
        /// Deletes all xmlns namespaces in xml file and and overwrites file
        /// </summary>
        /// <param name="fileName">path to file with name included</param>
        private static void RemoveXmlnsAndRewriteFile(string fileName)
        {
            Regex rgx = new Regex("xmlns=\".*?\" ?");
            var fileContent = rgx.Replace(File.ReadAllText(fileName), string.Empty);
            XDocument xdoc = XDocument.Parse(fileContent);
            xdoc.Save(fileName);
        }
    }
}
