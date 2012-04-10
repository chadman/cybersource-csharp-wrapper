using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CybersourceAPI;
using CybersourceAPI.QueryObject;
using CybersourceAPI.Model;

namespace CybersourceAPI.Tests.Integration {
    [TestClass]
    public class SingleTransactionReport {

        public string Username = "";
        public string Password = "";
        public string MerchantID = "";
        public string RequestID = "";

        // Variables set up for the test environment
        public string TestUsername = "";
        public string TestPassword = "";
        public string TestMerchantID = "";


        [TestMethod]
        public void single_transaction_error_no_merchant_id() {

            try {
                SingleTransactionQO qo = new SingleTransactionQO();

                CybersourceAPI.Reports.OnDemand.SingleTransaction.GetSingleTransaction(qo);
                Assert.Fail("The transaction should have resulted in anm error.");
            }

            catch (Exception e) {
                Assert.AreEqual("Merchant ID is required to call the cybersource API.", e.Message);
            }


        }

        [TestMethod]
        public void single_transaction_error_no_target_date() {

            try {
                SingleTransactionQO qo = new SingleTransactionQO();
                qo.MerchantID = "testmerchantid";
                qo.MerchantReferenceNumber = "1295766";
                CybersourceAPI.Reports.OnDemand.SingleTransaction.GetSingleTransaction(qo);
                Assert.Fail("The transaction should have resulted in anm error.");

            }
            catch (Exception e) {
                Assert.AreEqual("Since MerchantReferenceNumber is supplied, a TargetDate is required.", e.Message);
            }

        }

        [TestMethod]
        public void single_transaction_error_merchant_reference_number_and_requrest_id() {

            try {
                SingleTransactionQO qo = new SingleTransactionQO();
                qo.RequestID = "testrequestID";
                qo.MerchantReferenceNumber = "1295766";
                qo.TargetDate = DateTime.UtcNow;
                qo.MerchantID = "testmerchant";
                CybersourceAPI.Reports.OnDemand.SingleTransaction.GetSingleTransaction(qo);
                Assert.Fail("The transaction should have resulted in anm error.");

            }
            catch (Exception e) {
                Assert.AreEqual("Since the MerchantReferenceNumber is supplied, the RequestID must be null.", e.Message);
            }
        }

        [TestMethod]
        public void single_transaction_get_by_request_id() {
            SingleTransactionQO qo = new SingleTransactionQO();
            qo.MerchantID = this.MerchantID;
            qo.RequestID = this.RequestID;
            qo.Username = this.Username;
            qo.Password = this.Password;

            Assert.IsNotNull(CybersourceAPI.Reports.OnDemand.SingleTransaction.GetSingleTransaction(qo));
        }

        [TestMethod]
        public void single_transaction_get_by_merchant_reference_code() {
            SingleTransactionQO qo = new SingleTransactionQO();
            qo.MerchantID = this.MerchantID;
            qo.MerchantReferenceNumber = System.Web.HttpUtility.UrlEncode("Tithe - Yukon Campus");
            qo.TargetDate = new DateTime(2012, 3, 5);
            qo.Username = this.Username;
            qo.Password = this.Password;

            Assert.IsNotNull(CybersourceAPI.Reports.OnDemand.SingleTransaction.GetSingleTransaction(qo));
        }

        [TestMethod]
        public void single_transaction_get_by_merchant_reference_code_for_test() {

            SingleTransactionQO qo = new SingleTransactionQO();
            qo.IsTestEnvironment = true;
            qo.MerchantID = this.TestMerchantID;
            qo.MerchantReferenceNumber = "";
            qo.TargetDate = new DateTime(2012, 4, 10);
            qo.Username = this.TestUsername;
            qo.Password = this.TestPassword;

            Report report = CybersourceAPI.Reports.OnDemand.SingleTransaction.GetSingleTransaction(qo);

            Assert.IsNotNull(report);

        }
    }
}
