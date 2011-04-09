using MyPersonalShortner.Lib.Domain.Repositories;
using MyPersonalShortner.Lib.Domain.Url;
using MyPersonalShortner.Lib.Domain.UrlConversion;
using System.Collections;

namespace MyPersonalShortner.Lib.Services
{
    public interface IShortnerService
    {
        void AddCustomUrl(string url, string customPart);
        string Shorten(string url);
        string Expand(string hash);
    }

    public class ShortnerService : IShortnerService
    {
        private static Hashtable customUrlsCache;

        private readonly ILongUrlRepository longUrlRepository;
        private readonly ICustomUrlRepository customUrlRepository;
        private readonly IUrlConversion urlConversion;
        public ShortnerService(ILongUrlRepository longUrlRepository, ICustomUrlRepository customUrlRepository, IUrlConversion urlConversion)
        {
            this.longUrlRepository = longUrlRepository;
            this.customUrlRepository = customUrlRepository;
            this.urlConversion = urlConversion;
            StartCustomUrlCache();
        }

        public void AddCustomUrl(string url, string customPart)
        {
            var customUrl = new CustomUrl { Url = url, CustomPart = customPart};
            customUrlRepository.Add(customUrl);
            customUrlRepository.Save();
            customUrlsCache.Add(customPart, url);
        }

        public string Shorten(string url)
        {
            var id = Add(url);
            var hash = urlConversion.Encode(id);
            return hash;
        }
        private int Add(string url)
        {
            var longUrl = new LongUrl { Url = url };
            longUrl = longUrlRepository.Add(longUrl);
            longUrlRepository.Save();
            return longUrl.Id;
        }

        public string Expand(string hash)
        {
            if (customUrlsCache.ContainsKey(hash))
            {
                return customUrlsCache[hash].ToString();
            }
            var id = urlConversion.Decode(hash);
            return Get(id);
        }
        private string Get(int id)
        {
            var longUrl = longUrlRepository.GetById(id);
            return longUrl.Url;
        }

        private void StartCustomUrlCache()
        {
            if (customUrlsCache != null) return;
            customUrlsCache = new Hashtable();
            var customUrls = customUrlRepository.GetAll();
            foreach (var customUrl in customUrls)
            {
                customUrlsCache.Add(customUrl.CustomPart, customUrl.Url);
            }
        }
    }
}
