using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using YoutTubeWrapper.Models;
using System.Threading.Tasks;
using YoutTubeWrapper.Services;

namespace YoutTubeWrapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YoutubeController : Controller
    {
        private readonly YTDBService _yTDBService;

        public YoutubeController(YTDBService yTDBService)
        {
            this._yTDBService = yTDBService;
        }

        [HttpGet]
        public IEnumerable<YoutubeSchema> Get([FromQuery]int queryCount = 5, [FromQuery]string searchQuery = "")
        {
            List<YoutubeSchema> result = new List<YoutubeSchema>();

            var mongoResponse = _yTDBService.Get();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                foreach (string searchKeyword in searchQuery.Split(" "))
                {
                    result.AddRange(mongoResponse.Where(_ => _.title.ToLower().Contains(searchKeyword)
                    || _.title.ToUpper().Contains(searchKeyword)
                    || _.description.ToUpper().Contains(searchKeyword)
                    || _.description.ToLower().Contains(searchKeyword)).ToList());
                }
            }
            else
                result = mongoResponse;
            
            return result.Take(queryCount);
        }
    }
}
