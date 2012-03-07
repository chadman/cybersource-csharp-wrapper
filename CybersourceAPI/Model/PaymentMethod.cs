using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CybersourceAPI.Model {
    
    [XmlRoot("PaymentMethod")]
    public class PaymentMethod {

        [XmlElement("Card")]
        public Card Card { get; set; }
    }

    [XmlRoot("Card")]
    public class Card {
        
        [XmlElement("AccountSuffix")]
        public string AccountSuffix { get; set; }

        [XmlElement("ExpirationMonth")]
        public int ExpirationMonth { get; set; }

        [XmlElement("ExpirationYear")]
        public int ExpirationYear { get; set; }

        [XmlElement("CardType")]
        public string CardType { get; set; }

    }
}