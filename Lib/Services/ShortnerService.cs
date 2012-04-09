using MyPersonalShortner.Lib.Domain.Repositories;
using MyPersonalShortner.Lib.Domain.Url;
using MyPersonalShortner.Lib.Domain.UrlConversion;
using System.Collections;
using System.Collections.Concurrent;
using MyPersonalShortner.Lib.Infrastructure;
using System.Collections.Generic;

namespace MyPersonalShortner.Lib.Services
{
    public interface IShortnerService
    {
        void AddCustomUrl(CustomUrl customUrl);
        string Shorten(string url);
        string Expand(string hash);
    }

    public class ShortnerService : IShortnerService
    {
        private static ConcurrentDictionary<string, string> customUrlsCache;

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

        public void AddCustomUrl(CustomUrl customUrl)
        {
            customUrlRepository.Add(customUrl);
            customUrlRepository.Save();
            customUrlsCache.TryAdd(customUrl.CustomPart, customUrl.Url);
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
            customUrlsCache = new ConcurrentDictionary<string, string>();
            var customUrls = customUrlRepository.GetAll();
            foreach (var customUrl in customUrls)
            {
                customUrlsCache.TryAdd(customUrl.CustomPart, customUrl.Url);
            }
        }
    }
}
