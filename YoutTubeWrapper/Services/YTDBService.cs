using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using YoutTubeWrapper.DBConnector;
using YoutTubeWrapper.Models;

namespace YoutTubeWrapper.Services
{
    public class YTDBService
    {
        private readonly IMongoCollection<YoutubeSchema> _videos;
        public YTDBService(YTCacheDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _videos = database.GetCollection<YoutubeSchema>(settings.CollectionName);
        }

        public List<YoutubeSchema> Get() =>
           _videos.Find(book => true).SortByDescending(_=>_.publishedAt).ToList();

        public YoutubeSchema Get(string id) =>
            _videos.Find<YoutubeSchema>(book => book.Id == id).FirstOrDefault();

        public YoutubeSchema Create(YoutubeSchema youtube)
        {
            _videos.InsertOne(youtube);
            return youtube;
        }

        public void Update(string id, YoutubeSchema youtube) =>
            _videos.ReplaceOne(book => book.Id == id, youtube);

        public void Remove(YoutubeSchema youtube) =>
            _videos.DeleteOne(_ => _.Id == youtube.Id);

        public void Remove(string id) =>
            _videos.DeleteOne(_ => _.Id == id);
    }
}
