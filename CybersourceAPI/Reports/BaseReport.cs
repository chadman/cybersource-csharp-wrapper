using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace CybersourceAPI.Reports {
    public class BaseReport {

        #region Properties

        #endregion Properties

        protected static string Call(string url, CybersourceAPI.QueryObject.BaseQO qo) {

            string returnXML = null;
            
            try {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                // Set the content type of the data being posted.
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";

                request.Headers.Add("Authorization", "Basic " + EncodeTo64(string.Format("{0}:{1}", qo.Username, qo.Password)));

                byte[] byteArray = Encoding.UTF8.GetBytes(qo.FormEncode());
                request.ContentLength = byteArray.Length;

                using (var input = request.GetRequestStream()) {
                    input.Write(byteArray, 0, byteArray.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Get the stream associated with the response.
                Stream receiveStream = response.GetResponseStream();

                // Pipes the stream to a higher level stream reader with the required encoding format. 
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8)) {
                    returnXML = readStream.ReadToEnd();
                }

                receiveStream.Close();
                response.Close();
            }
            catch (WebException we) {

                HttpWebResponse response = ((System.Net.HttpWebResponse)(we.Response));

                throw we;
            }

            return returnXML;
        }

        protected static string EncodeTo64(string toEncode) {

            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;
        }
    }
}
