using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CybersourceAPI.Model {

    [XmlRoot("ShipTo")]
    public class ShipTo {

        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("Address1")]
        public string Address1 { get; set; }

        [XmlElement("Address2")]
        public string Address2 { get; set; }

        [XmlElement("City")]
        public string City { get; set; }

        [XmlElement("State")]
        public string State { get; set; }

        [XmlElement("Zip")]
        public string Zip { get; set; }

        [XmlElement("Country")]
        public string Country { get; set; }
    }
}