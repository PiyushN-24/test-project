using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Task_Mvc.BaseEntity
{
    public class ApiBaseUrl
    {
        string _baseUrl;
        public ApiBaseUrl()
        {
            //_baseUrl = "http://localhost:44386/api/";
            _baseUrl = ConfigurationManager.AppSettings["BaseApiUrl"];

            //_baseUrl = AppSettingsReaders.GetAppSettings().baseUrl;
        }
        public string baseUrl { get { return _baseUrl; } private set {; } }
    }

    public class TrackNPayPayMode
    {
        string _PaymentMode;
        public TrackNPayPayMode()
        {
            _PaymentMode = "live";
            //_PaymentMode = AppSettingsReaders.GetAppSettings().PaymentMode;
        }
        public string PaymentMode { get { return _PaymentMode; } private set {; } }
    }
}