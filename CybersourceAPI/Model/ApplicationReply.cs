using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CybersourceAPI.Model {

    [XmlRoot("ApplicationReply")]
    public class ApplicationReply {

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlElement("RCode")]
        public string RCode { get; set; }

        [XmlElement("RFlag")]
        public string RFlag { get; set; }

        [XmlElement("RMsg")]
        public string RMsg { get; set; }
    }
}
