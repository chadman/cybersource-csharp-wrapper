using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CybersourceAPI.QueryObject {
    public class TransactionExceptionDetailQO : BaseQO {

        private string[] _formValues = null;
        public override string[] FormValues {
            get {

                if (_formValues == null) {
                    // Need to know a head of time how many pairs there will be

                    int pairCount = 6;
                    string[] nameValuePairs = new string[pairCount * 2];

                    nameValuePairs[0] = "merchantID";
                    nameValuePairs[1] = this.MerchantID;
                    nameValuePairs[2] = "startDate";
                    nameValuePairs[3] = this.StartDateAndTime.ToString("yyyy-MM-dd");
                    nameValuePairs[4] = "startTime";
                    nameValuePairs[5] = this.StartDateAndTime.ToString("HH:mm:ss");
                    nameValuePairs[6] = "endDate";
                    nameValuePairs[7] = this.EndDateAndTime.ToString("yyyy-MM-dd");
                    nameValuePairs[8] = "endTime";
                    nameValuePairs[9] = this.EndDateAndTime.ToString("HH:mm:ss");
                    nameValuePairs[10] = "format";
                    nameValuePairs[11] = this.ReportFormat == Enum.ReportFormat.XML ? "xml" : "csv";


                    _formValues = nameValuePairs;
                }

                return _formValues;

            }
            set {
                base.FormValues = value;
            }
        }

        /// <summary>
        /// The date where to begin the search for transactions
        /// </summary>
        public DateTime StartDateAndTime { get; set; }

        /// <summary>
        /// The date where to end the search for transactions
        /// </summary>
        public DateTime EndDateAndTime { get; set; }

        /// <summary>
        /// The format the report should be returned as
        /// </summary>
        public CybersourceAPI.Enum.ReportFormat ReportFormat { get; set; }

    }
}
