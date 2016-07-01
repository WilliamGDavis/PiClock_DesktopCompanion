﻿using System;
using System.Collections.Generic;
using PiClock_DesktopCompanion.Properties;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace PiClock_DesktopCompanion.Classes
{
    class WebServiceCall : IDisposable
    {
        //URI of the web service resource
        public string Uri { get; set; }
        //Allow a user to pass in a Uri (currently used for the Configuration
        public string CustomUri { get; set; }
        //Dictionary of paramaters to pass to the web service
        public Dictionary<string, string> ParamDictionary { get; set; }

        //Allow a user to optionally pass in the uri, but set it to the current settings value if there isn't one passed in
        public WebServiceCall(Dictionary<string, string> paramDictionary = null, string uri = null)
        {
            Uri = (uri == null) ? Settings.Default.UriPrefix : uri;
            ParamDictionary = paramDictionary;
        }

        //Connect to a web service and retrieve the data (JSON format) using the POST verb
        public async Task<HttpResponseMessage> PostJsonToRpcServer()
        {
            //Return a null if the URI or the ParamDictionary is empty(null)
            if (null == Uri || null == ParamDictionary)
            { return null; }

            //Make sure the ParamDictionary has an action, used by the RPC server
            if (!ParamDictionary.ContainsKey("action"))
            { return null; }

            string apiUsername = (ParamDictionary.ContainsKey("ApiUsername")) ? ParamDictionary["ApiUsername"] : Settings.Default.ApiUsername;
            string apiPassword = (ParamDictionary.ContainsKey("ApiPassword")) ? ParamDictionary["ApiPassword"] : Settings.Default.ApiPassword;

            using (var HttpClient = new HttpClient())
            {
                //Client headers
                string basicAuth = string.Format("{0}:{1}", apiUsername, apiPassword);
                HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(basicAuth)));

                //Content headers
                var content = new StringContent(JsonConvert.SerializeObject(ParamDictionary));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //Return JSON from the RPC server
                return await HttpClient.PostAsync(Uri, content);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~WebServiceCall() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
