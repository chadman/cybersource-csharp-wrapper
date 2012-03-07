using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CybersourceAPI.Model {
    public class LineItem {

        [XmlAttribute("Number")]
        public int Number { get; set; }

        [XmlElement("Quantity")]
        public int Quantity { get; set; }

        [XmlElement("UnitPrice")]
        public decimal UnitPrice { get; set; }

        [XmlElement("TaxAmount")]
        public decimal TaxAmount { get; set; }

        [XmlElement("MerchantProductSKU")]
        public string MerchantProductSKU { get; set; }

        [XmlElement("ProductName")]
        public string ProductName { get; set; }

        [XmlElement("ProductCode")]
        public string ProductCode { get; set; }
    }
}
