using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrxParserLibrary.Models
{
    public class TestDefinitions
    {
        [XmlElement("UnitTest")]
        public List<UnitTest> UnitTests { get; set; }
    }
}
