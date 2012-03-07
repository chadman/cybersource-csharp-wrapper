using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CybersourceAPI.Model {
    
    [XmlRoot("Request")]
    public class Request {

        #region Private Properties
        private string _requestDateString;
        #endregion Private Properties

        [XmlAttribute("MerchantReferenceNumber")]
        public string MerchantReferenceNumber { get; set; }

        [XmlAttribute("RequestDate")]
        public string RequestDateString {
            get {
                return _requestDateString;
            }
            set {
                _requestDateString = value;
                if (value != null && value.Length > 10) {
                    try {
                        RequestDate = DateTime.Parse(value);
                    }
                    catch (Exception e) {
                        RequestDate = new DateTime();
                    }
                }
                else
                    RequestDate = new DateTime();
            }
        }

        [XmlIgnore]
        public DateTime RequestDate { get; set; }

        [XmlAttribute("RequestID")]
        public string RequestID { get; set; }

        [XmlAttribute("SubscriptionID")]
        public string SubscriptionID { get; set; }

        [XmlAttribute("Source")]
        public string Source { get; set; }

        [XmlAttribute("User")]
        public string User { get; set; }

        [XmlAttribute("TransactionReferenceNumber")]
        public string TransactionReferenceNumber { get; set; }

        [XmlAttribute("PredecessorRequestID")]
        public string PredecessorRequestID { get; set; }

        [XmlElement("BillTo")]
        public BillTo BillTo { get; set; }

        [XmlElement("ShipTo")]
        public ShipTo ShipTo { get; set; }

        [XmlElement("PaymentMethod")]
        public PaymentMethod PaymentMethod { get; set; }

        [XmlArray("LineItems")]
        [XmlArrayItem("LineItem")]
        public List<LineItem> LineItems { get; set; }

        [XmlArray("ApplicationReplies")]
        [XmlArrayItem("ApplicationReply")]
        public List<ApplicationReply> ApplicationReplies { get; set; }

        [XmlElement("PaymentData")]
        public PaymentData PaymentData { get; set; }

    }
}
