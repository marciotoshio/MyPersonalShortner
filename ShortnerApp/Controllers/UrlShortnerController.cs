using MyPersonalShortner.Lib.CustomExceptions;
using MyPersonalShortner.Lib.Services;
using MyPersonalShortner.ShortnerApp.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace MyPersonalShortner.ShortnerApp.Controllers
{
	public class UrlShortnerController : ApiController
	{
		private readonly IShortnerService service;
		public UrlShortnerController(IShortnerService service)
		{
			//AppHelper.EnableCors(System.Web.HttpContext.Current);
			this.service = service;
		}

		// GET api/urlshortner
		public string Get()
		{
			return "Welcome, My Personal Shorner API v0.1!!!";
		}

		// POST api/urlshortner
		public HttpResponseMessage Post(ShortnerUrl shortnerUrl)
		{
			try
			{
				var url = shortnerUrl.Url.Trim();
				var hash = service.Shorten(url);
				return new HttpResponseMessage(HttpStatusCode.Created)
				{
					ReasonPhrase = "Shorten url created",
					Content = new ObjectContent<ApiShortenResult>(new ApiShortenResult { Hash = hash, LongUrl = url }, new JsonMediaTypeFormatter())
				};
			}
			catch (ShortnerValidationException ex)
			{
				throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
				{
					ReasonPhrase = ex.Message,
					Content = new ObjectContent<ApiErrorResult>(new ApiErrorResult { Errors = ex.Errors }, new JsonMediaTypeFormatter())
				});
			}
			catch (Exception ex)
			{
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}
		}
	}
}
