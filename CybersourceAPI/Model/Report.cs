using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CybersourceAPI.Model {

    [XmlRoot("Report", Namespace="https://ebc.cybersource.com/ebc/reports/dtd/tdr_1_8.dtd"), XmlType("Report")]
    public class Report {

        #region Private Properties
        private string _reportStartDateString;
        private string _reportEndDateString;
        #endregion Private Properties

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Version")]
        public string Version { get; set; }

        [XmlAttribute("MerchantID")]
        public string MerchantID { get; set; }

        [XmlAttribute("ReportStartDate")]
        public string RequestStartDateString {
            get {
                return _reportStartDateString;
            }
            set {
                _reportStartDateString = value;
                if (value != null && value.Length > 6) {
                    try {
                        ReportStartDate = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss.fffzzz", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    }
                    catch {
                        ReportStartDate = new DateTime();
                    }
                }
                else
                    ReportStartDate = new DateTime();
            }
        }

        [XmlIgnore]
        public DateTime? ReportStartDate { get; set;  }

        [XmlAttribute("ReportEndDate")]
        public string ReportEndDateString {
            get {
                return _reportEndDateString;
            }
            set {
                _reportEndDateString = value;
                if (value != null && value.Length > 10) {
                    try {
                        EndDate = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss.fffzzz", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception e) {
                        EndDate = new DateTime();
                    }
                }
                else
                    EndDate = new DateTime();
            }
        }

        [XmlIgnore]
        public DateTime EndDate { get; set; }

        [XmlArray("Requests")]
        [XmlArrayItem("Request")]
        public List<Request> Requests { get; set; }
    }
}
