using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CybersourceAPI.Model {

    [XmlRoot("PaymentData")]
    public class PaymentData {

        [XmlElement("PaymentRequestID")]
        public string PaymentRequestID { get; set; }

        [XmlElement("PaymentProcessor")]
        public string PaymentProcessor { get; set; }

        [XmlElement("Amount")]
        public decimal Amount { get; set; }

        [XmlElement("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [XmlElement("TotalTaxAmount")]
        public decimal TotalTaxAmount { get; set; }

        [XmlElement("EventType")]
        public string EventType { get; set; }

        [XmlElement("AVSResultMapped")]
        public string AVSResultMapped { get; set; }

        [XmlElement("AVSResult")]
        public string AVSResult { get; set; }

        [XmlElement("AuthorizationCode")]
        public string AuthorizationCode { get; set; }
    }
}
