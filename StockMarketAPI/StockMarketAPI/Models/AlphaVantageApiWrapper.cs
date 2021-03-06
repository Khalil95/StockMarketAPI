﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace StockMarketAPI.Models
{
    public static class AlphaVantageApiWrapper
    {
        public static async Task<AlphaVantageRootObject> GetTechnical(string symbol, string apiKey)
        {
            var stringRequest = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=";
            stringRequest += symbol;
            stringRequest += "&apikey=" + apiKey;

            var apiData = await CallAlphaVantageApi(stringRequest);

            //convertir en object avec rootAvmachin

            return null;
        }

        public class ApiParam
        {
            public string ParamName;
            public string ParamValue;

            public ApiParam(string paramNameIn, string paramValueIn)
            {
                ParamName = paramNameIn;
                ParamValue = paramValueIn;
            }

            public string ToApiString()
            {
                return $"&{ParamName}={ParamValue}";
            }
        }

        public static string ToDescription(this Enum enumeration)
        {
            var type = enumeration.GetType();
            var memInfo = type.GetMember(enumeration.ToString());
            if (memInfo.Length <= 0) return enumeration.ToString();
            var attrs = memInfo[0].GetCustomAttributes(typeof(EnumDescription), false);
            return attrs.Length > 0 ? ((EnumDescription)attrs[0]).Text : enumeration.ToString();
        }

        public static async Task<JObject> CallAlphaVantageApi(string stringRequest)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var res = await client.GetStringAsync(stringRequest);
                    return JsonConvert.DeserializeObject<JObject>(res);
                }
            }
            catch (Exception e)
            {
                //fatal error
                return null;
            }
        }

        public class AlphaVantageRootObject
        {
            public MetaData MetaData;
            public List<TechnicalDataDate> TechnicalsByDate;
        }

        public class MetaData
        {
            public string Function;
            public string Interval;
            public string SeriesType;
            public string Symbol;
        }

        public class TechnicalDataDate
        {
            public DateTime Date;
            public List<TechnicalDataObject> Data;
        }

        public class TechnicalDataObject
        {
            public string TechnicalKey { get; set; }
            public double TechnicalValue { get; set; }
        }

        public class EnumDescription : Attribute
        {
            public string Text { get; }

            public EnumDescription(string text)
            {
                Text = text;
            }
        }

        public enum AvIntervalEnum
        {
            [EnumDescription("1min")] OneMinute,
            [EnumDescription("5min")] FiveMinutes,
            [EnumDescription("15min")] FifteenMinutes,
            [EnumDescription("30min")] ThirtyMinutes,
            [EnumDescription("60min")] SixtyMinutes,
            [EnumDescription("daily")] Daily,
            [EnumDescription("weekly")] Weekly,
            [EnumDescription("monthly")] Monthly
        }

        public enum AvSeriesType
        {
            [EnumDescription("close")] Close,
            [EnumDescription("open")] Open,
            [EnumDescription("high")] High,
            [EnumDescription("low")] Low,
        }
    }
}