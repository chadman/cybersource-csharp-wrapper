using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CybersourceAPI.QueryObject {
    public class BaseQO {

        public virtual string[] FormValues { get; set; }

        #region Public Properties

        /// <summary>
        /// Your cybersource ID :: This property is required
        /// </summary>
        public string MerchantID { get; set; }

        /// <summary>
        /// The user name capable with enough rights to call the Cybersource API
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password to the username
        /// </summary>
        public string Password { get; set; }

        #endregion Public Properties

        #region Private Methods
        internal string FormEncode() {
            if (this.FormValues.Length % 2 != 0) {
                throw new ArgumentException("Pairs please.");
            }
            var bldr = new StringBuilder();
            for (int i = 1; i < this.FormValues.Length; i += 2) {
                WeDoNotSupportEncodingTheValues(this.FormValues[i - 1]);
                WeDoNotSupportEncodingTheValues(this.FormValues[i]);
                bldr.AppendFormat("{0}={1}&", this.FormValues[i - 1], this.FormValues[i]);
            }//while
            if (bldr.Length > 0) bldr.Length -= 1; //remove final '&'
            return bldr.ToString();
        }


        private void WeDoNotSupportEncodingTheValues(string txt) {
            if (txt.Contains('=') || txt.Contains('&') || txt.Contains(' ')
                //... more special characters?
             ) {
                throw new NotSupportedException();
            }
        }
        #endregion Private Methods
    }
}
