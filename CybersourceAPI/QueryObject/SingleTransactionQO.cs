using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CybersourceAPI.QueryObject {
    public class SingleTransactionQO : BaseQO {

        private string[] _formValues = null;
        public override string[] FormValues {
            get {

                if (_formValues == null) {
                    // Need to know a head of time how many pairs there will be

                    int pairCount = 3;
                    int count = 6;


                    if (!string.IsNullOrEmpty(this.MerchantReferenceNumber)) {
                        pairCount += 2;
                    }
                    else if (!string.IsNullOrEmpty(this.RequestID)) {
                        pairCount += 1;
                    }

                    string[] nameValuePairs = new string[pairCount * 2];

                    nameValuePairs[0] = "merchantID";
                    nameValuePairs[1] = this.MerchantID;
                    nameValuePairs[2] = "type";
                    nameValuePairs[3] = "transaction";
                    nameValuePairs[4] = "subtype";
                    nameValuePairs[5] = "transactionDetail";

                    if (!string.IsNullOrEmpty(this.MerchantReferenceNumber)) {
                        nameValuePairs[count] = "merchantReferenceNumber";
                        count++;

                        nameValuePairs[count] = this.MerchantReferenceNumber;
                        count++;

                        // The Target Date is required is just set it here
                        nameValuePairs[count] = "targetDate";
                        count++;
                        nameValuePairs[count] = this.TargetDate.GetValueOrDefault().ToString("yyyyMMdd");
                        count++;
                    }
                    else {

                        if (!string.IsNullOrEmpty(this.RequestID)) {
                            nameValuePairs[count] = "requestID";
                            count++;
                            nameValuePairs[count] = this.RequestID;
                            count++;
                        }
                    }

                    _formValues = nameValuePairs;
                }

                return _formValues;

            }
            set {
                base.FormValues = value;
            }
        }

        /// <summary>
        /// Your merchant reference number. This must be used in conjunction with the TargetDate parameter.
        /// If you choose this combination, do not send in the RequestID parameter. If you do so, the query request will be ignored
        /// </summary>
        public string MerchantReferenceNumber { get; set; }

        /// <summary>
        /// Date to include in report
        /// </summary>
        public DateTime? TargetDate { get; set; }


        /// <summary>
        /// Number of the transaction that you want to see
        /// </summary>
        public string RequestID { get; set; }

    }
}
