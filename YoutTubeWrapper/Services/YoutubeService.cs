using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using YoutTubeWrapper.Models;

namespace YoutTubeWrapper.Services
{
    public class YoutubeService 
    {
        private readonly YTDBService _yTDBService;
        private readonly ILogger _logger;
        private HttpClient httpClient;
        private readonly IConfiguration Configuration;
        public YoutubeService(ILogger<YoutubeService> logger,YTDBService yTDBService, IConfiguration configuration)
        {
            this._logger = logger;
            this._yTDBService = yTDBService;
            this.Configuration = configuration;
        }

        public async Task getUpdatedResult(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try {
                    httpClient = new HttpClient();

                    httpClient.BaseAddress = new Uri(Configuration["YoutubeBaseUrl"]);

                    var query = HttpUtility.ParseQueryString(string.Empty);
                    query["part"] = "snippet";
                    query["maxResults"] = Configuration["YouTubeMaxCount"];
                    query["q"] = "apple|cricket|cooking|python";
                    query["type"] = "video";

                    query["key"] = Configuration["YouTubeKey"];

                    string queryString = query.ToString();

                    dynamic response = JsonConvert.DeserializeObject( await httpClient.GetStringAsync(httpClient.BaseAddress + queryString));

                    foreach( dynamic item in response["items"])
                    {
                        var obj = new YoutubeSchema();
                        obj.VideoId = item["id"]["videoId"];
                        obj.channelTitle = item["snippet"]["channelTitle"];
                        obj.description = item["snippet"]["description"];
                        obj.publishedAt = item["snippet"]["publishedAt"];
                        obj.title= item["snippet"]["title"];
                        obj.thumbnailUrl= item["snippet"]["thumbnails"]["default"]["url"];

                        _yTDBService.Create(obj);
                    }

                }
                catch(Exception e) {
                    _logger.LogError(e.Message);
                }
                finally
                {
                    
                    await Task.Delay(500000);
                }
            }
            return;
        }

    }
}

