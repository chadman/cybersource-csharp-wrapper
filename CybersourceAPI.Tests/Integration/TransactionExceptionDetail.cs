using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CybersourceAPI.QueryObject;

namespace CybersourceAPI.Tests.Integration {
    [TestClass]
    public class TransactionExceptionDetail {

        public string Username = "";
        public string Password = "";
        public string MerchantID = "";

        [TestMethod]
        public void transaction_exception_detail_get_report() {

            TransactionExceptionDetailQO qo = new TransactionExceptionDetailQO();
            qo.MerchantID = this.MerchantID;
            qo.Username = this.Username;
            qo.Password = this.Password;
            qo.StartDateAndTime = DateTime.Now.AddHours(-10);
            qo.EndDateAndTime = DateTime.Now;
            qo.ReportFormat = Enum.ReportFormat.XML;

            Assert.IsNotNull(CybersourceAPI.Reports.OnDemand.TransactionExceptionDetail.GetTransactionExceptionDetails(qo));
        }
    }
}
