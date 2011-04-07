using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPersonalShortner.Lib.Domain.Repositories;
using MyPersonalShortner.Lib.Domain.Url;
using MyPersonalShortner.Lib.Domain.UrlConversion;

namespace MyPersonalShortner.Lib.Services
{
    public interface IShortnerService
    {
        string Shorten(string url);
        string Expand(string hash);
    }

    public class ShortnerService : IShortnerService
    {
        private readonly ILongUrlRepository repository;
        private readonly IUrlConversion urlConversion;
        public ShortnerService(ILongUrlRepository repository, IUrlConversion urlConversion)
        {
            this.repository = repository;
            this.urlConversion = urlConversion;
        }
        
        public string Shorten(string url)
        {
            var id = Add(url);
            var hash = this.urlConversion.Encode(id);
            return hash;
        }
        private int Add(string url)
        {
            var longUrl = new LongUrl { Url = url };
            this.repository.Add(longUrl);
            this.repository.Save();
            return longUrl.Id;
        }

        public string Expand(string hash)
        {
            var id = this.urlConversion.Decode(hash);
            var url = Get(id);
            return url;
        }
        private string Get(int id)
        {
            var longUrl = this.repository.GetById(id);
            return longUrl.Url;
        }
    }
}
