using System.Xml.Serialization;

namespace TrxParserLibrary.Models
{
    public class ResultSummary
    {
        [XmlAttribute("outcome")]
        public string Outcome { get; set; }

        [XmlElement("Counters")]
        public Counters Counters { get; set; }
    }
}
