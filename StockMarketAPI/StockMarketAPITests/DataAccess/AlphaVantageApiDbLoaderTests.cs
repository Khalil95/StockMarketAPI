using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockMarketAPI.DataAccess;
using StockMarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketAPI.DataAccess.Tests
{
    [TestClass()]
    public class AlphaVantageApiDbLoaderTests
    {
        [TestMethod()]
        public async Task TestAsyncTestAsync()
        {
            var API_KEY = "X29IZ87X3MQOLPUZ";

            var StockTickers = new List<string> { "AAPL" };

            foreach (var ticker in StockTickers)
            {
                var parameters = new List<AlphaVantageApiWrapper.ApiParam>
                {
                    new AlphaVantageApiWrapper.ApiParam("symbol", ticker),
                    new AlphaVantageApiWrapper.ApiParam("interval", AlphaVantageApiWrapper.AvIntervalEnum.Daily.ToDescription()),
                    new AlphaVantageApiWrapper.ApiParam("time_period", "5"),
                    new AlphaVantageApiWrapper.ApiParam("series_type", AlphaVantageApiWrapper.AvSeriesType.Open.ToDescription()),
                };

                //Start Collecting SMA values
                var SMA_5 = await AlphaVantageApiWrapper.GetTechnical(parameters, API_KEY);
                parameters.FirstOrDefault(x => x.ParamName == "time_period").ParamValue = "20";
            }
        }
    }
}