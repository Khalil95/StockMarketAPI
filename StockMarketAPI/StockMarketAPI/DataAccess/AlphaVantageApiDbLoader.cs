using StockMarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StockMarketAPI.DataAccess
{
    public static class AlphaVantageApiDbLoader
    {

            public static async Task TestAsync()
            {
                var API_KEY = "X29IZ87X3MQOLPUZ";

                var StockTickers = new List<string> { "AAPL" };

                foreach (var ticker in StockTickers)
                {
                    var parameters = new List<AlphaVantageApiWrapper.ApiParam>
                {
                    new AlphaVantageApiWrapper.ApiParam("interval", AlphaVantageApiWrapper.AvIntervalEnum.Daily.ToDescription()),
                };

                    //Start Collecting SMA values

                var SMA_5 = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "20";
                }
            }
        }
}