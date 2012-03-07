using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using CybersourceAPI.Helpers;

namespace CybersourceAPI.Reports.OnDemand {
    public class SingleTransaction : CybersourceAPI.Reports.BaseReport {

        /// <summary>
        /// Calls the Cybersource API to retrieve a single transaction from their system
        /// </summary>
        /// <param name="qo">The filters in which to search for the transaction</param>
        /// <returns></returns>
        public static CybersourceAPI.Model.Report GetSingleTransaction(CybersourceAPI.QueryObject.SingleTransactionQO qo) {

            // Single transaction URL
            string url = string.Format("https://ebc.cybersource.com/ebc/Query");

            // There are a few things that are reequired in order to call Cybersource API
            /// First is the merchant is always required.
            if (string.IsNullOrEmpty(qo.MerchantID)) {
                throw new Exception("Merchant ID is required to call the cybersource API.");
            }

            // Either the merchant reference number and targetDate is required OR the requestID, both cannot be supplied
            if (!string.IsNullOrEmpty(qo.MerchantReferenceNumber)) {
                if (!qo.TargetDate.HasValue) {
                    throw new Exception("Since MerchantReferenceNumber is supplied, a TargetDate is required.");
                }

                if (!string.IsNullOrEmpty(qo.RequestID)) {
                    throw new Exception("Since the MerchantReferenceNumber is supplied, the RequestID must be null.");
                }
            }

            return Serialization.DeserializeFromXmlString<CybersourceAPI.Model.Report>(Call(url, qo));
        }
    }
}