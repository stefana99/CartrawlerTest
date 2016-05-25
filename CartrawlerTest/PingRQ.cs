using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CartrawlerTest
{
    [XmlRoot(ElementName = "OTA_PingRQ", Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public class PingRQ
    {

        private XmlSerializerNamespaces xmlns;

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Xmlns
        {
            get
            {
                if (xmlns == null)
                {
                    xmlns = new XmlSerializerNamespaces();
                    xmlns.Add("xsi", "http://");
                }
                return xmlns;
            }
            set { xmlns = value; }
        }

        [XmlAttribute("uid", Namespace = "http://xxx")]
        public int Uid { get; set; }

        [XmlAttribute]
        public string Version { get; set; } = "1.003";

        [XmlElement("EchoData")]
        public string EchoData { get; set; }
    }
}
