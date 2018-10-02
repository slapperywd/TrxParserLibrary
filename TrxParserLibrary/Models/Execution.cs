using System.Xml.Serialization;

namespace TrxParserLibrary.Models
{
    public class Execution
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}
