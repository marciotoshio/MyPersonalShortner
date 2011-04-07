using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPersonalShortner.Lib.Domain.Repositories;
using MyPersonalShortner.Lib.Infrastructure.Data;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly IUrlConversion urlConversion;
        public ShortnerService(ILongUrlRepository repository, IUnitOfWork unitOfWork, IUrlConversion urlConversion)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.urlConversion = urlConversion;
        }

        public string Shorten(string url)
        {
            throw new NotImplementedException();
        }

        public string Expand(string hash)
        {
            throw new NotImplementedException();
        }
    }
}
