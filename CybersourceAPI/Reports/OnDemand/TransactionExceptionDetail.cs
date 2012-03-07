using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CybersourceAPI.Reports.OnDemand {
    public class TransactionExceptionDetail : CybersourceAPI.Reports.BaseReport {

        /// <summary>
        /// This report provides detailed information about transactions that were flagged by CyberSource or by the processor because of errors in requests for follow-on transactions. 
        /// When these errors occur, you are notified in the Message Center. These notifications remain in the Message Center for seven days. 
        /// The following figures show the Message Center and descriptions of transaction errors.
        /// </summary>
        /// <param name="qo">The filters in which to search for the report</param>
        /// <returns></returns>
        public static string GetTransactionExceptionDetails(CybersourceAPI.QueryObject.TransactionExceptionDetailQO qo) {

            // The report can not have a start and end date bigger than 24 hours
            // Expires differences. This is ridiculous... c'mon microsoft did you really need to make it this hard
            int secondsDifference = 0;
            TimeSpan timeDifference = qo.EndDateAndTime.Subtract(qo.StartDateAndTime);

            if (timeDifference.TotalHours > 24) {
                throw new Exception("The transaction Exception Detail report can only be run for 24 hours. The time span in hours is " + timeDifference.TotalHours);
            }

            // Single transaction URL
            string url = string.Format("https://ebc.cybersource.com/ebc/TransactionExceptionDetailReportRequest.do");
            return Call(url, qo);
        }
    }
}
