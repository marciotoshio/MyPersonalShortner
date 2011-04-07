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
        LongUrl Add(string url);
        string Shorten(int id);
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

        public LongUrl Add(string url)
        {
            var longUrl = new LongUrl { Url = url };
            this.repository.Add(longUrl);
            this.repository.Save();
            return longUrl;
        }

        public string Shorten(int id)
        {
            var hash = this.urlConversion.Encode(id);
            return hash;
        }

        public string Expand(string hash)
        {
            throw new NotImplementedException();
        }
    }
}
